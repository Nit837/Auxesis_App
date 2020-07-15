using Acr.UserDialogs;
using Auxesis_App.Model;
using Auxesis_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auxesis_App.UI_Interface
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public const string MatchEmailPattern =
           @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
    + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        WebService web;
        Loginjsondata login;
        public Login()
        {
            InitializeComponent();
            web = new WebService();
        }
        //public async void validateLogin()
        //{
        //    if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text))
        //        DisplayAlert("Alert", "Enter Email address and password", "OK");
        //    else if(!Regex.IsMatch(email.Text,MatchEmailPattern))
        //        DisplayAlert("Alert", "Invalid Emil Address", "OK","cancel");
        //    else
        //    {
        //        var response = await web.LoginUser();
        //        if (response.status == "200")
        //            await DisplayAlert("", "Login success", "OK");
        //        else
        //            await DisplayAlert("", "Login unsuccess", "OK");
        //    }
        //}

        private async void btn_login_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                UserDialogs.Instance.ShowLoading();
                if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text))
                    await DisplayAlert("Alert", "Enter Email address and password", "OK");
                else if (!Regex.IsMatch(email.Text, MatchEmailPattern))
                    await DisplayAlert("Alert", "Invalid Emil Address", "OK", "cancel");
                else
                {

                    Users users = new Users()
                    {
                        name = email.Text,
                        pass = password.Text
                    };
                    var response = await web.Login(users);
                    if (response.status == "200")
                    {
                        await DisplayAlert("", response.message, "OK");
                        UserDialogs.Instance.HideLoading();
                        login = new Loginjsondata()
                        {
                            csrf_token = response.current_user.csrf_token,
                            logout_token = response.current_user.logout_token
                        };
                        App.csrf_token = response.current_user.csrf_token;
                        App.logout_token = response.current_user.logout_token;
                        //App.logindata = new List<Loginjsondata>();
                        //App.logindata.Add(login);
                        await Navigation.PushModalAsync(new BalancePage());
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        await DisplayAlert("", App.Wrongcredentialresponse, "OK");
                    }
                }
            }
            else
                await DisplayAlert("", "Check Your Internet Connectivity", "OK");
        }
        public async void validateLogin()
        {
           
        }
    }
}