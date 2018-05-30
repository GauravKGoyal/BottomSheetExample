using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace BottomSheetExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            var button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;
            var button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += Button_Click2;

            Button_Click(null, null);
        }

        private void Button_Click2(object sender, EventArgs e)
        {
            FrameLayout bottomSheet = (FrameLayout)FindViewById(Resource.Id.bottom_sheet);

            BottomSheetBehavior behavior = BottomSheetBehavior.From(bottomSheet);
            behavior.PeekHeight = 300;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var codingSearchDrawerDialog = new CodingSearchDrawerDialog();
            codingSearchDrawerDialog.Show(SupportFragmentManager, codingSearchDrawerDialog.Tag);

            //Button_Click2(null, null);
        }
    }

    public class CodingSearchDrawerDialog : BottomSheetDialogFragment
    {
        public CodingSearchDrawerDialog()
        {
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
        }
        public override void OnHiddenChanged(bool hidden)
        {
            //if (hidden == true)
            base.OnHiddenChanged(hidden);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.coding_search_drawing_dialog, container, false);

            var recyclerView = view.FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.coding_search_drawing_dialog_recyclerView);
            var layoutManager = new LinearLayoutManager(view.Context);
            recyclerView.SetLayoutManager(layoutManager);
            var dataAdapter = new CodingSearchRecyclerViewAdapter();
            recyclerView.SetAdapter(dataAdapter);
            return view;
        }
    }

    public class CodingSearchRecyclerViewAdapter : RecyclerView.Adapter
    {
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is FavouriteItemHolder vh))
            {
                return;
            }

            vh.TextView.Text = "test data";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View favouriteItemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.favourite_item, parent, false);

            return new FavouriteItemHolder(favouriteItemView);
        }

        public override int ItemCount => 10;
    }

    public class FavouriteItemHolder : RecyclerView.ViewHolder
    {
        public TextView TextView { get; private set; }

        public FavouriteItemHolder(View favouriteItemView) : base(favouriteItemView)
        {
            TextView = favouriteItemView.FindViewById<TextView>(Resource.Id.favorite_item_textview);
        }
    }
}