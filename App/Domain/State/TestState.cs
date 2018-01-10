using Srpg.App.Domain.Common;

namespace Srpg.App.Domain.State
{
    public class TestState : IState
    {
        public void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnExit()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Render()
        {
            throw new System.NotImplementedException();
        }
    }

    public class StateRunner
    {
        static public void RunState(IState state)
        {
            state.OnEnter();

            while(true)
            {
                state.Update();
                state.Render();
            }

            state.OnExit();
        }
    }
}