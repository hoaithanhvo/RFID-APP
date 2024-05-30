namespace RFHandheld
{
    using System.Linq;
    using System.Collections.Generic;

    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using Android.Views.InputMethods;
    using Newtonsoft.Json;

    [Activity(Label = "PutInActivity", Theme = "@style/AppTheme")]
    public class PutInActivity : Activity
    {
        ListView putinList;
        ListView rfidListView;
        TextView txtRFID;
        TextView txtLocation;
        string RFID = string.Empty;
        string Location = string.Empty;
        string NewLocation = string.Empty;
        List<string> DisplayList = new List<string>();
        ArrayAdapter<string> adapter;
        List<RfidInfo> RFID_List = new List<RfidInfo>();
        PutListAdapter listAdapter;
        Button Put;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.put_in);

            // ListView to display input
            putinList = FindViewById<ListView>(Resource.Id.list);
            if (savedInstanceState != null)
            {
                DisplayList = savedInstanceState.GetStringArrayList("DisplayList").ToList();
                var history = savedInstanceState.GetString("History");
                RFID_List = JsonConvert.DeserializeObject<List<RfidInfo>>(history);
            }
            else
            {
                RFID_List = RfidInfo.InitialList();
                DisplayList = new List<string>()
                {
                    "Scanning result",
                    "RFID - ",
                    "Location - "
                };
            }
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DisplayList);
            putinList.Adapter = adapter;

            // ListView to display RFID Information
            rfidListView = FindViewById<ListView>(Resource.Id.listInfo);
            listAdapter = new PutListAdapter(this, RFID_List);
            rfidListView.Adapter = listAdapter;

            // Back button
            var Back = FindViewById<Button>(Resource.Id.btBack);
            Back.Click += (sender, e) =>
            {
                base.OnBackPressed();
            };

            // Put In Function
            Put = FindViewById<Button>(Resource.Id.btPutin);
            Put.Click += (sender, e) =>
            {
                OnPutFunction();
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

            txtLocation = FindViewById<TextView>(Resource.Id.txtLocation);
            txtLocation.SetRawInputType(Android.Text.InputTypes.Null);
            txtLocation.SetTextIsSelectable(true);
            txtLocation.KeyPress += Location_KeyPress;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            string history = JsonConvert.SerializeObject(RFID_List);
            outState.PutStringArrayList("DisplayList", DisplayList);
            outState.PutString("History", history);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
            imm.HideSoftInputFromWindow(txtRFID.WindowToken, 0);
            imm.HideSoftInputFromWindow(txtLocation.WindowToken, 0);
            return base.OnTouchEvent(e);
        }

        private async void RFID_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (e.Event.Action == KeyEventActions.Down && txtRFID.Text.Length > 0)
                {
                    var validation = await InputValidation.EpcValidation(txtRFID.Text);
                    if (validation.Item1 == 1 && validation.Item2[0].Location != "NOT FOUND")
                    {
                        RFID = txtRFID.Text;
                        OnReceivedRFID(validation.Item2);
                    }
                    else
                    {
                        string message = string.Empty;
                        if (validation.Item2.Count > 0 && validation.Item2[0].Location == "NOT FOUND")
                        {
                            message = "RFID tag information not found";
                        }
                        else if (validation.Item1 == 0)
                        {
                            // API error
                            message = $"API error - {validation.Item2}";
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

        private async void Location_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (e.Event.Action == KeyEventActions.Down && txtLocation.Text.Length > 0)
                {
                    var validation = await InputValidation.LocationValidation(txtLocation.Text, Location);
                    if (validation == "OK")
                    {
                        NewLocation = txtLocation.Text;
                        OnReceivedLocation();
                    }
                    else
                    {
                        string message = string.Empty;
                        switch (validation)
                        {
                            case "FULL":
                                message = $"Location error - {txtLocation.Text} Full";
                                break;
                            case "DISABLED":
                                message = $"Location error - {txtLocation.Text} Not used / Disabled";
                                break;
                            case "FORMAT":
                                message = $"Location error - {txtLocation.Text} Wrong format";
                                break;
                            default:
                                message = $"API error - {validation}";
                                break;
                        }
                        txtLocation.Post(() =>
                        {
                            txtLocation.Text = "";
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
            // Reset display input
            DisplayList = new List<string>
            {
                "Scanning result",
                "RFID - ",
                "Location - "
            };
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DisplayList);
            putinList.Adapter = adapter;

            // Reset rfid information
            RFID_List = RfidInfo.InitialList();
            listAdapter = new PutListAdapter(this, RFID_List);
            rfidListView.Adapter = listAdapter;

            // Reset input
            txtRFID.Enabled = true;
            RFID = Location = NewLocation = string.Empty;
            txtRFID.Post(() =>
            {
                txtRFID.Text = "";
            });
            txtLocation.Post(() =>
            {
                txtLocation.Text = "";
            });
            txtRFID.RequestFocus();
        }

        public void OnReceivedRFID(List<RfidInfo> data)
        {
            // Display RFID input on ListView
            adapter.Remove(DisplayList[1]);
            DisplayList[1] = $"RFID - {RFID}";
            adapter.Insert(DisplayList[1], 1);
            adapter.NotifyDataSetChanged();

            // Display rfid information
            RFID_List = RfidInfo.InitialList();
            RFID_List.AddRange(data);
            listAdapter = new PutListAdapter(this, RFID_List);
            rfidListView.Adapter = listAdapter;

            // Display Location information
            adapter.Remove(DisplayList[2]);
            if (NewLocation == string.Empty || NewLocation == Location)
            {
                // RFID scan first or Same Location
                Location = RFID_List[1].Location;
                DisplayList[2] = $"Location - {Location}";
            }
            else
            {
                // Location scan first and different location
                DisplayList[2] = $"Location - {NewLocation} => {Location}";
                Location = NewLocation;
            }
            adapter.Insert(DisplayList[2], 2);
            adapter.NotifyDataSetChanged();

            // Disable RFID and focus Location
            txtRFID.Enabled = false;
            txtLocation.RequestFocus();
        }

        public void OnReceivedLocation()
        {
            txtLocation.Post(() =>
            {
                txtLocation.Text = "";
            });
            adapter.Remove(DisplayList[2]);
            if (Location != string.Empty && Location != NewLocation)
            {
                DisplayList[2] = $"Location - {Location} => {NewLocation}";
                Location = NewLocation;
            }
            else
            {
                Location = NewLocation;
                DisplayList[2] = $"Location - {Location}";
            }
            adapter.Insert(DisplayList[2], 2);
            adapter.NotifyDataSetChanged();
        }

        public async void OnPutFunction()
        {
            if (RFID != string.Empty && Location != string.Empty)
            {
                Put.Enabled = false;
                Put.Text = "Put in request processing... Please wait...";
                var result = await API.PUT_IN(RFID, Location);
                if (result == "Put - OK")
                {
                    OnClearView();
                }
                Toast.MakeText(this, result, ToastLength.Long).Show();
                Put.Enabled = true;
                Put.Text = "PUT IN";
            }
        }
    }
}