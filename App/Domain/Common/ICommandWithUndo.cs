namespace Srpg.App.Domain.Common
{
    public interface ICommandWithUndo : ICommand
    {
        void Undo();
    }
}