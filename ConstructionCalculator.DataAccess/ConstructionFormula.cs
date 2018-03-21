namespace ConstructionCalculator.DataAccess
{
    public class ConstructionFormula
    {
        public int Id { get; set; }

        public CalculatGroup Group { get; set; }

        public string ColumnId { get; set; }

        //using excel for calculating
        public string Formula { get; set; }

        public double Result { get; set; }
    }

    public enum CalculatGroup
    {
        潜在风险,
        接受水准,
        防火水准,
        火灾风险
    }
}