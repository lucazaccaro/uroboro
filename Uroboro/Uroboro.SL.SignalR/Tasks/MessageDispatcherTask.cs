using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Uroboro.SL.SignalR.Hubs;

namespace Uroboro.SL.SignalR.Tasks
{
    public class MessageDispatcherTask : IHostedService, IDisposable
    {
        private IHubContext<SampleHub> _hubContext = null;
        private Timer _timer;
        private CancellationToken _tk;

        public MessageDispatcherTask(IHubContext<SampleHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void Dispose()
        {

        }

        private async void DoWork(object state)
        {
            var rnd = new Random();
            string message = rnd.Next(10000).ToString();

            await this._hubContext.Clients.All.SendAsync("GetServerMessage", message);

            //foreach (KeyValuePair<string, string> connectionItem in connections)
            //{
            //    await this._hubContext.Clients.Client(connectionItem.Key).SendAsync("receiveEarnings", this._dataService.GetEarnings(connectionItem.Value));
            //}

            // await StopAsync(_tk);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _tk = cancellationToken;
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
