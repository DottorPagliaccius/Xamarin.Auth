using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;

namespace Xamarin.Auth.XamarinForms
{
    [Preserve(AllMembers = true)]
#if XAMARIN_AUTH_INTERNAL
    internal class AuthenticatorPage : ContentPage
#else
    public class AuthenticatorPage : ContentPage
#endif

    {
        public Authenticator Authenticator { get; set; } = null;

        public AuthenticatorPage()
        {
            Title = "";

            return;
        }

        public AuthenticatorPage(Authenticator a) : this()
        {
            Authenticator = a;

            return;
        }

        bool was_shown;

#if XAMARIN_AUTH_INTERNAL
        internal void Authentication_Completed(object sender, AuthenticatorCompletedEventArgs e)
#else
        public void Authentication_Completed(object sender, AuthenticatorCompletedEventArgs e)
#endif
        {

        }

#if XAMARIN_AUTH_INTERNAL
        internal void Authentication_Error(object sender, AuthenticatorErrorEventArgs e)
#else
        public void Authentication_Error(object sender, AuthenticatorErrorEventArgs e)
#endif
        {

        }

        public void Authentication_BrowsingCompleted(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (was_shown)
            {
                Navigation.PopAsync(true);
            }
            else
            {
                was_shown = true;
            }
        }

        protected override void OnDisappearing()
        {

        }
    }
}

