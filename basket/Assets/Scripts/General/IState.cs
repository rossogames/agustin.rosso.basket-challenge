namespace Basket.General
{
    public interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }
}