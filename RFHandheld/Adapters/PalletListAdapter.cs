namespace RFHandheld
{
    using System.Collections.Generic;
    using Android.Content;
    using Android.Views;
    using Android.Widget;

    class PalletListAdapter : BaseAdapter<PalletInfo>
    {
        private List<PalletInfo> items;

        Context context;

        public PalletListAdapter(Context context, List<PalletInfo> items)
        {
            this.context = context;
            this.items = items;
        }

        public override int Count => items.Count;

        public override long GetItemId(int position) => position;

        public override PalletInfo this[int position] => items[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.pallet_layout, null);
            }

            TextView MaterialCode = view.FindViewById<TextView>(Resource.Id.MatCol);
            TextView LotNumber = view.FindViewById<TextView>(Resource.Id.LotCol);
            TextView Quantity = view.FindViewById<TextView>(Resource.Id.QtyCol);
            TextView Box = view.FindViewById<TextView>(Resource.Id.BoxCol);

            PalletInfo item = items[position];
            MaterialCode.Text = item.MaterialCode;
            LotNumber.Text = item.LotNumber;
            Quantity.Text = item.Quantity;
            Box.Text = item.Box;

            return view;
        }
    }
}