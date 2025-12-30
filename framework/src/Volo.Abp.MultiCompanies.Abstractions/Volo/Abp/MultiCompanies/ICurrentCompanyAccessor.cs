namespace Volo.Abp.MultiCompanies;

/* A null Current indicates that we haven't set it explicitly.
 * A null Current.CompanyId indicates that we have set null company id value explicitly.
 * A non-null Current.CompanyId indicates that we have set a company id value explicitly.
 */

public interface ICurrentCompanyAccessor
{
    BasicCompanyInfo? Current { get; set; }
}
