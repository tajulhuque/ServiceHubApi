

using System.Collections.Generic;
using ServiceHubApi.Data_Access;
using System.Linq;
using System;

public class RetentionPolicyMatcher : IRetentionPolicyMatcher
{

    public RetentionPolicyMatcher()
    {
        
    }

    public RetentionPolicy Match(ServiceEvent seEvent, IEnumerable<RetentionPolicy> policies)
    {
        var matchScores = (from p in policies
                           let score = (string.Equals(seEvent.AppName, p.ForAppName, StringComparison.CurrentCultureIgnoreCase) ? 10 : 0) 
                                     + (seEvent.Severity == p.ForSeverity ? 10 : 0)
                                     + (string.Equals(seEvent.Description, p.ForDescription, StringComparison.CurrentCultureIgnoreCase) ? 10 : 0) 
                            select new {policy = p, score = score}).ToArray();

        var highestScore = matchScores.OrderByDescending(ms => ms.score).FirstOrDefault();
        return highestScore?.policy;
    }
}