namespace MinerProfitManager.App.Services.Coinbase
{
	public enum ResourceStatus
	{
		Created = 1,
		Unconfirmed = 2,
		Pending = 3,
		Canceled = 4,
		Completed = 5,
		NewPayment = 6
	}
}