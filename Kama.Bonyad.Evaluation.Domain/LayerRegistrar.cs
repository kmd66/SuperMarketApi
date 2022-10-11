using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Linq;
using ioc = Kama.AppCore.IOC;

[assembly: ioc.Registrar(typeof(Kama.Bonyad.Evaluation.Domain.LayerRegistrar), Order = 1)]
namespace Kama.Bonyad.Evaluation.Domain
{
    using asm = System.Reflection.Assembly;
    using svc = Core.Service;

    class LayerRegistrar : ioc.IRegistrar
    {
        private readonly Guid _layerId = Guid.NewGuid();

        public Guid ID => _layerId;

        public void Start(ioc.IContainer container)
        {
            var svcInterfaces = asm.GetAssembly(typeof(svc.IService))
                           .GetTypes()
                           .Where(t => t.IsInterface && t != typeof(svc.IService));

            var svcClasses = asm.GetAssembly(this.GetType())
                             .GetTypes()
                             .Where(t => t.IsClass && t.IsSubclassOf(typeof(Service)));

            foreach (var svcInterface in svcInterfaces)
            {
                var svcClass = svcClasses.FirstOrDefault(e => svcInterface.IsAssignableFrom(e));
                if (svcClass != null)
                    container.RegisterType(from: svcInterface, to: svcClass);
            }

            StartTimers(container);
        }

        private void StartTimers(ioc.IContainer container)
        {
            //container.RegisterType<ITimerToAddMinisterListLetters, TimerToAddMinisterListLetters>();
            //var timerToAddMinisterListLetters = container.Resolve<ITimerToAddMinisterListLetters>();
            //timerToAddMinisterListLetters.Start();

            //container.RegisterType<ITimerToUpdateLetterNumbers, TimerToUpdateLetterNumbers>();
            //var timerToUpdateLetterNumbers = container.Resolve<ITimerToUpdateLetterNumbers>();
            //timerToUpdateLetterNumbers.Start();

            //container.RegisterType<IFollowingLetterAutomationTimer, FollowingLetterAutomationTimer>();
            //var followingLetterAutomationTimer = container.Resolve<IFollowingLetterAutomationTimer>();
            //followingLetterAutomationTimer.Start();

            //container.RegisterType<ITimerToUpdateIncomingLetters, TimerToUpdateIncomingLetters>();
            //var timerToUpdateIncomingLetters = container.Resolve<ITimerToUpdateIncomingLetters>();
            //timerToUpdateIncomingLetters.Start();

        }
    }
}