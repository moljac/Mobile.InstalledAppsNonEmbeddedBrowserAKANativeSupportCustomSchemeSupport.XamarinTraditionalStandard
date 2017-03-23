using System;

using UIKit;

namespace SFSafariViewControllerTest
{
    public partial class ViewController 
    {
		partial void SetUpDataPrivateSensitiveSecret()
		{
			url = url.Replace
						(
							"{app-id}",
							//"385560981836828"             // Facebook redirect_url http[s]://*.xamarin.com
							//"259129081208614"             // Facebook redirect_url http[s]://localhost 
							//"606794869530176"             // Facebook redirect_url http[s]://127.0.0.1 
							"228CVW"                        // fitbit   redirect url xamarin-auth://localhost
						);
			url = url.Replace
						(
							"{redirect-uri}",
							//"https://www.xamarin.com"    // Facebook redirect_url http[s]://*.xamarin.com
							//"http://localhost"            // Facebook redirect_url http[s]://localhost 
							//"http://127.0.0.1"            // Facebook redirect_url http[s]://127.0.0.1 
							"xamarin-auth://localhost"      // fitbit   redirect url xamarin-auth://localhost
						);

			return;
		}

	}
}
