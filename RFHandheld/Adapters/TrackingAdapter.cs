namespace RFHandheld
{
    using System.Collections.Generic;
    using Android.Content;
    using Android.Views;
    using Android.Widget;

    class TrackingAdapter : BaseAdapter<TrackingInfo>
    {
        private List<TrackingInfo> items;

        Context context;

        public TrackingAdapter(Context context, List<TrackingInfo> items)
        {
            this.context = context;
            this.items = items;
        }

        public override int Count => items.Count;

        public override long GetItemId(int position) => position;

        public override TrackingInfo this[int position] => items[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.tracking_layout, null);
            }

            TextView Location = view.FindViewById<TextView>(Resource.Id.LocCol);
            TextView EPC = view.FindViewById<TextView>(Resource.Id.EpcCol);
            TextView MaterialCode = view.FindViewById<TextView>(Resource.Id.MatCol);
            TextView LotNumber = view.FindViewById<TextView>(Resource.Id.LotCol);
            TextView Quantity = view.FindViewById<TextView>(Resource.Id.QtyCol);
            TextView Box = view.FindViewById<TextView>(Resource.Id.BoxCol);

            TrackingInfo item = items[position];
            Location.Text = item.Location;
            EPC.Text = item.EPC;
            MaterialCode.Text = item.MaterialCode;
            LotNumber.Text = item.LotNumber;
            Quantity.Text = item.Quantity;
            Box.Text = item.Box;

            return view;
        }
    }
}