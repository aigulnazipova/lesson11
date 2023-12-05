using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tymakov14
{
    internal class BankTransaction
    {
        private DateTime transactionTime;
        public readonly decimal Amount;
        /// <summary>
        /// Свойство для чтения и заполнения полей transactionTime.
        /// </summary>
        public DateTime TransactionTime
        {
            get
            {
                return transactionTime;
            }
            set
            {
                transactionTime = value;
            }
        }
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
