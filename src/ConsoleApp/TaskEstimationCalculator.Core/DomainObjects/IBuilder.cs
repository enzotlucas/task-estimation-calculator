namespace TaskEstimationCalculator.Core.DomainObjects
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
