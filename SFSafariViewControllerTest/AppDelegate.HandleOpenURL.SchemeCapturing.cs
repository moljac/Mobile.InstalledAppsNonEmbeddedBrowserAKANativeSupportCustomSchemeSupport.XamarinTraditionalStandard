using Foundation;
using UIKit;

namespace SFSafariViewControllerTest
{
    public partial class AppDelegate
    {
        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			System.Diagnostics.Debug.WriteLine("OpenURL Called");

			return true;
		}

        public override bool HandleOpenURL(UIApplication application, NSUrl url)
        {
			System.Diagnostics.Debug.WriteLine("HandleOpenURL Called");

            return true;
        }
    }
}

