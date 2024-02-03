using Quartz;
using SchdularApi.Jobs;

namespace SchdularApi
{
    public class QuartzService: IQuartzService
    {
        private readonly IScheduler _scheduler;
        public QuartzService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task SchedulePolling(ScheduleRequest request)
        {
            var job = JobBuilder.Create<PollingJob>()
                         .WithIdentity(request.JobId)
                         .Build();

            var trigger = TriggerBuilder.Create()
                            .WithIdentity($"{request.JobId.Split("-")[0]}")
                            .WithCronSchedule(request.CronTime)
                            .Build();

            await _scheduler.ScheduleJob(job, trigger);

            await Console.Out.WriteLineAsync("Job scheduled");
        }

        public async Task ScheduleTestJob(ScheduleRequest request)
        {

            var job = JobBuilder.Create<TestJob>()
                        .WithIdentity(request.JobId)
                        .Build();

            var trigger = TriggerBuilder.Create()
                            .WithIdentity($"{request.JobId.Split("-")[0]}")
                            .WithCronSchedule(request.CronTime)
                            .Build();

            await _scheduler.ScheduleJob(job, trigger);

            await Console.Out.WriteLineAsync("Job scheduled");
        }
    }
}
