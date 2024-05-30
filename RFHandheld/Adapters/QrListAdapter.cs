namespace RFHandheld
{
    using System.Collections.Generic;
    using Android.Content;
    using Android.Views;
    using Android.Widget;

    class QrListAdapter : BaseAdapter<QR_INFORMATION>
    {
        private List<QR_INFORMATION> items;

        Context context;

        public QrListAdapter(Context context, List<QR_INFORMATION> items)
        {
            this.context = context;
            this.items = items;
        }

        public override int Count => items.Count;

        public override long GetItemId(int position) => position;

        public override QR_INFORMATION this[int position] => items[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.qr_layout, null);
            }

            TextView MaterialCode = view.FindViewById<TextView>(Resource.Id.MatCol);
            TextView Description = view.FindViewById<TextView>(Resource.Id.DescCol);
            TextView LotNumber = view.FindViewById<TextView>(Resource.Id.LotCol);
            TextView Quantity = view.FindViewById<TextView>(Resource.Id.QtyCol);
            TextView Box = view.FindViewById<TextView>(Resource.Id.BoxCol);

            QR_INFORMATION item = items[position];
            MaterialCode.Text = item.MaterialCode;
            Description.Text = item.Description;
            LotNumber.Text = item.LotNumber;
            Quantity.Text = item.Quantity;
            Box.Text = item.Box;

            return view;
        }
    }
}