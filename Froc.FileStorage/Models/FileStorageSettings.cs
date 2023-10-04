namespace Forc.FileStorage.Models
{
    public class FileStorageSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public DbCollections Collections { get; set; }
    }
}
