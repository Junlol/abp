namespace Volo.Abp.MultiCompanies;

public interface ICompanyResolveResultAccessor
{
    CompanyResolveResult? Result { get; set; }
}
