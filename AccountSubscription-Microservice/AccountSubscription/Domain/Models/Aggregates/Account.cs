using DittoBox.API.AccountSubscription.Domain.Models.Entities;

namespace DittoBox.API.AccountSubscription.Domain.Models.Aggregates
{
	public class Account
	{
		public int Id { get; set; }
		public string BusinessName { get; set; } = string.Empty;
		public string BusinessId { get; set; } = string.Empty;
		public int RepresentativeId { get; set; }
		public Account() { }
		public Account(int id, string businessName, string bussinessId, int representativeId, int subscriptionId)
		{
			Id = id;
			BusinessName = businessName;
			BusinessId = bussinessId;
			RepresentativeId = representativeId;
		}
		public void UpdateBusinessInformation(string businessName, string businessId, int representativeId)
		{
			BusinessName = businessName;
			BusinessId = businessId;
			RepresentativeId = representativeId;
		}
	}
}
