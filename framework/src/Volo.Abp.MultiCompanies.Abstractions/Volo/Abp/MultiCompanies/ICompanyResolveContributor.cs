using System.Threading.Tasks;

namespace Volo.Abp.MultiCompanies;

public interface ICompanyResolveContributor
{
    string Name { get; }

    Task ResolveAsync(ICompanyResolveContext context);
}
