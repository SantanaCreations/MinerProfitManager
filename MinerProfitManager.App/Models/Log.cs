using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinerProfitManager.App.Models
{
	public class Log
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime Timestamp { get; set; }

		[Required]
		public string LogLevel { get; set; }

		[Required]
		public string Callsite { get; set; }

		[Required]
		public string Message { get; set; }
	}
}