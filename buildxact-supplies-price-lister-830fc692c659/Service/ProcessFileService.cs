using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuppliesPriceLister.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace buildxact_supplies.Service
{
    public sealed class ProcessFileService : IHostedService
    {
        private readonly ILogger<ProcessFileService> _logger;
        private readonly IFileParserService _fileParserService;

        public ProcessFileService(IFileParserService fileParserService,
             ILogger<ProcessFileService> logger)
        {
            _fileParserService = fileParserService;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Process started");
            try
            {
                var dir = Directory.GetCurrentDirectory();
                await _fileParserService.ProcessParsedFiles(dir + "\\humphries.csv", dir + "\\megacorp.json");
            }
            catch (Exception ex)
            {
                _logger.LogError("Processed stopped because of unhandled exception" + ex.Message);
            }
            _logger.LogInformation("Process ended");
            return;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
