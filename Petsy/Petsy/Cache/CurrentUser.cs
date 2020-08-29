using AutoMapper;
using Petsy.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Cache
{
    public class CurrentUser : ICache<User>
    {
        private User User = new User();

        //Singelton start:
        private static readonly CurrentUser instance = new CurrentUser();
        private CurrentUser()
        {
        }
        public static CurrentUser GetInstance()
        {
            return instance;
        }
        //Singelton end
        public User Get()
        {
            return this.User;
        }

        public void Update(User cache)
        {
            this.User = cache;
        }
    }
}
