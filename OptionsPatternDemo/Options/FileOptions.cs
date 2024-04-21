using System.ComponentModel.DataAnnotations;

namespace API.Options
{
    public class FileOptions {
        public const string Key = "file";
        
        public string MaxSize { get; set; }
        public string FileType { get; set; }
        public bool CanModify { get; set; }
        public int MaxFileCount { get; set; }
    }
}
