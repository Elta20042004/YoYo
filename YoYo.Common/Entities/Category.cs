namespace YoYo.Common.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int ParentID { get; set; }
        public string NavigateUrl { get; set; }
    }
}