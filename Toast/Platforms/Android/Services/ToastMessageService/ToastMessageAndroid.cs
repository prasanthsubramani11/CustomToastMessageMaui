using Android.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toast.Platforms.Services.ToastMessageService;
using Toast.Services;
[assembly: Dependency(typeof(ToastMessageAndroid))]

namespace Toast.Platforms.Services.ToastMessageService
{
    public class ToastMessageAndroid
    {
        public class ToastServiceAndroid : IToastService
        {
            public async void LongAlert(string message)
            {
                await ShowMessage(message, 3.5); // Typical long toast duration
            }

            public async void ShortAlert(string message)
            {
                await ShowMessage(message, 2); // Typical short toast duration
            }
            public async Task ShowMessage(string message, double duration)
            {
                var activity = Platform.CurrentActivity; // Requires: using Microsoft.Maui.ApplicationModel;

                // Create a new Dialog
                var dialog = new Dialog(activity);
                dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
                dialog.SetCancelable(true);

                // Inflate the custom toast layout
                var layout = activity.LayoutInflater.Inflate(Resource.Layout.custom_message_layout, null);

                // Find the TextView and set the message
                var toastMessageTextView = layout.FindViewById<TextView>(Resource.Id.toastMessage);
                toastMessageTextView.Text = message;

                // Set the custom layout to the dialog
                dialog.SetContentView(layout);
                dialog.SetCanceledOnTouchOutside(false);
                dialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.Transparent);

                // Center the layout on screen
                var window = dialog.Window;
                if (window != null)
                {
                    window.SetLayout(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                    window.SetGravity(GravityFlags.Center);
                }

                // Show the dialog
                dialog.Show();

                // Wait for the specified duration
                await Task.Delay((int)(duration * 1000));

                // Dismiss the dialog after the duration
                dialog.Dismiss();
            }

        }
    }
}
