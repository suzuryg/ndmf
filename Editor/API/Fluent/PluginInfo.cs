﻿using nadena.dev.ndmf.model;

namespace nadena.dev.ndmf.fluent
{
    internal class PluginInfo
    {
        private readonly SolverContext _solverContext;
        private readonly IPlugin _plugin;
        private int sequenceIndex = 0;
        
        public PluginInfo(SolverContext solverContext, IPlugin plugin)
        {
            _solverContext = solverContext;
            _plugin = plugin;
        }

        internal Sequence NewSequence(BuildPhase phase)
        {
            string sequencePrefix = _plugin.QualifiedName + "/sequence#" + sequenceIndex++;
            return new Sequence(phase, _solverContext, _plugin, sequencePrefix);
        }
    }
}