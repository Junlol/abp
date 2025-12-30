using Volo.Abp.DependencyInjection;

namespace Volo.Abp.MultiCompanies;

public class NullCompanyResolveResultAccessor : ICompanyResolveResultAccessor, ISingletonDependency
{
    public CompanyResolveResult? Result {
        get => null;
        set { }
    }
}
