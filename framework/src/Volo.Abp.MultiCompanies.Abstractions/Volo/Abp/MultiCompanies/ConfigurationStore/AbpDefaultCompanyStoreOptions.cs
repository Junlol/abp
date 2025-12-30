using System;

namespace Volo.Abp.MultiCompanies.ConfigurationStore;

public class AbpDefaultCompanyStoreOptions
{
    public CompanyConfiguration[] Companies { get; set; }

    public AbpDefaultCompanyStoreOptions()
    {
        Companies = Array.Empty<CompanyConfiguration>();
    }
}
