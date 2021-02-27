namespace Address_Book_API.Domain.Models
{
    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string DataBaseName { get; set; }
    }
}
