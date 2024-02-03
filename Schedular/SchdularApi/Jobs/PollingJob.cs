using Quartz;

namespace SchdularApi.Jobs
{
    public class PollingJob : IJob
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PollingJob(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                int result = 0;
                var jobId = context.JobDetail.Key.Name;
                using (var client = _httpClientFactory.CreateClient("pollingApi"))
                {
                    var response = await client.GetAsync($"/api/Values/value/{jobId}");
                    if(response.IsSuccessStatusCode)
                    {
                        var res = await response.Content.ReadAsStringAsync();
                        result = Convert.ToInt32(res);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        await Console.Out.WriteLineAsync($"For JobId : {jobId} the API Response is : {result} , at Time : {DateTime.Now}");
                        Console.ResetColor();
                    }
                }
                if (result == 3)
                {
                    var schedular = context.Scheduler;
                    JobKey jobKey = context.JobDetail.Key;
                    IReadOnlyCollection<ITrigger> triggers = await schedular.GetTriggersOfJob(jobKey);
                    List<TriggerKey> triggerKeys = triggers.Select(trigger => trigger.Key).ToList();
                    await schedular.UnscheduleJobs(triggerKeys);
                    await schedular.DeleteJob(jobKey);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    await Console.Out.WriteLineAsync($"API Response is : {result}, so job : {jobId} is deleted");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"{ex.Message}");
            }
        }
    }
}
