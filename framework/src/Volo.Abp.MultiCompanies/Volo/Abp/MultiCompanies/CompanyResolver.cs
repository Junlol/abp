using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.MultiCompanies;

public class CompanyResolver : ICompanyResolver, ITransientDependency
{
    public ILogger<CompanyResolver> Logger { get; set; }

    protected IServiceProvider ServiceProvider { get; }
    protected AbpCompanyResolveOptions Options { get; }

    public CompanyResolver(IOptions<AbpCompanyResolveOptions> options, IServiceProvider serviceProvider)
    {
        Logger = NullLogger<CompanyResolver>.Instance;

        ServiceProvider = serviceProvider;
        Options = options.Value;
    }

    public virtual async Task<CompanyResolveResult> ResolveCompanyIdOrNameAsync()
    {
        var result = new CompanyResolveResult();

        Logger.LogDebug("Starting resolving company...");
        using (var serviceScope = ServiceProvider.CreateScope())
        {
            var context = new CompanyResolveContext(serviceScope.ServiceProvider);

            foreach (var companyResolver in Options.CompanyResolvers)
            {
                Logger.LogDebug("Trying to resolve company through '{CompanyResolverName}'...", companyResolver.Name);
                await companyResolver.ResolveAsync(context);

                result.AppliedResolvers.Add(companyResolver.Name);

                if (context.HasResolvedCompanyOrHost())
                {
                    result.CompanyIdOrName = context.CompanyIdOrName;
                    Logger.LogDebug("Company resolved by '{CompanyResolverName}' as '{CompanyIdOrName}'.", companyResolver.Name, result.CompanyIdOrName ?? "Host");
                    break;
                }
            }
        }

        if (result.CompanyIdOrName.IsNullOrEmpty() && !string.IsNullOrWhiteSpace(Options.FallbackCompany))
        {
            result.CompanyIdOrName = Options.FallbackCompany;
            result.AppliedResolvers.Add(CompanyResolverNames.FallbackCompany);
            Logger.LogDebug("No company resolved. Using fallback company as '{FallbackCompany}'.", result.CompanyIdOrName);
        }
        else if (result.CompanyIdOrName.IsNullOrEmpty())
        {
            Logger.LogDebug("No company resolved.");
        }

        return result;
    }
}
