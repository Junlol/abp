using System.Collections.Generic;

namespace Volo.Abp.MultiCompanies;

public class CompanyResolveResult
{
    public string? CompanyIdOrName { get; set; }

    public List<string> AppliedResolvers { get; }

    public CompanyResolveResult()
    {
        AppliedResolvers = new List<string>();
    }
}
