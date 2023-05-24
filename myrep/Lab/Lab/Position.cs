namespace Lab
{
    [Serializable]
    public class Position
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BaseHourlyRate { get; set; }
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
