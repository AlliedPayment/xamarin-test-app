using Cirrious.FluentLayouts.Touch;
using Foundation;
using System;
using UIKit;

namespace Test
{
    public partial class ViewController : UIViewController
    {
        UIWebView webView = new UIWebView();

        public ViewController(IntPtr handle) : base(handle)
        {
            this.View.AddSubview(webView);
            this.View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(
                webView.AtTopOf(View),
                webView.AtLeftOf(View),
                webView.AtRightOf(View),
                webView.AtBottomOf(View)
            );
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            string url = "https://allied-upload-test.firebaseapp.com";
            webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
            webView.LoadError += (object sender, UIWebErrorArgs e) =>
            {
                Console.WriteLine(e);
            };

        }

    }
}