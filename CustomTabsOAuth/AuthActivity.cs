using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace CustomTabsOAuth
{
	[IntentFilter(
		actions: new[] { Intent.ActionView },
		Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
		DataScheme = "@string/callback_scheme",
		DataHost = "@string/callback_host")]
	[Activity(Label = "@string/app_name")]
	public class AuthActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Auth);

			var message = FindViewById<TextView>(Resource.Id.message);

			var uri = Intent.Data;
			var code = uri?.GetQueryParameter("code");
			if (string.IsNullOrEmpty(code))
			{
				message.Text = "Error reason: " + uri?.GetQueryParameter("error");
			}
			else
			{
				message.Text = "Success code: " + code;
			}
		}
	}
}




