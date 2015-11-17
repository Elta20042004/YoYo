using YoYo.Common.Entities;

namespace YoYo.Site.Logic.ServerStorage
{
    interface IUserRepository
    {
        User GetUser(string email);

        void PutUser(User user);
    }
}