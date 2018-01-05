using System.Collections.Generic;

namespace Srpg.App.Domain.Common
{
    public interface IState
    {
        void Update();
        void Render();
        void OnEnter();
        void OnExit();
    }

    public class StateContaier
    {
        private Stack<IState> states = new Stack<IState>();

        public void Update()
        {
            var state = states.Peek();
            state.Update();
        }

        public void Render()
        {
            var state = states.Peek();
            state.Render();
        }

		public void Push(IState newState)
		{
			states.Push(newState);
		}

		public void Pop()
		{
			states.Pop();
		}
    }
}