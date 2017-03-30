using Foundation;
using UIKit;

namespace SFSafariViewControllerTest
{
    public partial class AppDelegate
    {
        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.AppendLine("OpenURL Called");
            sb.Append("     url         = ").AppendLine(url.AbsoluteUrl.ToString());
			sb.Append("     application = ").AppendLine(sourceApplication);
			sb.Append("     annottion   = ").AppendLine(annotation.ToString());
			System.Diagnostics.Debug.WriteLine(sb.ToString());

			return true;
		}

        public override bool HandleOpenURL(UIApplication application, NSUrl url)
        {
			System.Diagnostics.Debug.WriteLine("HandleOpenURL Called");

            return true;
        }
    }
}

