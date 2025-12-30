namespace Volo.Abp.MultiCompanies;

public class AbpMultiCompaniesOptions
{
    /// <summary>
    /// A central point to enable/disable multi-company.
    /// Default: false. 
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// Database style for companies.
    /// Default: <see cref="MultiCompanyDatabaseStyle.Hybrid"/>.
    /// </summary>
    public MultiCompanyDatabaseStyle DatabaseStyle { get; set; } = MultiCompanyDatabaseStyle.Hybrid;
}
