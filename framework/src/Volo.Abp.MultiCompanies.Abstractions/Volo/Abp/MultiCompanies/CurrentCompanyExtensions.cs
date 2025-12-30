using System;
using JetBrains.Annotations;

namespace Volo.Abp.MultiCompanies;

public static class CurrentCompanyExtensions
{
    public static Guid GetId([NotNull] this ICurrentCompany currentCompany)
    {
        Check.NotNull(currentCompany, nameof(currentCompany));

        if (currentCompany.Id == null)
        {
            throw new AbpException("Current Company Id is not available!");
        }

        return currentCompany.Id.Value;
    }

    public static MultiCompanySides GetMultiCompanySide(this ICurrentCompany currentCompany)
    {
        return currentCompany.Id.HasValue
            ? MultiCompanySides.Company
            : MultiCompanySides.Host;
    }
}
