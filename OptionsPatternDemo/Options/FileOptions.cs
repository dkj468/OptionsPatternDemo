using System.ComponentModel.DataAnnotations;

namespace API.Options
{
    public class FileOptions {
        public const string Key = "file";

        [Required(AllowEmptyStrings =false, ErrorMessage ="MaxSize cannot be empty")]
        public string MaxSize { get; set; }
        public string FileType { get; set; }
        public bool CanModify { get; set; }
        [Range(minimum:2, maximum:6)]
        public int MaxFileCount { get; set; }
        public string FileMode { get; set; } = "read"; // from env variables
        public string version { get; set; } // from command line
    }
}
