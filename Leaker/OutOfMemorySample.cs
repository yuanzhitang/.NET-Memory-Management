using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leaker
{
	public class OutOfMemorySample
	{
		private static TransactionProcessor _txnProcessor = new TransactionProcessor();
		public static void Run()
		{
			while (true)
			{
				for (int i = 0; i < 10*10000; i++)
				{
					_txnProcessor.Process(new Transaction(Guid.NewGuid().ToString()));
				}

				Thread.Sleep(1000);
			}
		}
	}

	class TransactionProcessor
	{
		private TransactionCache _cache = new TransactionCache();

		public void Process(Transaction txn)
		{
			_cache.AddTxn(txn);
		}
	}

	class TransactionCache
	{
		private List<Transaction> _cache = new List<Transaction>();
		public void AddTxn(Transaction txn)
		{
			_cache.Add(txn);
		}
	}

	class Transaction
	{
		private string _id;

		public Transaction(string id)
		{
			_id = id;
		}
	}
}
