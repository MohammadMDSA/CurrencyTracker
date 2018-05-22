using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTracker.Models
{
	public class Check
	{
		public DateTime DateTime { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Amount { get; set; }
	}
}
