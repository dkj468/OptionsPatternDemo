using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FileOptions = API.Options.FileOptions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase {
        private readonly IConfiguration _config;
        private  FileOptions _fileOptions;
        //private readonly IOptionsMonitor<FileOptions> _optionsMonitor;

        public FileController(IConfiguration config, IOptions<FileOptions> fileOptions) {
            _config = config;
            _fileOptions = fileOptions.Value;
        }

        //public FileController(IConfiguration config, IOptionsMonitor<FileOptions> optionsMonitor)
        //{
        //    _config = config;
        //    _optionsMonitor = optionsMonitor;
        //    _fileOptions = _optionsMonitor.CurrentValue;

        //    _optionsMonitor.OnChange(options =>
        //    {
        //        _fileOptions = options;
        //    });

        //}

        [HttpGet("config/iconfiguration")]
        public IActionResult GetFileConfig_IConfiguration() {
            var fileSize = _config.GetValue<string>("file:maxSize");
            var fileType = _config.GetValue<string>("file:fileType");
            var canModify = _config.GetValue<bool>("file:canModify");
            var maxFileCount = _config.GetValue<int>("file:maxFileCount");

            //_config.
             
            return Ok(new { fileSize = fileSize, fileType = fileType, canModify = canModify, maxFileCount = maxFileCount });
        }

        // get config data using Options Pattern
        [HttpGet("config/option")]
        public IActionResult GetFileConfig_IOptions() {
            var fileSize = _fileOptions.MaxSize;
            var fileType = _fileOptions.FileType;
            var canModify = _fileOptions.CanModify;
            var maxFileCount = _fileOptions.MaxFileCount;
            var filemode = _fileOptions.FileMode;
            var version = _fileOptions.version;

            return Ok(
                    new
                    {
                        fileSize,
                        fileType,
                        canModify,
                        maxFileCount,
                        filemode,
                        version
                    }
            );
        }
    }
}
