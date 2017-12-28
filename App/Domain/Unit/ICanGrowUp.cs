namespace Srpg.App.Domain.Unit
{
    public interface ICanGrowUp
    {
        int Level { get; }
        int ExperiencePoint { get; }
        void IncreaseLevel();
        void AcquireExperiencePoint(int amount);
    }
}