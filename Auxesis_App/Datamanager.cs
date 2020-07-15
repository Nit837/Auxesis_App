using Auxesis_App.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Auxesis_App
{
    public class BaseTable
    {
        protected static SQLiteAsyncConnection db = null;
        protected static SQLiteConnection database = null;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "UserCokkieData.db3");
        public BaseTable()
        {
            if (db == null)
            {
                db = new SQLiteAsyncConnection(dbPath);
                database = new SQLiteConnection(dbPath);
            }
        }
    }
    public class Datamanager:BaseTable
    {
        public void CreateUserTable()
        {
            try
            {
                db.CreateTableAsync<LoginCookieData>().Wait();
            }
            catch (Exception ex)
            {
                //exception handling code to go here
                throw;
            }
        }
        public Task<int> SaveUserDetailAsync(LoginCookieData userDetail)
        {
            return db.InsertAsync(userDetail);
        }
        public List<LoginCookieData> GetUserCokkiedata()
        {
            try
            {
                var result = database.Table<LoginCookieData>().ToList();

                return result;
            }
            catch (Exception ex)
            {
                //exception handling code to go here
                throw;
            }
        }
        public void DeleteCookieData()
        {
            try
            {
                var result = database.Table<LoginCookieData>().ToList();
                if(result.Count>0)
                {
                   database.Delete(result);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
