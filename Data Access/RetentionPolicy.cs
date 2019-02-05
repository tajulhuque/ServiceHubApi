namespace ServiceHubApi.Data_Access
{
    public class RetentionPolicy
    {
        
        public int Id { get; set; }

        /// <summary>
        /// Retain the object until this many hours.  After this many hours has elapsed,
        /// then delete the object
        /// </summary>
        /// <value></value>
        public int RetentionTimeHours { get; set; }

        public bool IsRetainForever {get; set;}

        public int ForSeverity {get; set;}

        public string ForAppName {get; set;}

        public string ForDescription {get; set;}

        public string Description {get; set;}

    }

    
}