using System;

using UIKit;

namespace SFSafariViewControllerTest
{
    public partial class ViewController : UIViewController
    {
		string url = null;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            buttonLoginCustomTabsOAuth2.TouchUpInside += ButtonLoginCustomTabsOAuth2_TouchUpInside;

            return;
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


		void ButtonLoginCustomTabsOAuth2_TouchUpInside(object sender, EventArgs e)
		{
			SetUpDataPublicNonSensitive();
			SetUpDataPrivateSensitiveSecret();

			Foundation.NSUrl nsurl = new Foundation.NSUrl(url);
			SafariServices.SFSafariViewController vc = null;
			vc = new SafariServices.SFSafariViewController(nsurl, true);
			PresentViewController(vc, true, null);

			return;
		}

		partial void SetUpDataPrivateSensitiveSecret();

		private void SetUpDataPublicNonSensitive()
		{
			url =
					/*
                    @"https://www.facebook.com/v2.8/dialog/oauth"
                    + "?" +
                    "client_id={app-id}"
                    + "&" +
                    "redirect_uri={redirect-uri}"
                    */
					@"https://www.fitbit.com/oauth2/authorize"
					+ "?" +
					"response_type=token"
					+ "&" +
					"client_id={app-id}"
					+ "&" +
					@"redirect_uri={redirect-uri}"
					+ "&" +
					"scope=activity%20nutrition%20heartrate%20location%20nutrition%20profile%20settings%20sleep%20social%20weight"
					+ "&" +
					"expires_in=604800"
					/*
					*/
					;

			return;
		}
	}
}
