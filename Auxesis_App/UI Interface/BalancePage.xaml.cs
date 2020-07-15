using Acr.UserDialogs;
using Auxesis_App.Model;
using Auxesis_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auxesis_App.UI_Interface
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BalancePage : ContentPage
    {
        WebService web;
 
        public BalancePage()
        {
            InitializeComponent();
            web = new WebService();
            getbalance();
            //getloginstatus();
        }
        public async void getloginstatus()
        {
            var response = await web.LoginStatus();
            if(response==1)
                await DisplayAlert("", "aaaiioohh", "OK");
            else
                await DisplayAlert("", "hjyuu", "OK");
        }
        public async void getbalance()
        {
            UserDialogs.Instance.ShowLoading();
            var response = await web.GetUserAccountBalance();
            if (response.user_login_status == 1)
            {
                UserDialogs.Instance.HideLoading();
                //await DisplayAlert("", "aaaiioohh", "OK");
            }
            else
            {
                UserDialogs.Instance.HideLoading();
               // await DisplayAlert("", "hhhhhh", "OK");
            }
        }
        private async void btn_logout_Clicked(object sender, EventArgs e)
        {
            var response = await web.Logout(App.logout_token);
            if (response == true)
                await Navigation.PopModalAsync(true);
            else
                await DisplayAlert("Error", "Something Went Wrong Please try again.", "OK");
        }
    }
}