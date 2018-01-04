namespace Srpg.App.Domain.Common
{
    public interface IState
    {
        void Update();
        void Render();
        void OnEnter();
        void OnExit();
    }
}