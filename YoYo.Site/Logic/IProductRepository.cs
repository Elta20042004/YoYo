namespace YoYo.Site.Logic
{
    public interface IProductRepository
    {
        CookieData GetCookieData();

        void PutCookieData(CookieData data);
    }
}
