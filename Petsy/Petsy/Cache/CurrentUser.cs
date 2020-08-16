using AutoMapper;
using Petsy.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Cache
{
    public class CurrentUser : ICache<User_x>
    {
        private User_x User = new User_x();

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

        public User_x Get()
        {
            return this.User;
        }

        public void Update(User_x cache)
        {
            this.User = cache;
        }
    }
}
