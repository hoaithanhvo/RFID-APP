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

    [Activity(Label = "DeleteMappingActivity", Theme = "@style/AppTheme")]
    public class DeleteMappingActivity : Activity
    {
        ListView scanningListView;
        ListView rfidListView;
        TextView txtRFID;
        string RFID = string.Empty;
        List<string> DisplayList = new List<string>();
        ArrayAdapter<string> adapter;
        List<RfidInfo> RFID_List = new List<RfidInfo>();
        PutListAdapter listAdapter;
        Button Delete;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.delete);

            // ListView to display input
            scanningListView = FindViewById<ListView>(Resource.Id.list);
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
                    "RFID - "
                };
            }
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DisplayList);
            scanningListView.Adapter = adapter;

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

            // Delete mapping function
            Delete = FindViewById<Button>(Resource.Id.btDelete);
            Delete.Click += (sender, e) =>
            {
                OnDeleteFunction();
            };

            // Clear button
            var Clear = FindViewById<Button>(Resource.Id.btClear);
            Clear.Click += (sender, e) =>
            {
                OnClearView();
            };

            // Display input
            txtRFID = FindViewById<TextView>(Resource.Id.txtRFID);
            txtRFID.SetRawInputType(Android.Text.InputTypes.Null);
            txtRFID.SetTextIsSelectable(true);
            txtRFID.KeyPress += RFID_KeyPress;
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

        public void OnClearView()
        {
            // Reset display input
            DisplayList = new List<string>
            {
                "Scanning result",
                "RFID - "
            };
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DisplayList);
            scanningListView.Adapter = adapter;

            // Reset rfid information
            RFID_List = RfidInfo.InitialList();
            listAdapter = new PutListAdapter(this, RFID_List);
            rfidListView.Adapter = listAdapter;

            // Reset input
            txtRFID.Enabled = true;
            RFID = string.Empty;
            txtRFID.Post(() =>
            {
                txtRFID.Text = "";
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
        }

        public async void OnDeleteFunction()
        {
            if (RFID != string.Empty)
            {
                Delete.Enabled = false;
                Delete.Text = "Delete mapping request processing...Please wait...";
                var result = await API.DELETE_MAPPING(RFID);
                if (result == "Delete - OK")
                {
                    OnClearView();
                }
                Toast.MakeText(this, result, ToastLength.Long).Show();
                Delete.Enabled = true;
                Delete.Text = "DELETE MAPPING";
            }
        }
    }
}