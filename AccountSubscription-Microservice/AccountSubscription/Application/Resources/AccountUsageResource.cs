namespace DittoBox.API.AccountSubscription.Application.Resources
{
	public record Usage
	{
		public int Current { get; init; }
		public int CurrentLimit { get; init; }
		public int LowerPlanLimit { get; init; }
		public int UpperPlanLimit { get; init; }
	}

	public record AccountUsageResource
	{
		public int AccountId { get; init; }
		public string CurrentPlan { get; init; }
		public string LowerPlan { get; init; }
		public string UpperPlan { get; init; }
		public Usage Users { get; init; }
		public Usage Containers { get; init; }
		public Usage Facilities { get; init; }
	}
}