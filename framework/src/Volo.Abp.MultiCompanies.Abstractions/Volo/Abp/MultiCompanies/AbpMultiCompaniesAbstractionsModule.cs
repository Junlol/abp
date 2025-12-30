using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiCompanies.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.MultiCompanies;

[DependsOn(
    typeof(AbpVirtualFileSystemModule),
    typeof(AbpLocalizationModule)
)]
public class AbpMultiCompaniesAbstractionsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpMultiCompaniesAbstractionsModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpMultiCompaniesResource>("en")
                .AddVirtualJson("/Volo/Abp/MultiCompanies/Localization");
        });
    }
}
