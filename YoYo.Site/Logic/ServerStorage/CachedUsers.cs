using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoYo.Common;
using YoYo.Common.Entities;

namespace YoYo.Site.Logic.ServerStorage
{
    class CachedUsers : IUserRepository
    {
        private readonly Lru<string, User> _cache;
        private const int CacheLength = 1000;

        public static IUserRepository Instance = new CachedUsers();

        protected CachedUsers()
        {
            _cache = new Lru<string, User>(CacheLength);
        }

        public User GetUser(string email)
        {
            var user = _cache.Get(email);
            if (user == null)
            {              
                var dbShop = new ShopEntities();
                user = dbShop.User.First(u=>u.Email == email);
                _cache.Push(user.Email, user);
            }

            return user;
        }

        public void PutUser(User user)
        {
            _cache.Push(user.Email, user);

            ShopEntities db = new ShopEntities();

            db.User.Add(user);
        }
    }
}
