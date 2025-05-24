using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toast.Services;
using UIKit;

namespace Toast.Platforms.iOS.Services
{
    public class ToastServiceiOS : IToastService
    {
        public void LongAlert(string message)
        {
            ShowAlert(message, 2);
        }
        public void ShortAlert(string message)
        {
            ShowAlert(message, 2);
        }

        //void ShowAlert(string message, double seconds)
        //{
        //    try
        //    {
        //        UserDialogs.Instance.Toast(message, TimeSpan.FromSeconds(seconds));
        //        //alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
        //        //    {
        //        //        dismissMessage();
        //        //    });
        //        //alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
        //        //UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandling.WriteExceptionData(ex.ToString());
        //    }
        //}

        void ShowAlert(string message, double seconds)
        {
            try
            {
                var backgroundView = new UIView(UIScreen.MainScreen.Bounds)
                {
                    BackgroundColor = UIColor.White.ColorWithAlpha(0.8f), // White background with 50% opacity
                    Alpha = 0.8f // Optional: Set the alpha for the entire view
                };
                var toast = new UILabel(new CoreGraphics.CGRect(0, 0, 300, 50))
                {
                    Text = message,
                    BackgroundColor = UIColor.FromRGB(81, 81, 91), // Set background color to #51515B
                    TextColor = UIColor.White,
                    TextAlignment = UITextAlignment.Center,
                    Lines = 0,
                    Font = UIFont.BoldSystemFontOfSize(17), // Set font to bold with a size of 17
                    AdjustsFontSizeToFitWidth = true,
                    Center = UIApplication.SharedApplication.KeyWindow.Center // Center it on the screen
                };
                // Set rounded corners
                toast.Layer.CornerRadius = 10; // Adjust the radius as needed
                toast.Layer.MasksToBounds = true; // Ensure the corners are clipped
                //Shadow
                toast.Layer.ShadowColor = UIColor.Black.CGColor;
                toast.Layer.ShadowOpacity = 0.5f;
                toast.Layer.ShadowRadius = 5;
                toast.Layer.ShadowOffset = new CoreGraphics.CGSize(0, 2);
                var window = UIApplication.SharedApplication.KeyWindow;
                window.AddSubview(backgroundView);
                window.AddSubview(toast);
                UIView.Animate(seconds, 0.0, UIViewAnimationOptions.CurveEaseInOut, () =>
                {
                    backgroundView.Alpha = 0;
                }, () =>
                {
                    backgroundView.RemoveFromSuperview();
                });
                UIView.Animate(seconds, 0.0, UIViewAnimationOptions.CurveEaseInOut, () =>
                {
                    toast.Alpha = 0;
                }, () =>
                {
                    toast.RemoveFromSuperview();
                });

                // Show for a specific duration
                toast.Alpha = 1;
                backgroundView.Alpha = 1;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
