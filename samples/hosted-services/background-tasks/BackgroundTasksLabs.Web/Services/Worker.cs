#region Imports
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace BackgroundTasksLabs.Web
{
    public class Worker : BackgroundService
    {
        #region Members

        private readonly ILogger<Worker> _logger;

        #endregion

        #region Ctor

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await BackgroundProcessing(stoppingToken);
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }

        #endregion

        #region Utilities

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker running at: {DateTimeOffset.Now}");
                await Task.Delay(1000, stoppingToken);
            }
        }

        #endregion
    }
}
