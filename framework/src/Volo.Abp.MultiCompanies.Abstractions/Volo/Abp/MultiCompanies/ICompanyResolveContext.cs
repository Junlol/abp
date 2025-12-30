using Volo.Abp.DependencyInjection;

namespace Volo.Abp.MultiCompanies;

public interface ICompanyResolveContext : IServiceProviderAccessor
{
    string? CompanyIdOrName { get; set; }

    bool Handled { get; set; }
}
