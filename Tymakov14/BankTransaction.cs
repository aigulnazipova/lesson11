using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tymakov14
{
    internal class BankTransaction
    {
        public readonly DateTime TransactionTime;
        public readonly decimal Amount;
        /// <summary>
        /// Конструктор, который создает новый экземпляр класса и заполняет его данными.
        /// </summary>
        public BankTransaction(decimal amount)
        {
            TransactionTime = DateTime.Now;
            Amount = amount;
        }
    }
}
