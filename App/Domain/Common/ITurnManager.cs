namespace srpg.App.Domain.Common
{
    public interface ITurnManager
    {
        int NowTurn { get; }
        void RunNextTurn();
    }
}