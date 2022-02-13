namespace SafeDevelopLesson_6_1.Data
{
    public class BookContext
    {
        public string ConnectionString{get;set;}
        public string DataBase { get; set; }
        public string Collection { get; set; }
        public BookContext()
        {
        ConnectionString = "mongodb://localhost:27017";
        DataBase = "Bookdb";
        Collection = "Books";
        }
    }
}
