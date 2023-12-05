using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tymakov13
{
    enum BankAccountType
    {
        Current,
        Savings
    }
    internal class BankAccount : IDisposable
    {
        private int _accountNumber;
        private decimal balance;
        private BankAccountType type;
        private string accountHolder;
        private List<BankTransaction> financialTransactions;
        private static int lastAccountNumber = 0;
        private Queue<BankTransaction> transactions;
        /// <summary>
        /// Свойство для чтения поля _accountNumber.
        /// </summary>
        public int AccountNumber
        {
            get
            {
                return _accountNumber;
            }
        }
        /// <summary>
        /// Свойство для чтения поля balance.
        /// </summary>
        public decimal Balance
        {
            get
            {
                return balance;
            }
        }
        /// <summary>
        /// Свойство для чтения поля type.
        /// </summary>
        public BankAccountType Type
        {
            get
            {
                return type;
            }
        }
        /// <summary>
        /// Свойство для чтения и заполнения поля accountHolder.
        /// </summary>
        public string AccountHolder
        {
            get 
            { 
                return accountHolder; 
            }
            set 
            { 
                accountHolder = value; 
            }
        }
        public BankTransaction this[int index]
        {
            get
            {
                if (index >= 0 && index < financialTransactions.Count)
                {
                    return financialTransactions[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
                }
            }
            set
            {
                if (index >= 0 && index < transactions.Count)
                {
                    financialTransactions[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
                }
            }
        }
        /// <summary>
        /// Конструктор, который создает новый экземпляр класса и заполняет его данными.
        /// </summary>
        internal BankAccount(decimal balance)
        {
            this.balance = balance;
            _accountNumber = GenerateAccountNumber();
            this.type = BankAccountType.Current;
            this.transactions = new Queue<BankTransaction>();
            financialTransactions = new List<BankTransaction>();
        }
        /// <summary>
        /// Конструктор, который создает новый экземпляр класса и заполняет его данными.
        /// </summary>
        internal BankAccount(BankAccountType type)
        {
            this.type = type;
            _accountNumber = GenerateAccountNumber();
            this.balance = 0;
            this.transactions = new Queue<BankTransaction>();
            financialTransactions = new List<BankTransaction>();
        }
        /// <summary>
        /// Конструктор, который создает новый экземпляр класса и заполняет его данными.
        /// </summary>
        internal BankAccount(decimal balance, BankAccountType type)
        {
            _accountNumber = GenerateAccountNumber();
            this.balance = balance;
            this.type = type;
            this.transactions = new Queue<BankTransaction>();
            financialTransactions = new List<BankTransaction>();
        }
        /// <summary>
        /// Конструктор, который создает новый экземпляр класса и заполняет его данными.
        /// </summary>
        internal BankAccount(decimal balance, int accountNumber)
        {
            _accountNumber = GenerateAccountNumber();
            this.balance = balance;
            this.transactions = new Queue<BankTransaction>();
            financialTransactions = new List<BankTransaction>();
        }
        /// <summary>
        /// Данный метод генерирует номер счета.
        /// </summary>
        private static int GenerateAccountNumber()
        {
            lastAccountNumber++;
            return lastAccountNumber;
        }
        /// <summary>
        /// Данный метод обеспечивает внесение введенной суммы на банковский счет.
        /// </summary>
        public void Deposit(decimal amount, decimal balance)
        {
            if (amount > 0)
            {
                balance += amount;
                BankTransaction transaction = new BankTransaction(amount);
                transactions.Enqueue(transaction);
                Console.WriteLine($"Внесено на счет: {amount} руб. Баланс после операций: {balance} руб.\n");
            }
            else
            {
                Console.WriteLine("Нельзя внести отрицательную сумму!");
            }

        }
        /// <summary>
        /// Данный метод обеспечивает снятие введенной суммы с банковского счета.
        /// </summary>
        public void Withdraw(decimal amount, decimal balance)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                BankTransaction transaction = new BankTransaction(-amount);
                transactions.Enqueue(transaction);
                Console.WriteLine($"Снято со счета: {amount} руб. Баланс после операций: {balance} руб.\n");
            }
            else
            {
                Console.WriteLine($"Невозможно снять сумму, недостаточно средств на счете! Баланс: {balance}\n");
            }
        }
        /// <summary>
        /// Данный метод обеспечивает перевод введенной суммы с одного банковского счета на другой.
        /// </summary>
        public void Transfer(BankAccount reciever, int sum)
        {
            if (sum < 0)
            {
                throw new ArgumentException("Сумма перевода не может быть отрицательной");
            }
            if (balance < sum)
            {
                throw new InvalidOperationException("На счете недостаточно средств!");
            }
            Withdraw(sum, balance);
            reciever.Deposit(sum, balance);
        }
        /// <summary>
        /// Данный метод записывает данные о транзакции в файл.
        /// </summary>
        public void Dispose()
        {
            string fileName = "transactions.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (BankTransaction transaction in transactions)
                {
                    writer.WriteLine($"{transaction.TransactionTime},{transaction.Amount}");
                }
            }

            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Данный метод выводит информацию о транзакциях банковского счета.
        /// </summary>
        public void PrintTransactions()
        {
            foreach (BankTransaction transaction in transactions)
            {
                Console.WriteLine($"Время транзакции: {transaction.TransactionTime}\nСумма: {transaction.Amount} руб.");
            }
        }
        /// <summary>
        /// Данный метод переопределяет метод Equals().
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            BankAccount other = (BankAccount)obj;
            return this._accountNumber == other._accountNumber && this.Balance == other.Balance;
        }
        /// <summary>
        /// Данный метод переопределяет метод GetHashCode().
        /// </summary>
        public override int GetHashCode()
        {
            return _accountNumber.GetHashCode() ^ Balance.GetHashCode();
        }

        /// <summary>
        /// Данный метод переопределяет метод ToString().
        /// </summary>
        public override string ToString()
        {
            return $"Номер счета: {GenerateAccountNumber()}\nБаланс: {balance} руб.\nТип счета: {type}";
        }

        /// <summary>
        /// Данный метод перегружает оператор =.
        /// </summary>
        public static bool operator ==(BankAccount a, BankAccount b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Данный метод перегружает оператор !=.
        /// </summary>
        public static bool operator !=(BankAccount a, BankAccount b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Данный метод добавляет новую транзакцию в список транзакций банковского счета.
        /// </summary>
        public void AddTransaction(BankTransaction transaction)
        {
            financialTransactions.Add(transaction);
        }
    }
}
