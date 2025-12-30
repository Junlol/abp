using System;

namespace Volo.Abp.MultiCompanies;

public interface IMultiCompany
{
    Guid? CompanyId { get; }
}
