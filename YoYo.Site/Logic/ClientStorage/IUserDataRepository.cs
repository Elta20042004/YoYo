namespace YoYo.Site.Logic.ClientStorage
{
    public interface IUserDataRepository
    {
        UserData GetUserData();

        void SaveUserData(UserData data);
    }
}
