using System.Collections.Generic;
using ServiceHubApi.Data_Access;

public interface IRetentionPolicyMatcher
{
    RetentionPolicy Match(ServiceEvent seEvent, IEnumerable<RetentionPolicy> policies);
}