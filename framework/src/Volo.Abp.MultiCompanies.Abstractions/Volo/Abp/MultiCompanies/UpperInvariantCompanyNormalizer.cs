namespace Volo.Abp.MultiCompanies;

public class UpperInvariantCompanyNormalizer : ICompanyNormalizer
{
    public string Normalize(string name)
    {
        return name.ToUpperInvariant();
    }
}
