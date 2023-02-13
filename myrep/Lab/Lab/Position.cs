namespace Lab
{
    public class Position
    {
        private int Code { get; set; }
        private string Name { get; set; } = string.Empty;
        private double BaseHourlyRate { get; set; }
        public Position() { }
        public Position(int code, string name, int baseHourlyRate)
        {
            Code = code;
            Name = name;
            BaseHourlyRate = baseHourlyRate;
        }

        public int GetCode() => Code;
        public string GetName() => Name;
        public double GetBaseHourlyRate() => BaseHourlyRate;
    }
}
