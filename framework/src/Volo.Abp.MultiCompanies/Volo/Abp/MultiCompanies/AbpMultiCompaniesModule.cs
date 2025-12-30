using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.EventBus.Abstractions;
using Volo.Abp.Modularity;
using Volo.Abp.MultiCompanies.ConfigurationStore;
using Volo.Abp.Security;
using Volo.Abp.Settings;

namespace Volo.Abp.MultiCompanies;

[DependsOn(
    typeof(AbpDataModule),
    typeof(AbpSecurityModule),
    typeof(AbpSettingsModule),
    typeof(AbpEventBusAbstractionsModule),
    typeof(AbpMultiCompaniesAbstractionsModule)
    )]
public class AbpMultiCompaniesModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton<ICurrentCompanyAccessor>(AsyncLocalCurrentCompanyAccessor.Instance);

        var configuration = context.Services.GetConfiguration();
        Configure<AbpDefaultCompanyStoreOptions>(configuration);

        Configure<AbpSettingOptions>(options =>
        {
            options.ValueProviders.InsertAfter(t => t == typeof(GlobalSettingValueProvider), typeof(CompanySettingValueProvider));
        });

        Configure<AbpCompanyResolveOptions>(options =>
        {
            options.CompanyResolvers.Insert(0, new CurrentUserCompanyResolveContributor());
        });
    }
}
