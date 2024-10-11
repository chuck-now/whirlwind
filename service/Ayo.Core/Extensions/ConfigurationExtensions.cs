using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using BaseLib.Dependency;
using Ayo.Core.Configuration;

namespace Ayo.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddAppOptions(this IServiceCollection services, AppOptions appOptions)
        {
            services.AddSingleton(appOptions);
            services.AddSingleton(appOptions.StorageOptions);
            services.AddSingleton(appOptions.UploadOptions);
            services.AddSingleton(appOptions.JwtOptions);
            return services;
        }

        public static IIocManager AddAppOptions(this IIocManager iocManager, AppOptions appOptions)
        {
            iocManager.IocContainer.Register(Component.For<AppOptions>().Instance(appOptions));
            iocManager.IocContainer.Register(Component.For<StorageOptions>().Instance(appOptions.StorageOptions));
            iocManager.IocContainer.Register(Component.For<UploadOptions>().Instance(appOptions.UploadOptions));
            iocManager.IocContainer.Register(Component.For<JwtOptions>().Instance(appOptions.JwtOptions));
            return iocManager;
        }

        public static Dictionary<string, object> ToDictionary(this IConfiguration section, params string[] sectionsToSkip)
        {
            if (sectionsToSkip == null)
                sectionsToSkip = new string[0];

            var dict = new Dictionary<string, object>();
            foreach (var value in section.GetChildren())
            {
                // kubernetes service variables
                if (value.Key.StartsWith("DEV_", StringComparison.Ordinal))
                    continue;

                if (String.IsNullOrEmpty(value.Key) || sectionsToSkip.Contains(value.Key, StringComparer.OrdinalIgnoreCase))
                    continue;

                if (value.Value != null)
                    dict[value.Key] = value.Value;

                var subDict = ToDictionary(value);
                if (subDict.Count > 0)
                    dict[value.Key] = subDict;
            }

            return dict;
        }

        /// <summary>
        /// 从CMD获取当前指定环境的模式
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string GetEnvFromArgs(this string[] args)
        {
            var env = "dev";
            if (args.IsNullOrEmpty())
            {
                return env;
            }
            foreach (var argValue in args)
            {
                if (argValue.Contains("--env"))
                {
                    env = argValue.ReplaceByEmpty("--env=").Trim();
                }
            }
            return env;
        }
    }
}