using System.Threading.Tasks;

namespace Volo.Abp.MultiCompanies;

public abstract class CompanyResolveContributorBase : ICompanyResolveContributor
{
    public abstract string Name { get; }

    public abstract Task ResolveAsync(ICompanyResolveContext context);
}
