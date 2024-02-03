# API_Scheduler
Polling a specific API until a particular status is achieved using Quartz.NET

# Quartz.net Demonstration: Scheduled Job Management in .NET 6 API

Hi everyone,

Sharing a demonstration showcasing how Quartz.net can be used to efficiently schedule jobs in a .NET 6 API. 
In this walkthrough, we'll focus on a practical use case: polling a specific API until a particular status is achieved.

# Key Highlights:

# 1. Scheduled Jobs:
   We have set up three distinct jobs - Job_One, Job_Two, and Job_Three.

# 2. Trigger Timing:
   Each job is associated with a trigger set to run at different intervals:
   - Job_One triggers every 5 seconds.
   - Job_Two triggers every 10 seconds.
   - Job_Three triggers every 15 seconds.

# 3. API Interaction:
   All jobs are designed to call an API, monitoring its response. If the API returns a status of 3, the respective job is deleted. For example:
   - If Job_One receives a response of 3, it will be removed from the schedule.
   - Job_Two and Job_Three will persist until they receive a response of 3.

# Job Specifications:

# Job_One
{
  "jobId": "Job_One",
  "cronTime": "*/5 * * * * ?"
}


# Job_Two
{
  "jobId": "Job_Two",
  "cronTime": "*/10 * * * * ?"
}


# Job_Three
{
  "jobId": "Job_Three",
  "cronTime": "*/15 * * * * ?"
}

This demonstration not only illustrates the power of Quartz.net in job scheduling but also provides a practical example of its application in real-world scenarios.

Thanks
