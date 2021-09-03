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
            catch (ArgumentNullException ex)
            {
                //   System.ArgumentNullException:
                //     fileName is null.
                _logger.LogError(ex.Message);
            }
            catch (System.Security.SecurityException ex)
            {
                //   System.Security.SecurityException:
                //     The caller does not have the required permission.
                _logger.LogError(ex.Message);
            }
            catch (ArgumentException ex)
            {
                //   System.ArgumentException:
                //     The file name is empty, contains only white spaces, or contains invalid
                //     characters.
                _logger.LogError(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                //   System.UnauthorizedAccessException:
                //     Access to fileName is denied.
                _logger.LogError(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                //   System.IO.PathTooLongException:
                //     The specified path, file name, or both exceed the system-defined maximum
                //     length. For example, on Windows-based platforms, paths must be less than
                //     248 characters, and file names must be less than 260 characters.
                _logger.LogError(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                //   System.NotSupportedException:
                //     fileName contains a colon (:) in the middle of the string.
                _logger.LogError(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                // System.FileNotFoundException
                //  The exception that is thrown when an attempt to access a file that does not
                //  exist on disk fails.
                _logger.LogError(ex.Message);
            }
            catch (IOException ex)
            {
                //   System.IO.IOException:
                //     An I/O error occurred while opening the file.
                _logger.LogError(ex.Message);
            }
            catch (CsvHelper.HeaderValidationException ex)
            {
                _logger.LogError(ex.Message);
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
