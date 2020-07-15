using Auxesis_App.Model;
using Auxesis_App.UI_Interface;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auxesis_App
{
    public partial class App : Application
    {
        public static string BaseUrl = "https://test.maxcrowdfund.com/en";
        public static string csrf_token = string.Empty;
        public static string logout_token = string.Empty;
        public static string Wrongcredentialresponse = string.Empty;
        Datamanager dataManager = new Datamanager();
        public App()
        {
            InitializeComponent();
            InitializeDatabase();
            var userdata = dataManager.GetUserCokkiedata();
            if(userdata.Count>0)
                MainPage = new BalancePage();
            else
                MainPage = new Login();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public static void InitializeDatabase()
        {
            Datamanager objDatamanager = new Datamanager();
            objDatamanager.CreateUserTable();
            objDatamanager.DeleteCookieData();
        }
    }
}
