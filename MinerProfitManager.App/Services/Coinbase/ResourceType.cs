using System.Runtime.Serialization;

namespace MinerProfitManager.App.Services.Coinbase
{
	public enum ResourceType
	{
		User,
		Account,
		Address,
		Notification,
		Transaction,
		Buy,
		Sell,
		Deposit,
		Withdrawal,
		[EnumMember(Value = "payment_method")]
		PaymentMethod
	}
}