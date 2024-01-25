using NebulaLearning.Core.Net4x.CrossCuttingConserns.Caching;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Linq;
using System.Reflection;

namespace NebulaLearning.Core.Net4x.Aspects.PostSharp.CacheAspects
{
    [PSerializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private Type _type;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;

        public CacheAspect(Type type, int cacheByMinute=60) // default 60 minute ayarlandı
        {
            _type = type;
            _cacheByMinute = cacheByMinute;
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
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            // Method için key oluşturuldu.
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,
                args.Method.Name);
            var methodArgs = args.Arguments.ToList();
            var key = string.Format("{0}({1})",
                methodName, string.Join(",", methodArgs.Select(x => x != null ? x.ToString() : "<null>")));
            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            base.OnInvoke(args);
            _cacheManager.Add(key, args.ReturnValue, _cacheByMinute);
        }
    }
}
