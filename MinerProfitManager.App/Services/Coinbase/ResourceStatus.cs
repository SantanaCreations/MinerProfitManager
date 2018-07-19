using System.Runtime.Serialization;

namespace MinerProfitManager.App.Services.Coinbase
{
	public enum ResourceStatus
	{
		Created,
		Unconfirmed,
		Pending,
		Canceled,
		Completed,
		[EnumMember(Value = "new_payment")]
		NewPayment
	}
}