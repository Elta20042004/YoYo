using System;
using System.Collections.Generic;
namespace WebApplication4.Logic
{
    public interface IProductRepository
    {
        CookieData GetCookieData();
        void PutCookieData(CookieData data);
    }
}
