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

    [Activity(Label = "PickingActivity", Theme = "@style/AppTheme")]
    public class PickingActivity : Activity
    {
        ListView pickingList;
        DateTime selectedFrom = DateTime.MinValue;
        DateTime selectedTo = DateTime.MinValue;
        string dateFrom = string.Empty;
        string dateTo = string.Empty;
        List<PickingListInfo> pickingListInfo = new List<PickingListInfo>();
        PickingListAdapter adapter;
        TextView txtDateFrom;
        TextView txtDateTo;
        CalendarView calendarViewFrom;
        CalendarView calendarViewTo;
        bool isCalendarViewFromVisible = false;
        bool isCalendarViewToVisible = false;
        Button Picking;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.picking);

            // ListView here
            if (savedInstanceState != null)
            {
                var history = savedInstanceState.GetString("History");
                pickingListInfo = JsonConvert.DeserializeObject<List<PickingListInfo>>(history);
            }
            else
            {
                pickingListInfo = PickingListInfo.InitialList();
            }
            pickingList = FindViewById<ListView>(Resource.Id.list);
            adapter = new PickingListAdapter(this, pickingListInfo);
            pickingList.Adapter = adapter;

            // Back button
            var Back = FindViewById<Button>(Resource.Id.btBack);
            Back.Click += (sender, e) =>
            {
                base.OnBackPressed();
            };

            // Clear button
            var _Clear = FindViewById<Button>(Resource.Id.btClear);
            _Clear.Click += (sender, e) =>
            {
                OnClearView();
            };

            // Get Picking List Function
            Picking = FindViewById<Button>(Resource.Id.btPickingList);
            Picking.Click += (sender, e) =>
            {
                OnPickingFunction();
            };

            // Inputs
            txtDateFrom = FindViewById<TextView>(Resource.Id.txtDateFrom);
            txtDateFrom.SetRawInputType(Android.Text.InputTypes.Null);
            txtDateFrom.SetTextIsSelectable(true);
            txtDateFrom.Click += DateFrom_Click;

            txtDateTo = FindViewById<TextView>(Resource.Id.txtDateTo);
            txtDateTo.SetRawInputType(Android.Text.InputTypes.Null);
            txtDateTo.SetTextIsSelectable(true);
            txtDateTo.Click += DateTo_Click;

            calendarViewFrom = FindViewById<CalendarView>(Resource.Id.calendarViewFrom);
            calendarViewFrom.Visibility = ViewStates.Gone;

            calendarViewTo = FindViewById<CalendarView>(Resource.Id.calendarViewTo);
            calendarViewTo.Visibility = ViewStates.Gone;
        }

        private void DateFrom_Click(object sender, EventArgs e)
        {
            isCalendarViewFromVisible = !isCalendarViewFromVisible;
            calendarViewFrom.Visibility = isCalendarViewFromVisible ? ViewStates.Visible : ViewStates.Gone;

            // Hide CalendarView To if it is visible
            if (isCalendarViewToVisible)
            {
                calendarViewTo.Visibility = ViewStates.Gone;
                isCalendarViewToVisible = false;
            }

            if (isCalendarViewFromVisible)
            {
                calendarViewFrom.DateChange += (s, args) =>
                {
                    var selectedDate = new DateTime(args.Year, args.Month + 1, args.DayOfMonth);
                    if (selectedTo != DateTime.MinValue && selectedDate > selectedTo)
                    {
                        Toast.MakeText(this, "Invalid date selection. 'Date From' must be before 'Date To'", ToastLength.Short).Show();
                    }
                    else
                    {
                        selectedFrom = selectedDate;
                        txtDateFrom.Text = selectedFrom.ToString("dd/MM/yyyy");
                        calendarViewFrom.Visibility = ViewStates.Gone;
                        isCalendarViewFromVisible = false;
                    }
                };
            }
        }

        private void DateTo_Click(object sender, EventArgs e)
        {
            isCalendarViewToVisible = !isCalendarViewToVisible;
            calendarViewTo.Visibility = isCalendarViewToVisible ? ViewStates.Visible : ViewStates.Gone;

            // Hide CalendarView From if it is visible
            if (isCalendarViewFromVisible)
            {
                calendarViewFrom.Visibility = ViewStates.Gone;
                isCalendarViewFromVisible = false;
            }

            if (isCalendarViewToVisible)
            {
                calendarViewTo.DateChange += (s, args) =>
                {
                    var selectedDate = new DateTime(args.Year, args.Month + 1, args.DayOfMonth);
                    if (selectedFrom != DateTime.MinValue && selectedDate < selectedFrom)
                    {
                        Toast.MakeText(this, "Invalid date selection. 'Date To' must be after 'Date From'", ToastLength.Short).Show();
                    }
                    else
                    {
                        selectedTo = selectedDate;
                        txtDateTo.Text = selectedTo.ToString("dd/MM/yyyy");
                        calendarViewTo.Visibility = ViewStates.Gone;
                        isCalendarViewToVisible = false;
                    }
                };
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            string history = JsonConvert.SerializeObject(pickingListInfo);
            outState.PutString("History", history);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
            imm.HideSoftInputFromWindow(txtDateFrom.WindowToken, 0);
            imm.HideSoftInputFromWindow(txtDateTo.WindowToken, 0);
            return base.OnTouchEvent(e);
        }

        public void OnClearView()
        {
            // Reset listview
            pickingListInfo = PickingListInfo.InitialList();
            adapter = new PickingListAdapter(this, pickingListInfo);
            pickingList.Adapter = adapter;

            // Reset date values
            selectedFrom = selectedTo = DateTime.MinValue;
            dateFrom = dateTo = string.Empty;
            txtDateFrom.Post(() => { txtDateFrom.Text = ""; });
            txtDateTo.Post(() => { txtDateTo.Text = ""; });

            // Hide calendar views
            calendarViewFrom.Visibility = ViewStates.Gone;
            isCalendarViewFromVisible = false;
            calendarViewTo.Visibility = ViewStates.Gone;
            isCalendarViewToVisible = false;
        }

        public async void OnPickingFunction()
        {
            dateFrom = txtDateFrom.Text;
            dateTo = txtDateTo.Text;
            if (!string.IsNullOrEmpty(dateFrom) && !string.IsNullOrEmpty(dateTo))
            {
                Picking.Enabled = false;
                Picking.Text = "Get picking list processing...Please wait...";
                var result = await API.GET_LIST_PICKINGLIST(dateFrom, dateTo);
                if (result.Item1 == 1 && result.Item2[0].No != "NOT FOUND")
                {
                    pickingListInfo = PickingListInfo.InitialList();
                    pickingListInfo.AddRange(result.Item2);
                    adapter = new PickingListAdapter(this, pickingListInfo);
                    pickingList.Adapter = adapter;
                }
                else
                {
                    Toast.MakeText(this, $"Get Picking List error - {result.Item2[0].No}", ToastLength.Long).Show();
                    OnClearView();
                }
                Picking.Enabled = true;
                Picking.Text = "GET PICKING LIST";
            }
            else
            {
                Toast.MakeText(this, "DateFrom/DateTo value is empty. Please select first", ToastLength.Long).Show();
                OnClearView();
            }
        }
    }
}