using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Contract
    {
        private int Number { get; set; }
        private DateOnly Date { get; set; }
        private string Client { get; set; } = string.Empty;
        private double Amount { get; set; }
        private string Comment { get; set; } = string.Empty;

        public Contract(int number, DateOnly date, string client, double amount, string comment)
        {
            Number = number;
            Date = date;
            Client = client;
            Amount = amount;
            Comment = comment;
        }

        public DateOnly GetContractDate() => Date;
        public override string ToString() => $"*****\n{Date}\n{Number}. {Client} - {Amount} рублей\nКомментарий: {Comment}\n*****";
    }
}
