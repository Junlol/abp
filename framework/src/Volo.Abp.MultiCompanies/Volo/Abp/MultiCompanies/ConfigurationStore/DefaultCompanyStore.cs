using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.MultiCompanies.ConfigurationStore;

[Dependency(TryRegister = true)]
public class DefaultCompanyStore : ICompanyStore, ITransientDependency
{
    private readonly AbpDefaultCompanyStoreOptions _options;

    public DefaultCompanyStore(IOptionsMonitor<AbpDefaultCompanyStoreOptions> options)
    {
        _options = options.CurrentValue;
    }

    public Task<CompanyConfiguration?> FindAsync(string normalizedName)
    {
        return Task.FromResult(Find(normalizedName));
    }

    public Task<CompanyConfiguration?> FindAsync(Guid id)
    {
        return Task.FromResult(Find(id));
    }

    public Task<IReadOnlyList<CompanyConfiguration>> GetListAsync(bool includeDetails = false)
    {
        return Task.FromResult<IReadOnlyList<CompanyConfiguration>>(_options.Companies);
    }

    public CompanyConfiguration? Find(string normalizedName)
    {
        return _options.Companies?.FirstOrDefault(t => t.NormalizedName == normalizedName);
    }

    public CompanyConfiguration? Find(Guid id)
    {
        return _options.Companies?.FirstOrDefault(t => t.Id == id);
    }
}
