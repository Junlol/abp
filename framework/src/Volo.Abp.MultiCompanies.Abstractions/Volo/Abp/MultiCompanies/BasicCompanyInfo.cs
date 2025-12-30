using System;

namespace Volo.Abp.MultiCompanies;

public class BasicCompanyInfo
{
    /// <summary>
    /// Null indicates the host.
    /// Not null value for a company.
    /// </summary>
    public Guid? CompanyId { get; }

    /// <summary>
    /// Name of the company if <see cref="CompanyId"/> is not null.
    /// </summary>
    public string? Name { get; }

    public BasicCompanyInfo(Guid? companyId, string? name = null)
    {
        CompanyId = companyId;
        Name = name;
    }
}
