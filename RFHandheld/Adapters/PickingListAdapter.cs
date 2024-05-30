namespace RFHandheld
{
    using System.Collections.Generic;
    using Android.Content;
    using Android.Views;
    using Android.Widget;

    class PickingListAdapter : BaseAdapter<PickingListInfo>
    {
        private List<PickingListInfo> items;

        Context context;

        public PickingListAdapter(Context context, List<PickingListInfo> items)
        {
            this.context = context;
            this.items = items;
        }

        public override int Count => items.Count;

        public override long GetItemId(int position) => position;

        public override PickingListInfo this[int position] => items[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.picking_layout, null);
            }

            TextView noCol = view.FindViewById<TextView>(Resource.Id.NoCol);
            TextView pickingNoCol = view.FindViewById<TextView>(Resource.Id.PickingNoCol);
            TextView locToCol = view.FindViewById<TextView>(Resource.Id.LocToCol);
            TextView timeCol = view.FindViewById<TextView>(Resource.Id.TimeCol);
            TextView statusCol = view.FindViewById<TextView>(Resource.Id.StatusCol);
            Button btView = view.FindViewById<Button>(Resource.Id.btView);
            Button btPick = view.FindViewById<Button>(Resource.Id.btPick);

            PickingListInfo item = items[position];
            noCol.Text = item.No;
            pickingNoCol.Text = item.PickingNo;
            locToCol.Text = item.LocTo;
            timeCol.Text = item.Time;
            statusCol.Text = item.Status;

            if (position == 0)
            {
                // Apply text style for buttons
                btView.Background = null; // Set background to null (transparent)
                btView.SetTextColor(Android.Graphics.Color.Black);
                btView.SetPadding(0, 0, 0, 0);

                btPick.Background = null; // Set background to null (transparent)
                btPick.SetTextColor(Android.Graphics.Color.Black);
                btPick.SetPadding(0, 0, 0, 0);
            }
            else
            {
                btView.Click += (sender, args) =>
                {
                    // Handle button click for View
                };

                btPick.Click += (sender, args) =>
                {
                    // Handle button click for Pick
                };
            }
            return view;
        }
    }
}