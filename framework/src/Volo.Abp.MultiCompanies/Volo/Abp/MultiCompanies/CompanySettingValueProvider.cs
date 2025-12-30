using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.MultiCompanies;

namespace Volo.Abp.Settings;

public class CompanySettingValueProvider : SettingValueProvider
{
    public const string ProviderName = "C";

    public override string Name => ProviderName;

    protected ICurrentCompany CurrentCompany { get; }

    public CompanySettingValueProvider(ISettingStore settingStore, ICurrentCompany currentCompany)
        : base(settingStore)
    {
        CurrentCompany = currentCompany;
    }

    public async override Task<string?> GetOrNullAsync(SettingDefinition setting)
    {
        return await SettingStore.GetOrNullAsync(setting.Name, Name, CurrentCompany.Id?.ToString());
    }

    public override async Task<List<SettingValue>> GetAllAsync(SettingDefinition[] settings)
    {
        return await SettingStore.GetAllAsync(settings.Select(x => x.Name).ToArray(), Name, CurrentCompany.Id?.ToString());
    }
}
