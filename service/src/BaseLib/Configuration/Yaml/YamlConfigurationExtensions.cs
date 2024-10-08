using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace BaseLib.Configuration
{
    public static class YamlConfigurationExtensions
    {
        public static IConfigurationBuilder AddYamlFile(this IConfigurationBuilder builder, string path)
        {
            return builder.AddYamlFile(null, path, false, false);
        }

        public static IConfigurationBuilder AddYamlFile(this IConfigurationBuilder builder, string path, bool optional)
        {
            return builder.AddYamlFile(null, path, optional, false);
        }

        public static IConfigurationBuilder AddYamlFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            return builder.AddYamlFile(null, path, optional, reloadOnChange);
        }

        public static IConfigurationBuilder AddYamlFile(this IConfigurationBuilder builder, IFileProvider provider, string path, bool optional, bool reloadOnChange)
        {
            bool flag = builder == null;
            if (flag)
            {
                throw new ArgumentNullException("builder");
            }
            bool flag2 = string.IsNullOrEmpty(path);
            if (flag2)
            {
                throw new ArgumentException("File path must be a non-empty string.", "path");
            }
            return builder.AddYamlFile(delegate (YamlConfigurationSource s)
            {
                s.FileProvider = provider;
                s.Path = path;
                s.Optional = optional;
                s.ReloadOnChange = reloadOnChange;
                s.ResolveFileProvider();
            });
        }

        public static IConfigurationBuilder AddYamlFile(this IConfigurationBuilder builder, Action<YamlConfigurationSource> configureSource)
        {
            return builder.Add(configureSource);
        }
    }
}