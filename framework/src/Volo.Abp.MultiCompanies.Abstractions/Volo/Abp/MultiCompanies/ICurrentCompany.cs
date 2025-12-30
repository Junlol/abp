using System;

namespace Volo.Abp.MultiCompanies;

public interface ICurrentCompany
{
    bool IsAvailable { get; }

    Guid? Id { get; }

    string? Name { get; }

    IDisposable Change(Guid? id, string? name = null);
}
