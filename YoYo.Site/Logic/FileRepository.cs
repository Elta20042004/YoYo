using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication4.Logic
{
    public class FileRepository : IProductRepository
    {
        public List<int> GetProducts()
        {
            if (!File.Exists(@"ser.xml"))
            {
                return new List<int>();
            }

            List<int> result ;
            using (var str = File.OpenRead(@"ser.xml"))
            {
                XmlSerializer x = new XmlSerializer((new List<int>()).GetType());
                result = x.Deserialize(str) as List<int>;
            }
            return result;
        }

        public void PutProducts(List<int> products)
        {
            List<int> result;
            using (var str = File.Create(@"ser.xml"))
            {
                XmlSerializer x = new XmlSerializer((new List<int>()).GetType());
                x.Serialize(str, products);
            }
        }
    }
}