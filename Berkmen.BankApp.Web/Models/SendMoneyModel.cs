using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkmen.BankApp.Web.Models
{
	public class SendMoneyModel
	{ //senderid, amountid,accountid
		public int SenderAccountId { get; set; }
		public int Amount { get; set; }

		public int AccountId { get; set; }

	}
}
