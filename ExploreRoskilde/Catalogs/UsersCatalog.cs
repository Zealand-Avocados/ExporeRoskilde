using System;
using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using System.Linq;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Identity;

namespace ExploreRoskilde.Catalogs
{
   
    public class UsersCatalog : IUsersCatalog
    {
        public Dictionary<string, User> AllUsers() => Database.Database.ReadJsonUsers();

        public User GetUserById(string id)
        {
            return AllUsers()[id];
        }
        
        public User GetUserByUsername(string username)
        {
            return AllUsers().FirstOrDefault(i => i.Value.Username == username).Value;
        }

        public bool Register(User user)
        {
            Dictionary<string, User> users = AllUsers();

            var emailCheck = users.FirstOrDefault(u => u.Value.Email == user.Email);
            if (emailCheck.Value != null)
                return false;

            PasswordHasher<string> pw = new PasswordHasher<string>();
            string passwordHashed = pw.HashPassword(user.Email, user.Password);
            user.Password = passwordHashed;
            users.Add(user.Id, user);
            Database.Database.WriteToJsonUsers(users);
            return true;
        }
        
        public User Login(string email , string password)
        {
            User loggedIn = null;
            foreach (var (_, value) in AllUsers())
            {
                if (value.Email != email) continue;
                string jsonPassword = value.Password; 
                PasswordHasher<string> pw = new PasswordHasher<string>();
                var verificationResult = pw.VerifyHashedPassword(email, jsonPassword, password);
                loggedIn = verificationResult == PasswordVerificationResult.Success ? value : null;
                return loggedIn;
            }
            return null;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
