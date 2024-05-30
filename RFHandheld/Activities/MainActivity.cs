namespace RFHandheld
{
    using Android.App;
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Widget;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // Start Mapping Function
            var Mapping = FindViewById<Button>(Resource.Id.btMapping);
            Mapping.Click += (sender, e) =>
            {
                StartActivity(typeof(MappingActivity));
            };

            // Start Put In Function
            var Putint = FindViewById<Button>(Resource.Id.btPutin);
            Putint.Click += (sender, e) =>
            {
                StartActivity(typeof(PutInActivity));
            };

            // Start Move Function
            var Move = FindViewById<Button>(Resource.Id.btMove);
            Move.Click += (sender, e) =>
            {
                StartActivity(typeof(MoveActivity));
            };

            // Start Change Pallet Function
            var Pallet = FindViewById<Button>(Resource.Id.btChangePallet);
            Pallet.Click += (sender, e) =>
            {
                StartActivity(typeof(ChangePalletActivity));
            };

            // Start Tracking Function
            var Tracking = FindViewById<Button>(Resource.Id.btTracking);
            Tracking.Click += (sender, e) =>
            {
                StartActivity(typeof(TrackingActivity));
            };

            // Start Picking Function
            var Picking = FindViewById<Button>(Resource.Id.btPicking);
            Picking.Click += (sender, e) =>
            {
                StartActivity(typeof(PickingActivity));
            };

            // Start Delete mapping Function
            var Delete = FindViewById<Button>(Resource.Id.btDelete);
            Delete.Click += (sender, e) =>
            {
                StartActivity(typeof(DeleteMappingActivity));
            };
        }
    }
}