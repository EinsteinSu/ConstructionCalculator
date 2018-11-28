namespace ConstructionCalculator.DataAccess.Interfaces
{
    public interface IShowProgress
    {
        void SetMaxValue(int maxValue);

        void SetCurrentValue(int value);

        void Done();
    }
}
