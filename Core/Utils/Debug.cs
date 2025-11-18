using System;
using Aeros.Core.Dynamics;
using Aeros.Core.Avionics;
using Aeros.Core.Executive;
using System.Collections.Generic;

namespace Aeros.Core.Utils
{
    public interface ILogSource
    {
        List<string> Logs { get; }
    }

    public class Logger
    {
        private readonly List<ILogSource> _sources = new();

        public Logger(params ILogSource[] sources)
        {
            _sources.AddRange(sources);
        }

        public List<string> PrintLog()
        {

            List<string> buffer = new List<string>();

            foreach (var source in _sources)
            {
                buffer.AddRange(source.Logs);
                source.Logs.Clear();
            }

            return buffer;
        }
    }
}