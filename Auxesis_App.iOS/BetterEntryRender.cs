using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auxesis_App.Controls;
using Auxesis_App.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BetterEntry), typeof(BetterEntryRender))]
namespace Auxesis_App.iOS
{
    class BetterEntryRender:EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
                if (Element != null)
                {
                    Element.HeightRequest = 35;
                    Element.Margin = new Thickness(5, 0, 5, 0);
                }

                UITextField textField = (UITextField)Control;
                textField.Font = UIFont.FromName("AvenirLTStd Roman", 13);
            }
        }
    }
}