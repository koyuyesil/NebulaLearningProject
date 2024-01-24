﻿using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Diagnostics;
using System.Reflection;

namespace NebulaLearning.Core.Net4x.Aspects.PostSharp.PerformanceAspect
{
    [PSerializable]
    public class PerformanceCounterAspect : OnMethodBoundaryAspect
    {
        private int _interval;
        [NonSerialized]
        private Stopwatch _stopwatch;
        public PerformanceCounterAspect(int interval = 5)
        {
            _interval = interval;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            _stopwatch = Activator.CreateInstance<Stopwatch>();
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine("Performance : {0}.{1}->>{2}", args.Method.DeclaringType.FullName, args.Method.Name, _stopwatch.Elapsed.TotalSeconds);
            }
            _stopwatch.Reset();
            base.OnExit(args);
        }
    }
}