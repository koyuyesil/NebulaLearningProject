using FluentValidation.Validators;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Caching;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Reflection;



namespace NebulaLearning.Core.Net4x.Aspects.PostSharp.CacheAspects
{
    [PSerializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private string _pattern;
        private Type _type;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(Type type)
        {
            _type = type;   
        }
        public CacheRemoveAspect(string pattern, Type type)
        {
            _pattern = pattern;
            _type = type;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_type) == false)
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_type);
            base.RuntimeInitialize(method);
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
                ? string.Format("{0}.{1}.*",args.Method.ReflectedType.Namespace,args.Method.ReflectedType.Name):_pattern);
            // patterne uyan cache namespace ve name tamamen silinir
            base.OnSuccess(args);
        }

    }
}
