


using System;
using Microsoft.EntityFrameworkCore;

namespace ServiceHubApi.Data_Access
{
    public class ServiceEvent
    {
        public long Id { get; set; }
        public string AppName {get;set;}
        public string Description {get;set;}    
        public string LogEntry {get;set;}
        public int Type {get;set;}
        public int Severity {get;set;}
        public string ClientID {get; set;}
        public DateTime CreateDate {get;set;}
        public bool IsRetained {get;set;} 

        public RetentionPolicy RetentionPolicy {get; set;}
        
    }

   

}