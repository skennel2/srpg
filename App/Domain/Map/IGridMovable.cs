namespace Srpg.App.Domain.Map
{
    public interface IGridMovable
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}