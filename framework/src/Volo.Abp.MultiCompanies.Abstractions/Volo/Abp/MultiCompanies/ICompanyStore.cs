using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Volo.Abp.MultiCompanies;

public interface ICompanyStore
{
    Task<CompanyConfiguration?> FindAsync(string normalizedName);

    Task<CompanyConfiguration?> FindAsync(Guid id);

    Task<IReadOnlyList<CompanyConfiguration>> GetListAsync(bool includeDetails = false);

    [Obsolete("Use FindAsync method.")]
    CompanyConfiguration? Find(string normalizedName);

    [Obsolete("Use FindAsync method.")]
    CompanyConfiguration? Find(Guid id);
}
