﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly:Kama.AppCore.IOC.Registrar(typeof(Kama.Bonyad.Evaluation.Infrastructure.DAL.LayerRegistrar))]
namespace Kama.Bonyad.Evaluation.Infrastructure.DAL
{
    using asm = System.Reflection.Assembly;
    using ds = Core.DataSource;

    class LayerRegistrar : AppCore.IOC.IRegistrar
    {
        readonly Guid _guid = Guid.NewGuid();
        public Guid ID => _guid;

        public void Start(AppCore.IOC.IContainer container)
        {
            var dsInterfaces = asm.GetAssembly(typeof(ds.IDataSource))
                           .GetTypes()
                           .Where(t => t.IsInterface && t != typeof(ds.IDataSource));

            var dsClasses = asm.GetAssembly(this.GetType())
                             .GetTypes()
                             .Where(t => t.IsClass && t.IsSubclassOf(typeof(DataSource)));

            foreach (var di in dsInterfaces)
            {
                var dsClass = dsClasses.FirstOrDefault(dc => di.IsAssignableFrom(dc));
                if (dsClass != null)
                    container.RegisterType(from: di, to: dsClass);
            }
        }
    }
}
