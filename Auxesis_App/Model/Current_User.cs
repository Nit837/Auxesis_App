using System;
using System.Collections.Generic;
using System.Text;

namespace Auxesis_App.Model
{
    public class CurrentUser
    {
        public string uid { get; set; }
        public string name { get; set; }
        public string csrf_token { get; set; }
        public string logout_token { get; set; }
        public int show_quick_access_screen { get; set; }

    }

    public class LoginResponse
    {
        public string message { get; set; }
        public string status { get; set; }
        public CurrentUser current_user { get; set; }

    }
}
