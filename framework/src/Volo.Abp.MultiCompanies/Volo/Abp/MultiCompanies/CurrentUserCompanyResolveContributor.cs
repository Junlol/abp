using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Users;

namespace Volo.Abp.MultiCompanies;

public class CurrentUserCompanyResolveContributor : CompanyResolveContributorBase
{
    public const string ContributorName = "CurrentUser";

    public override string Name => ContributorName;

    public override Task ResolveAsync(ICompanyResolveContext context)
    {
        var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
        if (currentUser.IsAuthenticated)
        {
            context.Handled = true;
            context.CompanyIdOrName = currentUser.TenantId?.ToString();
        }

        return Task.CompletedTask;
    }
}
