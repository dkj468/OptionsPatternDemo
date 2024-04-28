using API.Options;
using Microsoft.Extensions.Options;
using FileOptions = API.Options.FileOptions;

namespace OptionsPatternDemo.Options
{
    public class FileOptionsSetup : IConfigureOptions<FileOptions>
    {
        private readonly IConfiguration _config;
        public FileOptionsSetup(IConfiguration config)
        {
            _config = config;
        }
        public void Configure(FileOptions options)
        {
            _config.GetSection("file").Bind(options);
            // bind the environment variable
            options.FileMode = Environment.GetEnvironmentVariable("filemode");
            // bind the command line argument
            options.version = _config.GetValue<string>("version"); 
        }
    }
}
