namespace YoYo.Site.Logic
{
    public interface IUserDataRepository
    {
        UserData GetUserData();

        void SaveUserData(UserData data);
    }
}
