using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoYo.Common;

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
                ShopEntities db = new ShopEntities();

                IEnumerable<User> users = db.Users;

                foreach (var u in db.Users)
                {
                    if (u.Email == email)
                    {
                        _cache.Push(u.Email, u);
                        return u;
                    }
                }
            }

            return null;
        }

        public void PutUser(User user)
        {
            _cache.Push(user.Email, user);

            ShopEntities db = new ShopEntities();
            db.AddToUsers(user);
        }
    }
}
