using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
    public class UserRepository
    {
        IDbConnection _db;
        // SaltRevision SALT = SaltRevision.Revision2X;

        //REGISTER C
        public User Register(UserRegistration creds)
        {
            //generate the user id
            //HASH THE PASSWORD
            string id = Guid.NewGuid().ToString();
            string hash = BCrypt.Net.BCrypt.HashPassword(creds.Password); //IF SALT, ENTER (, 'SALT') AS 2D PARAM
            int success = _db.Execute(@"
            INSERT INTO users(id, username, email, hash)
            VALUES (@id, @username, @email, @hash);
            ", new
            {
                id,
                username = creds.UserName,
                email = creds.Email,
                hash
            });
            if (success != 1)
            {
                return null;
            }
            return new User()
            {
                UserName = creds.UserName,
                Email = creds.Email,
                Hash = null,
                Id = id
            };
        }
        //LOGIN R
        public User Login(UserLogin creds)
        {
            //GET USER FROM DB
            User user = _db.Query<User>(@"
            SELECT * FROM users WHERE email = @Email
            ", creds).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            //HASH THE PASSWORD
            bool validPass = BCrypt.Net.BCrypt.Verify(creds.Password, user.Hash);
            if (!validPass)
            {
                return null;
            }
            user.Hash = null;
            return user;
        }

        internal User GetUserById(string id)
        {
            var user = _db.Query<User>(@"
            SELECT * FROM users WHERE id = @id
            ", new { id }).FirstOrDefault();
            if(user != null)
            {
                user.Hash = null;
                return user;
            }
        }

        //UPDATE U
        //CHANGE PASSWORD U
        //DELETE D

        public UserRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}