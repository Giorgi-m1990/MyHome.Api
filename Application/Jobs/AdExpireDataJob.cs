using Infrastructure.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyHome.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHome.Application.Jobs
{
    public class AdExpireDataJob : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFac;
        public AdExpireDataJob(IServiceScopeFactory serviceScopeFac)
        {
            _serviceScopeFac = serviceScopeFac;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ExecuteJob(stoppingToken);
        }

        public async Task ExecuteJob(CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFac.CreateScope())
            {
                var _adRepository = scope.ServiceProvider.GetRequiredService<IAdRepository>();
                var ads = _adRepository.GetQueries(i => i.CreationTime.AddDays(30) <= DateTime.Now);
                var totalCount = await ads.CountAsync();
                var data = await ads.ToListAsync();

                var numberOfChunks = Math.Ceiling(Convert.ToDecimal(totalCount) / 50);

                for (int i = 1; i <= numberOfChunks; i++)
                {
                    foreach (var ad in data.Skip((i - 1) * 50).Take(50))
                    {
                        ad.AdStatus = AdStatus.InActive;
                    }
                    await _adRepository.SaveChangesAsync();
                }
            }
            
        }
    }
}
