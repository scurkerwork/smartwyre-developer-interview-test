using Smartwyre.DeveloperTest.Enums;

namespace Smartwyre.DeveloperTest.Services.Attributes
{
	public class IncentiveTypeAttribute : Attribute
	{
		public IncentiveType IncentiveType { get; set; }


		public IncentiveTypeAttribute(IncentiveType incentiveType) 
		{
			IncentiveType = incentiveType;
		}
	}
}
