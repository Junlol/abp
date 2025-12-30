using System;
using JetBrains.Annotations;
using Volo.Abp.Data;

namespace Volo.Abp.MultiCompanies;

[Serializable]
public class CompanyConfiguration
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string NormalizedName { get; set; } = default!;

    public ConnectionStrings? ConnectionStrings { get; set; }

    public bool IsActive { get; set; }

    public CompanyConfiguration()
    {
        IsActive = true;
    }

    public CompanyConfiguration(Guid id, [NotNull] string name)
        : this()
    {
        Check.NotNull(name, nameof(name));

        Id = id;
        Name = name;

        ConnectionStrings = new ConnectionStrings();
    }

    public CompanyConfiguration(Guid id, [NotNull] string name, [NotNull] string normalizedName)
        : this(id, name)
    {
        Check.NotNull(normalizedName, nameof(normalizedName));

        NormalizedName = normalizedName;
    }
}
