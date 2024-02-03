namespace SchdularApi
{
    public interface IQuartzService
    {
        Task ScheduleTestJob(ScheduleRequest request);
        Task SchedulePolling(ScheduleRequest request);
    }
}
