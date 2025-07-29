using Rossoforge.Core.Services;

namespace Basket.Timer
{
    public interface ITimerService : IService, IUpdatable
    {
        void RegisterTimer(TimerBase timer);
        void UnregisterTimer(TimerBase timer);
    }
}
