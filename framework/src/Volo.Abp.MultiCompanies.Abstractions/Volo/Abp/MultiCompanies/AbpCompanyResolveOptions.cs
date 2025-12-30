using System.Collections.Generic;
using JetBrains.Annotations;

namespace Volo.Abp.MultiCompanies;

public class AbpCompanyResolveOptions
{
    [NotNull]
    public List<ICompanyResolveContributor> CompanyResolvers { get; }

    /// <summary>
    /// Fallback company to use when no other resolver resolves a company.
    /// </summary>
    public string? FallbackCompany { get; set; }

    public AbpCompanyResolveOptions()
    {
        CompanyResolvers = new List<ICompanyResolveContributor>();
    }
}
