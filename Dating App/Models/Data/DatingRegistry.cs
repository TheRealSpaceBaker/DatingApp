using SQLite;
using Dating_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Dating_App.Models.Data
{
    public class DatingRegistry
    {
        SQLiteConnection connection;
        public string? statusMessage { get; set; }
        public DatingRegistry()
        {
            connection = new SQLiteConnection(
                Constants.DatabasePath,
                Constants.flags);
            connection.CreateTable<Thing>();
            connection.CreateTable<User>();
            connection.CreateTable<Quiz>();
            connection.CreateTable<Question>();
            connection.CreateTable<QuizAnswer>();
            connection.CreateTable<Message>();
            connection.CreateTable<Location>();
            this.AddOrUpdateUser(new User { Email="ravismeets@gmail.com", Name= "Ravi", Password = "ravi1809", PhoneNumber = 0639833440, Username = "SpaceBaker" });
        }

        public async Task<User> AddOrUpdateUser(User newUser)
        {
            int result = 0;
            try
            {
                if (newUser.Id != 0)
                {
                    result = connection.Update(newUser);
                    statusMessage = $"{result} row(s) updated :)";
                    return newUser;
                }
                else
                {
                    result = connection.Insert(newUser);
                    statusMessage = $"{result} row(s) added :)";
                    return newUser;
                }
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
                return null;
            }
        }
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return connection.Table<User>().ToList();
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return null;
        }
        public async Task<User> GetUser(int id)
        {
            try
            {
                return connection.Table<User>().FirstOrDefault(t => t.Id == id);
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return null;
        }
        public async Task<User> GetUser(string userNameOrEmail)
        {
            try
            {
                return connection.Table<User>().FirstOrDefault(u => u.Username == userNameOrEmail || u.Email == userNameOrEmail);
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return null;
        }
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                User User = await GetUser(id);
                connection.Delete(User);
                return true;
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return false;
        }
        /*
        public async Task<Thing> AddOrUpdate(Thing newThing)
        {
            int result = 0;
            try
            {
                if (newThing.Id != 0)
                {
                    result = connection.Update(newThing);
                    statusMessage = $"{result} row(s) updated :)";
                    return newThing;
                }
                else
                {
                    result = connection.Insert(newThing);
                    statusMessage = $"{result} row(s) added :)";
                    return newThing;
                }
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
                return null;
            }
        }
        public async Task<List<Thing>> GetAll()
        {
            try
            {
                return connection.Table<Thing>().ToList();
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return null;
        }
        public async Task<Thing> GetById(int id)
        {
            try
            {
                return connection.Table<Thing>().FirstOrDefault(t => t.Id == id);
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return null;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Thing thing = await GetById(id);
                connection.Delete(thing);
                return true;
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return false;
        }
        */
    }
}
