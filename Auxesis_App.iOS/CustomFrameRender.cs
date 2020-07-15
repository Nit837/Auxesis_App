using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Auxesis_App.Controls;
using Auxesis_App.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRender))]
namespace Auxesis_App.iOS
{
    public class CustomFrameRender:FrameRenderer
    {
        public static void Initialize()
        {
            // empty, but used for beating the linker
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;
            UpdateShadow();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Elevation")
            {
                UpdateShadow();
            }
        }

        private void UpdateShadow()
        {
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            var materialFrame = (CustomFrame)Element;
            if (materialFrame.ShadowOpacity == 0.11f)
            {
                Layer.BorderColor = UIColor.LightGray.CGColor;
            }
            else if (materialFrame.ShadowOpacity == 0.12f)
            {
                Layer.BorderColor = UIColor.White.CGColor;
            }
            else
            {
                Layer.BorderColor = UIColor.White.CGColor;
            }
            if (materialFrame.ShadowOpacity == 0.11f)
            {
                Layer.ShadowRadius = materialFrame.Elevation;
            }
            else
            {
                Layer.ShadowRadius = (materialFrame.Elevation == 1f) ? 6 : materialFrame.Elevation;
            }
            if (materialFrame.ShadowOpacity == 0.12f)
            {
                Layer.ShadowRadius = 0;
            }

            Layer.ShadowColor = UIColor.Gray.CGColor;
            Layer.ShadowOffset = new CGSize(2, 2);
            Layer.ShadowOpacity = materialFrame.ShadowOpacity;
            Layer.ShadowPath = UIBezierPath.FromRect(Layer.Bounds).CGPath;
            Layer.MasksToBounds = false;
        }
    }
}