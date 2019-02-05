using Microsoft.EntityFrameworkCore;

namespace ServiceHubApi.Data_Access
{
     public class ServiceEventContext : DbContext
    {
        public ServiceEventContext(DbContextOptions<ServiceEventContext> options) : base(options)
        {
            
        }

        public DbSet<ServiceEvent> ServiceEvents {get; set;}

        public DbSet<RetentionPolicy> RetentionPolicies {get; set;}
    }
}