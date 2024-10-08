using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using YamlDotNet.RepresentationModel;

namespace BaseLib.Configuration
{
    internal class YamlConfigurationFileParser
    {
        private readonly Stack<string> _context = new Stack<string>();

        private readonly IDictionary<string, string> _data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private string _currentPath;

        public IDictionary<string, string> Parse(Stream stream)
        {
            _data.Clear();
            YamlStream yamlStream = new YamlStream();
            yamlStream.Load(new StreamReader(stream));
            bool flag = !yamlStream.Documents.Any<YamlDocument>();
            IDictionary<string, string> data;
            if (flag)
            {
                data = _data;
            }
            else
            {
                YamlMappingNode yamlMappingNode = yamlStream.Documents[0].RootNode as YamlMappingNode;
                bool flag2 = yamlMappingNode == null;
                if (flag2)
                {
                    data = _data;
                }
                else
                {
                    foreach (KeyValuePair<YamlNode, YamlNode> keyValuePair in yamlMappingNode.Children)
                    {
                        string value = ((YamlScalarNode)keyValuePair.Key).Value;
                        VisitYamlNode(value, keyValuePair.Value);
                    }
                    data = _data;
                }
            }
            return data;
        }

        private void VisitYamlNode(string context, YamlNode node)
        {
            if (!(node is YamlScalarNode yamlScalarNode))
            {
                if (!(node is YamlMappingNode yamlMappingNode))
                {
                    if (!(node is YamlSequenceNode yamlSequenceNode))
                    {
                        throw new ArgumentOutOfRangeException("node", "Unsupported YAML node type '" + node.GetType().Name + " was found. " + string.Format("Path '{0}', line {1} position {2}.", this._currentPath, node.Start.Line, node.Start.Column));
                    }
                    VisitYamlSequenceNode(context, yamlSequenceNode);
                }
                else
                {
                    VisitYamlMappingNode(context, yamlMappingNode);
                }
            }
            else
            {
                VisitYamlScalarNode(context, yamlScalarNode);
            }
        }

        private void VisitYamlScalarNode(string context, YamlScalarNode scalarNode)
        {
            EnterContext(context);
            string currentPath = _currentPath;
            bool flag = _data.ContainsKey(currentPath);
            if (flag)
            {
                throw new FormatException("A duplicate key '" + currentPath + "' was found.");
            }
            _data[currentPath] = scalarNode.Value;
            ExitContext();
        }

        private void VisitYamlMappingNode(string context, YamlMappingNode mappingNode)
        {
            EnterContext(context);
            foreach (KeyValuePair<YamlNode, YamlNode> keyValuePair in mappingNode.Children)
            {
                string value = ((YamlScalarNode)keyValuePair.Key).Value;
                VisitYamlNode(value, keyValuePair.Value);
            }
            ExitContext();
        }

        private void VisitYamlSequenceNode(string context, YamlSequenceNode sequenceNode)
        {
            EnterContext(context);
            for (int i = 0; i < sequenceNode.Children.Count; i++)
            {
                VisitYamlNode(i.ToString(), sequenceNode.Children[i]);
            }
            ExitContext();
        }

        private void EnterContext(string context)
        {
            _context.Push(context);
            _currentPath = ConfigurationPath.Combine(this._context.Reverse<string>());
        }

        private void ExitContext()
        {
            _context.Pop();
            _currentPath = ConfigurationPath.Combine(this._context.Reverse<string>());
        }
    }
}