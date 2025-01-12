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
            if (!File.Exists(Constants.DatabasePath))
            {
                InitializeDatabase();
                statusMessage = "Database created";
            }
        }

        public async void InitializeDatabase()
        {
            await connection.CreateTableAsync<User>();
            await connection.CreateTableAsync<Quiz>();
            await connection.CreateTableAsync<Question>();
            await connection.CreateTableAsync<QuizAnswer>();
            await connection.CreateTableAsync<Message>();
            await connection.CreateTableAsync<Location>();
            statusMessage = "Tables Initialized";
            GenerateData();
        }
        public async void GenerateData()
        {
            var user1 = await AddOrUpdateUser(new User { Email = "ravismeets@gmail.com", CapitalizedEmail = "RAVISMEETS@GMAIL.COM", Name = "Ravi", Password = "123", PhoneNumber = "0639833440", Username = "SpaceBaker", CapitalizedUsername = "SPACEBAKER" });
            var user2 = await AddOrUpdateUser(new User { Email = "egbertbuchem@gmail.com", CapitalizedEmail = "EGBERTBUCHEM@GMAIL.COM", Name = "Egbert", Password = "123", PhoneNumber = "0645678945", Username = "Buchem", CapitalizedUsername = "BUCHEM" });
            var user3 = await AddOrUpdateUser(new User { Email = "lisavanwersch@gmail.com", CapitalizedEmail = "LISAVANWERSCH@GMAIL.COM", Name = "Lisa", Password = "123", PhoneNumber = "0615988542", Username = "Lisa", CapitalizedUsername = "LISA" });
            var user4 = await AddOrUpdateUser(new User { Email = "joanmannens@gmail.com", CapitalizedEmail = "JOANMANNENS@GMAIL.COM", Name = "Joan", Password = "123", PhoneNumber = "0625488465", Username = "Joan", CapitalizedUsername = "JOAN" });
            await AddOrUpdateMatch(new Message { IsMatch = true, MatchId = user2.Id, DateTimeSent = new DateTime(2024, 11, 19, 9, 15, 15) });
            await AddOrUpdateMatch(new Message { IsMatch = true, MatchId = user3.Id, DateTimeSent = new DateTime(2024, 11, 19, 9, 15, 16) });
            await AddOrUpdateMatch(new Message { IsMatch = true, MatchId = user4.Id, DateTimeSent = new DateTime(2024, 11, 19, 9, 15, 17) });
            await AddOrUpdateMatch(new Message { IsMatch = false, MessageContent = "Match Edbert", MatchId = user2.Id, IsSender = true, DateTimeSent = new DateTime(2024, 11, 19, 9, 15, 18) });
            await AddOrUpdateMatch(new Message { IsMatch = false, MessageContent = "Match Lisa", MatchId = user2.Id, IsSender = true, DateTimeSent = new DateTime(2024, 11, 19, 9, 15, 19) });
            await AddOrUpdateMatch(new Message { IsMatch = false, MessageContent = "Match Joan", MatchId = user2.Id, IsSender = true, DateTimeSent = new DateTime(2024, 11, 19, 9, 15,20) });
            statusMessage = "Data Generated";
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
        public async Task<List<Message>> GetMatches(User user)
        {
            try
            {
                var matches = await connection.Table<Message>().Where(m => m.IsMatch == true).ToListAsync();
                foreach (var match in matches)
                {
                    match.Match = await GetUser(match.MatchId);
                }
                return matches;
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return null;
        }
        public async Task<List<Message>> GetMessages(User user)
        {
            try
            {
                return await connection.Table<Message>().Where(m => m.IsMatch == false).ToListAsync();
            }
            catch (Exception e)
            {
                statusMessage = $"Error: {e.Message}";
            }
            return null;
        }

    }
}
