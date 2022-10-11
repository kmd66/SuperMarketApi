﻿using System;
using System.Linq;
using Kama.AppCore.IOC;

[assembly: Kama.AppCore.IOC.Registrar(typeof(Kama.Bonyad.Evaluation.ApiClient.Registrar))]
namespace Kama.Bonyad.Evaluation.ApiClient
{
    using asm = System.Reflection.Assembly;

    class Registrar : IRegistrar
    {
        readonly Guid _id = Guid.NewGuid();
        public Guid ID => _id;

        public void Start(IContainer container)
        {
            var clientAssembly = asm.GetAssembly(this.GetType());

            container.RegisterFromAssembly(
                servicesAssembly: clientAssembly,
                implementationsAssembly: clientAssembly,
                isService: t => t.IsInterface && typeof(Interface.IService).IsAssignableFrom(t),
                isServiceImplementation: t => !t.IsInterface && t.IsClass && t.IsSubclassOf(typeof(Service))
             );

            /*var svcInterfaces = asm.GetAssembly(this.GetType())
                           .GetTypes()
                           .Where(t => t.IsInterface && typeof(Interface.IService).IsAssignableFrom(t));

            var svcClasses = asm.GetAssembly(this.GetType())
                             .GetTypes()
                             .Where(t => !t.IsInterface && t.IsClass && t.IsSubclassOf(typeof(Service)));

            foreach (var svcInterface in svcInterfaces)
            {
                var svcClass = svcClasses.FirstOrDefault(e => svcInterface.IsAssignableFrom(e));
                container.RegisterType(from: svcInterface, to: svcClass);
            }*/

            var hostInfo = container.TryResolve<Interface.IEvaluationHostInfo>();
            var objectSerializer = container.TryResolve<AppCore.IObjectSerializer>();

            container.RegisterInstance<Interface.IEvaluationClient>(new EvaluationClient(objectSerializer, hostInfo.Host, hostInfo.GetDefaultHeaders));
        }
    }
}
