using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp;

namespace AElf.Boilerplate.EventHandler
{
    public class EventHandlerAppHostedService : IHostedService
    {
        private readonly IAbpApplicationWithExternalServiceProvider _application;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EventHandlerAppHostedService> _logger;

        public EventHandlerAppHostedService(
            IAbpApplicationWithExternalServiceProvider application,
            IServiceProvider serviceProvider, ILogger<EventHandlerAppHostedService> logger)
        {
            _application = application;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _application.Initialize(_serviceProvider);

            var configOptions = _serviceProvider.GetRequiredService<IOptionsSnapshot<ConfigOptions>>().Value;
            var nodeManager = new NodeManager(configOptions.BlockChainEndpoint, configOptions.AccountAddress,
                configOptions.AccountPassword);
            if (!nodeManager.TransactionManager.IsKeyReady())
            {
                _logger.LogError("Something wrong with key store.");
                return Task.CompletedTask;
            }

            var contractAddressOptions =
                _serviceProvider.GetRequiredService<IOptionsSnapshot<ContractAddressOptions>>().Value;
            _logger.LogInformation(
                $"ContractAddressOptions contains: {contractAddressOptions.ContractAddressMap.Keys.Aggregate("", (t, n) => $"{t}\t{n}")}");

            var messageQueueOptions =
                _serviceProvider.GetRequiredService<IOptionsSnapshot<MessageQueueOptions>>().Value;
            _logger.LogInformation($"Message Queue Configs:\n" +
                                   $"HostName: {messageQueueOptions.HostName}\n" +
                                   $"Uri: {messageQueueOptions.Uri}\n" +
                                   $"Port:{messageQueueOptions.Port}\n" +
                                   $"ClientName: {messageQueueOptions.ClientName}\n" +
                                   $"ExchangeName: {messageQueueOptions.ExchangeName}");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _application.Shutdown();
            return Task.CompletedTask;
        }
    }
}