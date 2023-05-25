namespace Lab
{
    [Serializable]
    public class Contract
    {
        public int Number { get; set; }
        public DateOnly Date { get; set; }
        public string Client { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string Comment { get; set; } = string.Empty;

        public Contract() { }

        public Contract(int number, DateOnly date, string client, double amount, string comment)
        {
            Number = number;
            Date = date;
            Client = client;
            Amount = amount;
            Comment = comment;
        }

        public DateOnly GetContractDate() => Date;
        public double GetContractAmount() => Amount;
        public override string ToString() => $"*****\n{Date}\n{Number}. {Client} - {Amount} рублей\nКомментарий: {Comment}\n*****";
    }
}
