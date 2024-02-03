using Quartz;

namespace SchdularApi
{
    public class TestJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync($"Job is executing, for Id : {context.JobDetail.Key.Name} time is : {DateTime.Now}");
        }
    }
}
