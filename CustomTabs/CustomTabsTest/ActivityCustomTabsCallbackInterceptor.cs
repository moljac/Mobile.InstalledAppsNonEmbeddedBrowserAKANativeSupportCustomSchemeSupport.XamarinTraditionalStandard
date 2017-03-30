
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CustomTabsTest
{
    /// <summary>
    /// Activity custom tabs callback interceptor.
    /// https://developer.chrome.com/multidevice/android/customtabs
    /// </summary>
	[
        Activity
        (
            Label = "ActivityCustomTabsCallbackInterceptor"
        )
    ]
	[
		IntentFilter
		(
			actions: new[] { Intent.ActionView},
            Categories = new[]
                {
                    Intent.CategoryDefault,
                    Intent.CategoryBrowsable
                },
            DataScheme = "xamarin-auth",
            DataHost = "localhost"
        /*
        DataSchemes = new[] 
        { 
            //"http", "https" 
            "xamarin-auth"
        },
        DataHosts = new[] 
        { 
            //"*.xamarin.com", "xamarin.com", 
            "localhost", 
            //"127.0.0.1" 
        },
        */
        //DataMimeType = "text/plain"
        )
    ]
    public class ActivityCustomTabsCallbackInterceptor 
            :
            Activity // NOGO???
            //Android.Support.V7.App.AppCompatActivity
    {
        String message = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			Android.Net.Uri uri = Intent.Data;
			string code = uri?.GetQueryParameter("code");
            string error = uri?.GetQueryParameter("error");

			if (string.IsNullOrEmpty(code))
			{
				message = "Error reason: " + uri?.GetQueryParameter("error");
			}
			else
			{
				message = "Success code: " + code;
			}

            string intent_extra_text = Intent.GetStringExtra(Intent.ExtraText);
			// Create your application here
			if (!String.IsNullOrEmpty(intent_extra_text))
            {
                message = intent_extra_text;
            }

            return;
        }

        protected override void OnNewIntent(Intent intent)
        {
            return;
        }
    }
}
