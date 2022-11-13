using System;
using System.Collections.Generic;

namespace PlateTD.Extensions
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void RegisterService<T>(object service)
        {
            var serviceType = typeof(T);

            if (_services.ContainsKey(serviceType))
            {
                throw new Exception($"[ServiceLocator][RegisterService] Service already exists with type: {serviceType.Name}");
            }

            _services.Add(serviceType, service);
        }

        public static T Resolve<T>()
        {
            var serviceType = typeof(T);

            if (!_services.ContainsKey(serviceType))
            {
                throw new Exception($"[ServiceLocator][GetService] Can find service of type: {serviceType.Name}");
            }

            return (T)_services[serviceType];
        }

        public static void RemoveService<T>()
        {
            var serviceType = typeof(T);

            if (!_services.ContainsKey(serviceType))
            {
                throw new Exception($"[ServiceLocator][RemoveService] Can find service of type: {serviceType.Name}");
            }

            _services.Remove(serviceType);
        }
    }
}