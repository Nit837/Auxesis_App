using System;
using System.Collections.Generic;
using System.Text;

namespace Auxesis_App.Model
{
    public  class Loginjsondata
    {
        public  string csrf_token { get; set; }
        public  string logout_token { get; set; }
    }
    public class LoginCookieData
    {
        public string cookieName { get; set; }
        public string cookieValue { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Secure { get; set; }
        public string Port { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public bool HttpOnly { get; set; }
        public DateTime Expires { get; set; }
        public string Domain { get; set; }
        public string Value { get; set; }
        public bool Discard { get; set; }
        public Uri CommentUri { get; set; }
        public string Comment { get; set; }
        public bool Expired { get; set; }
        public int Version { get; set; }
    }
}
