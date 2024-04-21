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
        private readonly FileOptions _fileOptions;

        public FileController(IConfiguration config, IOptions<FileOptions> fileOptions) {
            _config = config;
            _fileOptions = fileOptions.Value;
        }
        [HttpGet("config/iconfiguration")]
        public IActionResult GetFileConfig_IConfiguration() {
            var fileSize = _config.GetValue<string>("file:maxSize");
            var fileType = _config.GetValue<string>("file:fileType");
            var canModify = _config.GetValue<bool>("file:canModify");
            var maxFileCount = _config.GetValue<int>("file:maxFileCount");
             
            return Ok(new { fileSize = fileSize, fileType = fileType, canModify = canModify, maxFileCount = maxFileCount });
        }

        // get config data using Options Pattern
        [HttpGet("config/option")]
        public IActionResult GetFileConfig_IOptions() {
            var fileSize = _fileOptions.MaxSize;
            var fileType = _fileOptions.FileType;
            var canModify = _fileOptions.CanModify;
            var maxFileCount = _fileOptions.MaxFileCount;

            return Ok(new { fileSize = fileSize, fileType = fileType, canModify = canModify, maxFileCount = maxFileCount });
        }
    }
}
