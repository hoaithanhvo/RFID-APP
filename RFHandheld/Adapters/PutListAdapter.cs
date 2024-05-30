namespace RFHandheld
{
    using System.Collections.Generic;
    using Android.Content;
    using Android.Views;
    using Android.Widget;

    class PutListAdapter : BaseAdapter<RfidInfo>
    {
        private List<RfidInfo> items;

        Context context;

        public PutListAdapter(Context context, List<RfidInfo> items)
        {
            this.context = context;
            this.items = items;
        }

        public override int Count => items.Count;

        public override long GetItemId(int position) => position;

        public override RfidInfo this[int position] => items[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.put_layout, null);
            }

            TextView Location = view.FindViewById<TextView>(Resource.Id.LocCol);
            TextView MaterialCode = view.FindViewById<TextView>(Resource.Id.MatCol);
            TextView LotNumber = view.FindViewById<TextView>(Resource.Id.LotCol);
            TextView Quantity = view.FindViewById<TextView>(Resource.Id.QtyCol);
            TextView Box = view.FindViewById<TextView>(Resource.Id.BoxCol);

            RfidInfo item = items[position];
            Location.Text = item.Location;
            MaterialCode.Text = item.MaterialCode;
            LotNumber.Text = item.LotNumber;
            Quantity.Text = item.Quantity;
            Box.Text = item.Box;

            return view;
        }
    }
}