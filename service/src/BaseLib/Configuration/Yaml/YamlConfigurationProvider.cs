using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using YamlDotNet.Core;

namespace BaseLib.Configuration
{
    public class YamlConfigurationProvider : FileConfigurationProvider
    {
        public YamlConfigurationProvider(YamlConfigurationSource source) : base(source)
        {
        }

        public override void Load(Stream stream)
        {
            YamlConfigurationFileParser yamlConfigurationFileParser = new YamlConfigurationFileParser();
            try
            {
                Data = yamlConfigurationFileParser.Parse(stream);
            }
            catch (YamlException ex)
            {
                string arg = string.Empty;
                bool canSeek = stream.CanSeek;
                if (canSeek)
                {
                    stream.Seek(0L, SeekOrigin.Begin);
                    using StreamReader streamReader = new StreamReader(stream);
                    IEnumerable<string> fileContent = ReadLines(streamReader);
                    arg = RetrieveErrorContext(ex, fileContent);
                }
                throw new FormatException("Could not parse the YAML file. " + string.Format("Error on line number '{0}': '{1}'.", ex.Start.Line, arg), ex);
            }
        }

        private static string RetrieveErrorContext(YamlException ex, IEnumerable<string> fileContent)
        {
            string text = fileContent.Skip(ex.Start.Line - 1).FirstOrDefault<string>();
            return text ?? string.Empty;
        }

        private static IEnumerable<string> ReadLines(StreamReader streamReader)
        {
            string line;
            do
            {
                line = streamReader.ReadLine();
                yield return line;
            }
            while (line != null);
            yield break;
        }
    }
}