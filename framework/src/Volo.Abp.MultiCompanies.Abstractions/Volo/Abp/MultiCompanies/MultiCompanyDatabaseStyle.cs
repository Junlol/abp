using System;

namespace Volo.Abp.MultiCompanies;

[Flags]
public enum MultiCompanyDatabaseStyle
{
    Shared = 1,
    PerCompany = 2,
    Hybrid = Shared | PerCompany
}
