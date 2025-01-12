using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Dating_App.MVVM.Models;

namespace Dating_App.MVVM.Models.Data
{
    public class DatingRegistry
    {
        SQLiteAsyncConnection connection;
        public string? statusMessage { get; set; }
        public DatingRegistry()
        {
            connection = new SQLiteAsyncConnection(
                Constants.DatabasePath,
                Constants.flags);
            InitializeDatabase();
            GenerateData();
        }

        public async void InitializeDatabase()
        {
            await connection.CreateTableAsync<User>();
            await connection.CreateTableAsync<Quiz>();
            await connection.CreateTableAsync<Question>();
            await connection.CreateTableAsync<QuizAnswer>();
            await connection.CreateTableAsync<Message>();
            await connection.CreateTableAsync<Location>();
        }
        public async void GenerateData()
        {
            var user1 = AddOrUpdateUser(new User { Email = "ravismeets@gmail.com", CapitalizedEmail = "RAVISMEETS@GMAIL.COM", Name = "Ravi", Password = "123", PhoneNumber = "0639833440", Username = "SpaceBaker", CapitalizedUsername = "SPACEBAKER" });
            var user2 = AddOrUpdateUser(new User { Email = "egbertbuchem@gmail.com", CapitalizedEmail = "EGBERTBUCHEM@GMAIL.COM", Name = "Egbert", Password = "123", PhoneNumber = "0645678945", Username = "Buchem", CapitalizedUsername = "BUCHEM" });
            await AddOrUpdateMatch(new Message { MessageContent = "Hello", SenderId = user1.Id, ReceiverId = user2.Id });
        }

        public async Task<User> AddOrUpdateUser(User newUser)
        {
            int result = 0;
            try
            {
                if (newUser.Id != 0)
                {
                    result = await connection.UpdateAsync(newUser);
                    statusMessage = $"{result} row(s) updated :)";
                    return newUser;
                }
                else
                {
                    result = await connection.InsertAsync(newUser);
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
                return await connection.Table<User>().ToListAsync();
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
                return await connection.Table<User>().FirstOrDefaultAsync(t => t.Id == id);
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
                return await connection.Table<User>().FirstOrDefaultAsync(u => u.CapitalizedUsername == userNameOrEmail.ToUpper() || u.CapitalizedEmail == userNameOrEmail.ToUpper());
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
                await connection.DeleteAsync(User);
                return true;
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return false;
        }
        public async Task<Message> AddOrUpdateMatch(Message newMessage)
        {
            int result = 0;
            try
            {
                if (newMessage.Id != 0)
                {
                    result = await connection.UpdateAsync(newMessage);
                    statusMessage = $"{result} row(s) updated :)";
                    return newMessage;
                }
                else
                {
                    result = await connection.InsertAsync(newMessage);
                    statusMessage = $"{result} row(s) added :)";
                    return newMessage;
                }
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
                return null;
            }
        }
        
    }
}
