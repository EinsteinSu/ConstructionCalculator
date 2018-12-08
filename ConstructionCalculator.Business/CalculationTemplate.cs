namespace ConstructionCalculator.Business
{
    public class CalculationTemplate
    {
        public Table BusinessFeature { get; set; }

        public Table ConstructionValue { get; set; }

        public Table RiskLevel { get; set; }

        public Table CellMapping { get; set; }

        public Table Construction { get; set; }
    }

    public class Table
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}