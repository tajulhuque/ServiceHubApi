# Service Hub 

"Service Hub" is an applicaiton for monitoring the activity of backend services.  Backend services can publish events to an API to signal that something was completed succesfully or if an error occurred.  The goal is to have one central view where all services "pass through" (a "hub") and report their recent interesting activity.  This project was created as learning project but also to address a real need at my current job.  My development team and I are currenlty relying on email notificaitons sent by our backend services.  Emails can get shuffled away by oulook rules and missed so hence the need for a dashboard like this.
 
## Architecture
 ServiceHubClient:  https://github.com/tajulhuque/ServiceHubClient/  - An Angular 4 applicaiton for the user interface
 ServiceHubApi: https://github.com/tajulhuque/ServiceHubApi/ - A .NET Core 2.0 App for the api backend and admin pages (MVC)

## Use Cases 
 1. An "Email Parser" service listens for new emails into an inbox.  When it picks up an email does some action, you might like to see that event displayed on the Service Hub.  Maybe you recently deployed a change to the email parser and want to verify the new version is running
 
 2. An "Integration Handler" that does API based integrations.  You might want to know everytime some data is synced, so you can can know to go look a the end result and make sure it looks good in the target system.
 
 3. Any error that a service runs into needs to be very visible so that developers can be made aware immediately and resolve quickly.  The event in this case needs to show the log trace, exception information, and stack trace to help you debug
 
## Retention
Depending on how many events and how frequently services publish events to the Service Hub, the amount of data to persist could grow quite large.  Therefore, a retention policy mechanism was developed.  Retention policies can be created which can be setup to have rules that match to events.  When a retention policy matches to a certain event, that event will only live for as long as specified in the retention policy
 

##  A Work in progress
To be implemented soon:
  1. The culling of event data based on retention policy expirations
  2. Auto-refresh of the event data on the client User Interface
  3. An actual persistance storage of events and policies (currently using .NET EF-Core In-Memory store)
