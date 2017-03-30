using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.CustomTabs;
using Android.Support.V7.App;
using Android.Widget;

namespace CustomTabsOAuth
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			var button = FindViewById<Button>(Resource.Id.button);
			button.Click += delegate
			{
				var client_id = Resources.GetString(Resource.String.client_id);
				var url = Resources.GetString(Resource.String.oauth_request_url, client_id);

				LaunchCustomTabs(url);
			};
		}

		private void LaunchCustomTabs(string url)
		{
			var packageName = CustomTabsHelper.GetPackageNameToUse(this);
			if (string.IsNullOrEmpty(packageName))
			{
				// in case custom tabs are not supported, use the browser

				StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse(url)));
			}
			else
			{
				// use custom tabs

				var mgr = new CustomTabsActivityManager(this);
				var builder = new CustomTabsIntent.Builder(mgr.Session);
				var customTabsIntent = builder
					.SetToolbarColor(new Color(0x34, 0x98, 0xDB))
					.SetShowTitle(true)
					.EnableUrlBarHiding()
					.Build();
				customTabsIntent.Intent.AddFlags(ActivityFlags.NoHistory);
				customTabsIntent.Intent.SetPackage(packageName);

				customTabsIntent.LaunchUrl(this, Android.Net.Uri.Parse(url));
			}
		}
	}
}
