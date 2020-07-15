using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Auxesis_App.Controls;
using AApplication = Android.App.Application;
using Auxesis_App.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Support.V4.Content;
using System.ComponentModel;
using Android.Text;
using Android.Text.Style;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(BetterEntry), typeof(BetterEntryRender))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace Auxesis_App.Droid
{
    [Obsolete]
    public class BetterEntryRender:EntryRenderer
    {
        private BetterEntry CustomElement => Element as BetterEntry;
        public BetterEntryRender(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // UpdatePlaceholderFont();
                Control.SetBackground(ContextCompat.GetDrawable(Context, Android.Resource.Color.Transparent));
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //if (e.PropertyName == CustomEntry.PlaceholderFontFamilyProperty.PropertyName)
            //    UpdatePlaceholderFont();
        }

        private void UpdatePlaceholderFont()
        {
            if (CustomElement.PlaceholderFontFamily == default(string))
            {
                Control.HintFormatted = null;
                Control.Hint = CustomElement.Placeholder;
                Control.SetHintTextColor(CustomElement.PlaceholderColor.ToAndroid());
                return;
            }

            var placeholderFontSize = (int)CustomElement.FontSize;
            var placeholderSpan = new SpannableString(CustomElement.Placeholder);
            placeholderSpan.SetSpan(new AbsoluteSizeSpan(placeholderFontSize, true), 0, placeholderSpan.Length(), SpanTypes.InclusiveExclusive); // Set Fontsize

            var typeFace = FindFont(CustomElement.PlaceholderFontFamily);
            //var typeFaceSpan = new CustomTypefaceSpan(typeFace);
            //placeholderSpan.SetSpan(typeFaceSpan, 0, placeholderSpan.Length(), SpanTypes.InclusiveExclusive); //Set Fontface

            Control.HintFormatted = placeholderSpan;
        }

        const string LoadFromAssetsRegex = @"\w+\.((ttf)|(otf))\#\w*";
        private Typeface FindFont(string fontFamily)
        {
            if (!string.IsNullOrWhiteSpace(fontFamily))
            {
                if (Regex.IsMatch(fontFamily, LoadFromAssetsRegex))
                {
                    var typeface = Typeface.CreateFromAsset(AApplication.Context.Assets, FontNameToFontFile(fontFamily));
                    return typeface;
                }
                else
                {
                    return Typeface.Create(fontFamily, TypefaceStyle.Normal);
                }
            }

            return Typeface.Create(Typeface.Default, TypefaceStyle.Normal);
        }

        private string FontNameToFontFile(string fontFamily)
        {
            int hashtagIndex = fontFamily.IndexOf('#');
            if (hashtagIndex >= 0)
                return fontFamily.Substring(0, hashtagIndex);

            throw new InvalidOperationException($"Can't parse the {nameof(fontFamily)} {fontFamily}");
        }
    }
}