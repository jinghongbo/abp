﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiThemeSharedModule)
        )]
    public class AbpAspNetCoreMvcUiBasicThemeModule : AbpModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ThemingOptions>(options =>
            {
                options.Themes.Add<BasicTheme>();

                if (options.DefaultThemeName == null)
                {
                    options.DefaultThemeName = BasicTheme.Name;
                }
            });

            services.Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiBasicThemeModule>("Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic");
            });

            services.Configure<ToolbarOptions>(options =>
            {
                options.Contributors.Add(new BasicThemeMainTopToolbarContributor());
            });

            services.Configure<BundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(BasicThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Styles.Global)
                            .AddContributors(new BasicThemeGlobalStyleContributor());
                    });

                options
                    .ScriptBundles
                    .Add(BasicThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle.AddBaseBundles(StandardBundles.Scripts.Global);
                    });
            });

            services.AddAssemblyOf<AbpAspNetCoreMvcUiBasicThemeModule>();
        }
    }
}
