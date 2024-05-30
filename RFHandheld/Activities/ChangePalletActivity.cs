namespace RFHandheld
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using Android.Views.InputMethods;
    using Newtonsoft.Json;

    [Activity(Label = "ChangePalletActivity", Theme = "@style/AppTheme")]
    public class ChangePalletActivity : Activity
    {
        ListView oldRfidView;
        ListView newRfidView;
        TextView txtOldRfid;
        TextView txtNewRfid;
        TextView txtQr;
        PalletListAdapter oldAdapter;
        PalletListAdapter newAdapter;
        List<PalletInfo> oldList = new List<PalletInfo>();
        List<PalletInfo> newList = new List<PalletInfo>();
        string OriEPC = string.Empty;
        string NewEPC = string.Empty;
        List<string> MovingQR = new List<string>();
        Button Change;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.change_pallet);

            // List of QR of pallets
            oldRfidView = FindViewById<ListView>(Resource.Id.listOldRFID);
            newRfidView = FindViewById<ListView>(Resource.Id.listNewRFID);
            if (savedInstanceState != null)
            {
                var originalQr = savedInstanceState.GetString("Original");
                oldList = JsonConvert.DeserializeObject<List<PalletInfo>>(originalQr);

                var newQr = savedInstanceState.GetString("New");
                newList = JsonConvert.DeserializeObject<List<PalletInfo>>(newQr);
            }
            else
            {
                oldList = PalletInfo.InitialList();
                newList = PalletInfo.InitialList();
            }
            oldAdapter = new PalletListAdapter(this, oldList);
            newAdapter = new PalletListAdapter(this, newList);
            oldRfidView.Adapter = oldAdapter;
            newRfidView.Adapter = newAdapter;

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

            // Move pallet Function
            Change = FindViewById<Button>(Resource.Id.btAccept);
            Change.Click += (sender, e) =>
            {
                OnChangePalletFunction();
            };

            // Inputs
            txtOldRfid = FindViewById<TextView>(Resource.Id.txtOldRFID);
            txtOldRfid.SetRawInputType(Android.Text.InputTypes.Null);
            txtOldRfid.SetTextIsSelectable(true);
            txtOldRfid.KeyPress += Rfid_KeyPress;

            txtNewRfid = FindViewById<TextView>(Resource.Id.txtNewRFID);
            txtNewRfid.SetRawInputType(Android.Text.InputTypes.Null);
            txtNewRfid.SetTextIsSelectable(true);
            txtNewRfid.KeyPress += Rfid_KeyPress;

            txtQr = FindViewById<TextView>(Resource.Id.txtQR);
            txtQr.SetRawInputType(Android.Text.InputTypes.Null);
            txtQr.SetTextIsSelectable(true);
            txtQr.KeyPress += Qr_KeyPress;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            string original = JsonConvert.SerializeObject(oldList);
            outState.PutString("Original", original);
            string newListQR = JsonConvert.SerializeObject(newList);
            outState.PutString("New", newListQR);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
            imm.HideSoftInputFromWindow(txtOldRfid.WindowToken, 0);
            imm.HideSoftInputFromWindow(txtNewRfid.WindowToken, 0);
            imm.HideSoftInputFromWindow(txtQr.WindowToken, 0);
            return base.OnTouchEvent(e);
        }

        public void OnClearView()
        {
            // Reset display
            oldList = PalletInfo.InitialList();
            newList = PalletInfo.InitialList();
            oldAdapter = new PalletListAdapter(this, oldList);
            newAdapter = new PalletListAdapter(this, newList);
            oldRfidView.Adapter = oldAdapter;
            newRfidView.Adapter = newAdapter;

            // Inputs
            OriEPC = NewEPC = string.Empty;
            txtOldRfid.Enabled = true;
            txtNewRfid.Enabled = true;
            txtOldRfid.Post(() =>
            {
                txtOldRfid.Text = "";
            });
            txtNewRfid.Post(() =>
            {
                txtNewRfid.Text = "";
            });
            txtQr.Post(() =>
            {
                txtQr.Text = "";
            });
            txtOldRfid.RequestFocus();
        }

        private async void Rfid_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (e.Event.Action == KeyEventActions.Down && txtOldRfid.Text.Length > 0)
                {
                    var validation = await RfidValidation(txtOldRfid.Text);
                    if (validation)
                    {
                        OnReceivedOriginalRFID(txtOldRfid.Text);
                    }
                    else
                    {
                        txtOldRfid.Post(() =>
                        {
                            txtOldRfid.Text = "";
                        });
                    }
                    e.Handled = true;
                }
                if (e.Event.Action == KeyEventActions.Down && txtNewRfid.Text.Length > 0)
                {
                    var validation = await RfidValidation(txtOldRfid.Text);
                    if (validation)
                    {
                        OnReceivedNewRFID(txtNewRfid.Text);
                    }
                    else
                    {
                        txtNewRfid.Post(() =>
                        {
                            txtNewRfid.Text = "";
                        });
                    }
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        private async Task<bool> RfidValidation(string input)
        {
            var validation = await InputValidation.EpcValidation(input);
            if (validation.Item1 == 1 && validation.Item2[0].Location != "NOT FOUND")
            {
                return true;
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
                Toast.MakeText(this, message, ToastLength.Long).Show();
                return false;
            }
        }

        private void Qr_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (e.Event.Action == KeyEventActions.Down && txtQr.Text.Length > 0)
                {
                    OnReceivedQR(txtQr.Text);
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        public async void OnReceivedOriginalRFID(string value)
        {
            var result = await API.GET_PALLET_INFORMATION(value);

            if (result.Item1 == 1 && result.Item2[0].MaterialCode != "NOT FOUND")
            {
                oldList = PalletInfo.InitialList();
                oldList.AddRange(result.Item2);
                oldAdapter = new PalletListAdapter(this, oldList);
                oldRfidView.Adapter = oldAdapter;

                OriEPC = value;
                txtOldRfid.Enabled = false;
                if (string.IsNullOrEmpty(NewEPC))
                    txtNewRfid.RequestFocus();
                else
                    txtQr.RequestFocus();
            }
            else
            {
                Toast.MakeText(this, $"Error get location - {result.Item2[0].MaterialCode}", ToastLength.Long).Show();
                OnClearView();
            }
        }

        public async void OnReceivedNewRFID(string value)
        {
            var result = await API.GET_PALLET_INFORMATION(value);

            if (result.Item1 == 1 && result.Item2[0].MaterialCode != "NOT FOUND")
            {
                newList = PalletInfo.InitialList();
                newList.AddRange(result.Item2);
                newAdapter = new PalletListAdapter(this, newList);
                newRfidView.Adapter = newAdapter;

                NewEPC = value;
                txtNewRfid.Enabled = false;
                if (string.IsNullOrEmpty(OriEPC))
                    txtOldRfid.RequestFocus();
                else
                    txtQr.RequestFocus();
            }
            else
            {
                Toast.MakeText(this, $"Error get location - {result.Item2[0].MaterialCode}", ToastLength.Long).Show();
                OnClearView();
            }
        }

        public async void OnReceivedQR(string value)
        {
            // Clear input
            txtQr.Post(() =>
            {
                txtQr.Text = "";
            });

            // Get input QR information
            var result = await API.GET_QR_INFORMATION(value);
            if (result.Item1 == 1)
            {
                var match = CompareQrInput(result.Item2);
                if (match != null)
                {
                    // Add moving qr value
                    MovingQR.Add(value);

                    // Remove QR value from original List
                    oldList.Remove(match);
                    oldAdapter = new PalletListAdapter(this, oldList);
                    oldRfidView.Adapter = oldAdapter;

                    // Add QR value to new List
                    newList.Add(match);
                    newAdapter = new PalletListAdapter(this, newList);
                    newRfidView.Adapter = newAdapter;
                }
                else
                {
                    // QR not match any box in original pallet
                    Toast.MakeText(this, $"QR Code not match - {result.Item2.MaterialCode}", ToastLength.Long).Show();
                }
            }
            else
            {
                // QR string invalid
                Toast.MakeText(this, $"Error get QR information - {result.Item2.MaterialCode}", ToastLength.Long).Show();
            }
        }

        public PalletInfo CompareQrInput(QR_INFORMATION value)
        {
            foreach (var item in oldList)
            {
                if (item.MaterialCode == value.MaterialCode && item.LotNumber == value.LotNumber
                    && item.Quantity == value.Quantity && item.Box == value.Box)
                {
                    return item;
                }
            }
            return null;
        }

        public async void OnChangePalletFunction()
        {
            if (MovingQR.Count > 0 && OriEPC != string.Empty && NewEPC != string.Empty)
            {
                Change.Enabled = false;
                Change.Text = "Change pallet request processing...Please wait...";
                var result = await API.POST_MOVING_PALLET_QR(OriEPC, NewEPC, MovingQR);
                if (result == "Moving Pallet QR - OK")
                {
                    OnClearView();
                }
                Toast.MakeText(this, result, ToastLength.Long).Show();
                Change.Enabled = true;
                Change.Text = "CHANGE PALLET";
            }
        }

    }
}