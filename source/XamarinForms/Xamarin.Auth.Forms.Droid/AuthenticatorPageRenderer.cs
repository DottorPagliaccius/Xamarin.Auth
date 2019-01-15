using System;
using System.Collections.Generic;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;

[assembly:
    ExportRenderer
        (
            typeof(Xamarin.Auth.XamarinForms.AuthenticatorPage),
            typeof(Xamarin.Auth.XamarinForms.XamarinAndroid.AuthenticatorPageRenderer)
        )
]
namespace Xamarin.Auth.XamarinForms.XamarinAndroid
{
    [global::Android.Runtime.Preserve(AllMembers = true)]
    public class AuthenticatorPageRenderer : PageRenderer
    {
        public AuthenticatorPageRenderer(Context context) : base(context)
        {

        }

        protected Authenticator Authenticator;
        protected AuthenticatorPage authenticator_page;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = Context as Activity;

            authenticator_page = (AuthenticatorPage)Element;

            Authenticator = authenticator_page.Authenticator;
            Authenticator.Completed += Authentication_Completed;
            Authenticator.Error += Authentication_Error;

            var ui_object = Authenticator.GetUI(activity);

            activity.StartActivity(ui_object);

            return;
        }


        protected void Authentication_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            authenticator_page.Authentication_Completed(sender, e);
        }

        protected void Authentication_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            authenticator_page.Authentication_Error(sender, e);
        }

        protected void Authentication_BrowsingCompleted(object sender, EventArgs e)
        {
            authenticator_page.Authentication_BrowsingCompleted(sender, e);
        }
    }
}

