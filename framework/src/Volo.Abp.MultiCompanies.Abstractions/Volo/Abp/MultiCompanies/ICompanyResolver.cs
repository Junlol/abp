using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Volo.Abp.MultiCompanies;

public interface ICompanyResolver
{
    /// <summary>
    /// Tries to resolve current company using registered <see cref="ICompanyResolveContributor"/> implementations.
    /// </summary>
    /// <returns>
    /// Company id, unique name or null (if could not resolve).
    /// </returns>
    [NotNull]
    Task<CompanyResolveResult> ResolveCompanyIdOrNameAsync();
}
