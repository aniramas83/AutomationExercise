namespace Automation.Core
{
	public class Settings
	{
		public static string Target => ConfigurationManager.GetSetting<string>("Target");
		public static string MlcSiteUrl => ConfigurationManager.GetSetting<string>("MlcWeb.Url");

		public static string TaxSiteUrl => ConfigurationManager.GetSetting<string>("TaxCalculator.Url");
		
	}
}