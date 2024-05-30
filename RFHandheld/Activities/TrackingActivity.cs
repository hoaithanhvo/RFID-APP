namespace RFHandheld
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using Android.Views.InputMethods;
    using Newtonsoft.Json;

    [Activity(Label = "TrackingActivity", Theme = "@style/AppTheme")]
    public class TrackingActivity : Activity
    {
        ListView resultList;
        RadioButton radioRack;
        RadioButton radioEPC;
        RadioButton radioMaterial;
        TextView txtLocation;
        TextView txtEPC;
        TextView txtMaterial;
        string Location = string.Empty;
        string EPC = string.Empty;
        string Material = string.Empty;
        List<TrackingInfo> TrackingList = new List<TrackingInfo>();
        TrackingAdapter listAdapter;
        Button Track;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.tracking);

            // ListView to display result
            resultList = FindViewById<ListView>(Resource.Id.list);
            if (savedInstanceState != null)
            {
                var history = savedInstanceState.GetString("History");
                TrackingList = JsonConvert.DeserializeObject<List<TrackingInfo>>(history);
            }
            else
            {
                TrackingList = TrackingInfo.InitialList();
            }
            listAdapter = new TrackingAdapter(this, TrackingList);
            resultList.Adapter = listAdapter;

            // Back button
            var Back = FindViewById<Button>(Resource.Id.btBack);
            Back.Click += (sender, e) =>
            {
                base.OnBackPressed();
            };

            // Tracking button
            Track = FindViewById<Button>(Resource.Id.btTracking);
            Track.Click += (sender, e) =>
            {
                OnTrackFunction();
            };

            // Clear button
            var Clear = FindViewById<Button>(Resource.Id.btClear);
            Clear.Click += (sender, e) =>
            {
                OnClearView();
            };

            // Input group
            // Location
            var radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            radioGroup.CheckedChange += Radio_CheckedChange;
            radioRack = FindViewById<RadioButton>(Resource.Id.radioRack);
            txtLocation = FindViewById<TextView>(Resource.Id.txtLocation);
            txtLocation.SetRawInputType(Android.Text.InputTypes.Null);
            txtLocation.SetTextIsSelectable(true);
            txtLocation.KeyPress += Location_KeyPress;

            // EPC
            radioEPC = FindViewById<RadioButton>(Resource.Id.radioEPC);
            txtEPC = FindViewById<TextView>(Resource.Id.txtEPC);
            txtEPC.SetRawInputType(Android.Text.InputTypes.Null);
            txtEPC.SetTextIsSelectable(true);
            txtEPC.KeyPress += EPC_KeyPress;

            // Material
            radioMaterial = FindViewById<RadioButton>(Resource.Id.radioMaterial);
            txtMaterial = FindViewById<TextView>(Resource.Id.txtMaterial);
            txtMaterial.SetRawInputType(Android.Text.InputTypes.Null);
            txtMaterial.SetTextIsSelectable(true);
            txtMaterial.KeyPress += Material_KeyPress;

            // Initial state
            OnRadioCheckedState();
        }

        private void Radio_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            OnRadioCheckedState();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            string history = JsonConvert.SerializeObject(TrackingList);
            outState.PutString("History", history);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
            imm.HideSoftInputFromWindow(txtLocation.WindowToken, 0);
            imm.HideSoftInputFromWindow(txtEPC.WindowToken, 0);
            imm.HideSoftInputFromWindow(txtMaterial.WindowToken, 0);
            return base.OnTouchEvent(e);
        }

        public void OnClearView()
        {
            // Reset result list information
            TrackingList = TrackingInfo.InitialList();
            listAdapter = new TrackingAdapter(this, TrackingList);
            resultList.Adapter = listAdapter;

            // Reset inputs
            Location = EPC = Material = string.Empty;
            txtLocation.Post(() => { txtLocation.Text = ""; });
            txtEPC.Post(() => { txtEPC.Text = ""; });
            txtMaterial.Post(() => { txtMaterial.Text = ""; });

            // Reset radio buttons
            radioRack.Checked = true;
            radioEPC.Checked = false;
            radioMaterial.Checked = false;
            OnRadioCheckedState();
        }

        public void OnRadioCheckedState()
        {
            txtLocation.Post(() => { txtLocation.Text = ""; });
            txtEPC.Post(() => { txtEPC.Text = ""; });
            txtMaterial.Post(() => { txtMaterial.Text = ""; });

            if (radioRack.Checked)
            {
                txtLocation.Enabled = true;
                txtEPC.Enabled = false;
                txtMaterial.Enabled = false;

                txtLocation.RequestFocus();
            }
            else if (radioEPC.Checked)
            {
                txtLocation.Enabled = false;
                txtEPC.Enabled = true;
                txtMaterial.Enabled = false;

                txtEPC.RequestFocus();
            }
            else if (radioMaterial.Checked)
            {
                txtLocation.Enabled = false;
                txtEPC.Enabled = false;
                txtMaterial.Enabled = true;

                txtMaterial.RequestFocus();
            }
            else
            {
                OnClearView();
            }
        }

        private async void Location_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (e.Event.Action == KeyEventActions.Down && txtLocation.Text.Length > 0)
                {
                    EPC = Material = string.Empty;
                    var validation = await InputValidation.LocationValidation(txtLocation.Text, string.Empty);
                    if (validation == "OK" || validation == "FULL")
                    {
                        Location = txtLocation.Text;
                        OnTrackFunction();
                    }
                    else
                    {
                        string message = string.Empty;
                        switch (validation)
                        {
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

        private async void EPC_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (e.Event.Action == KeyEventActions.Down && txtEPC.Text.Length > 0)
                {
                    Location = Material = string.Empty;
                    var validation = await InputValidation.EpcValidation(txtEPC.Text);
                    if (validation.Item1 == 1 && validation.Item2[0].Location != "NOT FOUND")
                    {
                        EPC = txtEPC.Text;
                        OnTrackFunction();
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
                        txtEPC.Post(() =>
                        {
                            txtEPC.Text = "";
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

        private void Material_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (e.Event.Action == KeyEventActions.Down && txtMaterial.Text.Length > 0)
                {
                    Location = EPC = string.Empty;
                    if (txtMaterial.Text != string.Empty)
                    {
                        Material = txtMaterial.Text;
                        OnTrackFunction();
                    }
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        public async void OnTrackFunction()
        {
#pragma warning disable IDE0042 // Deconstruct variable declaration
            var checkInput = (
#pragma warning restore IDE0042 // Deconstruct variable declaration
                IsOnlyOneStringWithValue: new[] { Location, EPC, Material }.Count(s => !string.IsNullOrEmpty(s)) == 1,
                ValueOfString: new[] { Location, EPC, Material }.FirstOrDefault(s=> !string.IsNullOrEmpty(s)) ?? "",
                SelectedStringIndex: Array.IndexOf(new[] { Location, EPC, Material }, new[] { Location, EPC, Material }.FirstOrDefault(s => !string.IsNullOrEmpty(s)))
                );

            if (checkInput.IsOnlyOneStringWithValue)
            {
                Track.Enabled = false;
                Track.Text = "Tracking processing...Please wait...";
                var result = await API.GET_TRACKING_INFORMATION(checkInput.SelectedStringIndex, checkInput.ValueOfString);
                if (result.Item1 == 1 && result.Item2[0].Location != "NOT FOUND")
                {
                    TrackingList = TrackingInfo.InitialList();
                    TrackingList.AddRange(result.Item2);
                    listAdapter = new TrackingAdapter(this, TrackingList);
                    resultList.Adapter = listAdapter;
                }
                else
                {
                    Toast.MakeText(this, $"Tracking error - {result.Item2[0].Location}", ToastLength.Long).Show();
                    OnClearView();
                }
                Track.Enabled = true;
                Track.Text = "TRACKING";
            }
            else
            {
                // Multiple inputs -> Error
                Toast.MakeText(this, "There are more than 1 search input. Please retry", ToastLength.Long).Show();
                OnClearView();
            }
        }
    }
}