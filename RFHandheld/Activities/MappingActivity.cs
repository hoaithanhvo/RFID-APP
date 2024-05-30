namespace RFHandheld
{
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Collections.Generic;

    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using Android.Views.InputMethods;
    using Newtonsoft.Json;

    [Activity(Label = "MappingActivity", Theme = "@style/AppTheme")]
    public class MappingActivity : Activity
    {
        ListView mappingListView;
        ListView qrListView;
        TextView txtRFID;
        TextView txtQr;
        string RFID = string.Empty;
        List<string> QR = new List<string>();
        List<QR_INFORMATION> QR_List = new List<QR_INFORMATION>();
        List<string> DisplayList = new List<string>();
        ArrayAdapter<string> adapter;
        QrListAdapter qrAdapter;
        Button Mapping;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mapping);

            // List view to display input
            mappingListView = FindViewById<ListView>(Resource.Id.list);
            if (savedInstanceState != null)
            {
                DisplayList = savedInstanceState.GetStringArrayList("DisplayList").ToList();
                var history = savedInstanceState.GetString("History");
                QR_List = JsonConvert.DeserializeObject<List<QR_INFORMATION>>(history);
            }
            else
            {
                QR_List = QR_INFORMATION.InitialList();
                DisplayList = new List<string>()
                {
                    "Scanning result",
                    "RFID - ",
                    "QR(s) - "
                };
            }
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DisplayList);
            mappingListView.Adapter = adapter;

            // List view to display QRs
            qrListView = FindViewById<ListView>(Resource.Id.listInfo);
            qrAdapter = new QrListAdapter(this, QR_List);
            qrListView.Adapter = qrAdapter;

            // Mapping Function
            Mapping = FindViewById<Button>(Resource.Id.btMapping);
            Mapping.Click += (sender, e) =>
            {
                OnMappingFunction();
            };

            // Back button
            var Back = FindViewById<Button>(Resource.Id.btBack);
            Back.Click += (sender, e) =>
            {
                base.OnBackPressed();
            };

            // Clear button
            var Clear = FindViewById<Button>(Resource.Id.btClear);
            Clear.Click += (sender, e) =>
            {
                OnClearView();
            };

            // Display input(s)
            txtRFID = FindViewById<TextView>(Resource.Id.txtRFID);
            txtRFID.SetRawInputType(Android.Text.InputTypes.Null);
            txtRFID.SetTextIsSelectable(true);
            txtRFID.KeyPress += RFID_KeyPress;

            txtQr = FindViewById<TextView>(Resource.Id.txtQR);
            txtQr.SetRawInputType(Android.Text.InputTypes.Null);
            txtQr.SetTextIsSelectable(true);
            txtQr.KeyPress += QR_KeyPress;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            string history = JsonConvert.SerializeObject(QR_List);
            outState.PutStringArrayList("DisplayList", DisplayList);
            outState.PutString("History", history);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
            imm.HideSoftInputFromWindow(txtRFID.WindowToken, 0);
            imm.HideSoftInputFromWindow(txtQr.WindowToken, 0);
            return base.OnTouchEvent(e);
        }

        private async void RFID_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (e.Event.Action == KeyEventActions.Down && txtRFID.Text.Length > 0)
                {
                    var validation = await InputValidation.EpcValidation(txtRFID.Text);
                    if (validation.Item1 == 1 && validation.Item2[0].Location == "NOT FOUND")
                    {
                        // Validation for mapping EPC succeed
                        RFID = txtRFID.Text;
                        OnReceivedRFID();
                    }
                    else
                    {
                        string message = string.Empty;
                        if (validation.Item2.Count > 0 && validation.Item2[0].Location != "NOT FOUND")
                        {
                            // RFID tag already mapped
                            message = "RFID tag already scanned / mapped";
                        }
                        else if (validation.Item1 == 0)
                        {
                            // API failed
                            message = $"API error - {validation.Item2[0].Location}";
                        }
                        else
                        {
                            // EPC wrong format
                            message = "RFID tag have wrong format";
                        }
                        txtRFID.Post(() =>
                        {
                            txtRFID.Text = "";
                        });
                        Toast.MakeText(this, message, ToastLength.Long).Show();
                    }
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        private async void QR_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (e.Event.Action == KeyEventActions.Down && txtQr.Text.Length > 0)
                {
                    var validation = await InputValidation.QrValidation(txtQr.Text, QR);
                    if (validation.Item1 == 0)
                    {
                        // Validation succeed
                        QR.Add(txtQr.Text);
                        OnReceivedQR(validation.Item2);
                    }
                    else
                    {
                        // Errors
                        string message = string.Empty;
                        switch (validation.Item1)
                        {
                            case 1:
                                // Material not match
                                message = "The QR value has a different MaterialCode";
                                break;
                            case 2:
                                // QR length not correct
                                message = "The QR code has an incorrect format";
                                break;
                            case 3:
                                // QR already scanned
                                message = "The QR code already scanned / DUPLICATION";
                                break;
                            case 4:
                                // Description not found
                                message = "MaterialCode error - Description not found";
                                break;
                            case 5:
                                // QR already mapped
                                message = "This QR code already mapped";
                                break;
                            default:
                                // API error
                                message = $"API error - {validation.Item2.MaterialCode}";
                                break;
                        }
                        txtQr.Post(() =>
                        {
                            txtQr.Text = "";
                        });
                        Toast.MakeText(this, message, ToastLength.Long).Show();
                    }
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        public void OnClearView()
        {
            // Reset input
            txtRFID.Enabled = true;
            RFID = string.Empty;
            QR = new List<string>();

            // Reset display input
            DisplayList = new List<string>()
            {
                "Scanning result",
                "RFID - ",
                "QR(s) - "
            };
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DisplayList);
            mappingListView.Adapter = adapter;

            // Reset qr(s) information
            QR_List = QR_INFORMATION.InitialList();
            qrAdapter = new QrListAdapter(this, QR_List);
            qrListView.Adapter = qrAdapter;

            txtRFID.Post(() =>
            {
                txtRFID.Text = "";
            });
            txtQr.Post(() =>
            {
                txtQr.Text = "";
            });
            txtRFID.RequestFocus();
        }

        public void OnReceivedRFID()
        {
            // Display RFID input on ListView
            adapter.Remove(DisplayList[1]);
            DisplayList[1] = $"RFID - {RFID}";
            adapter.Insert(DisplayList[1], 1);
            adapter.NotifyDataSetChanged();

            // Disable RFID and focus QR
            txtRFID.Enabled = false;
            txtQr.RequestFocus();
        }

        public void OnReceivedQR(QR_INFORMATION data)
        {
            txtQr.Post(() =>
            {
                txtQr.Text = "";
            });

            // Display QR count on ListView
            int count = GetQrCount(DisplayList[2]);
            adapter.Remove(DisplayList[2]);
            DisplayList[2] = $"QR(s) - {count + 1}";
            adapter.Insert(DisplayList[2], 2);
            adapter.NotifyDataSetChanged();

            // Display List of QR on ListView
            QR_List.Add(data);
            qrAdapter = new QrListAdapter(this, QR_List);
            qrListView.Adapter = qrAdapter;
        }

        public int GetQrCount(string input)
        {
            string pattern = @"-?\d+";
            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                if (int.TryParse(match.Value, out int number))
                    return number;
                return 0;
            }
            return 0;
        }

        public async void OnMappingFunction()
        {
            if (RFID != string.Empty && QR.Count > 0)
            {
                Mapping.Enabled = false;
                Mapping.Text = "Mapping request processing...Please wait...";
                var result = await API.POST_MAPPING(RFID, QR);
                if (result == "Mapping - OK")
                {
                    OnClearView();
                }
                Toast.MakeText(this, result, ToastLength.Long).Show();
                Mapping.Enabled = true;
                Mapping.Text = "MAPPING";
            }
        }
    }
}