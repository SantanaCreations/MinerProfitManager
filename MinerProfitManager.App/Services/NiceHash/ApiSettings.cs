namespace MinerProfitManager.App.Services.NiceHash
{
    public class ApiSettings
    {
        private static bool DEVELOPMENT = true;

        public string ApiDomain { get; private set; }
        public string OrganizationID { get; private set; }
        public string ApiKey { get; private set; }
        public string ApiSecret { get; private set; }
        public string DefaultCurrency { get; private set; }

        public ApiSettings()
        {
            if (DEVELOPMENT)
            {
                ApiDomain = "https://api-test.nicehash.com";
                OrganizationID = "d4188b51-e4c0-4cd2-a1ba-b8d505882d10";
                ApiKey = "1da7c7c3-d39b-48d5-b771-9ebbeb334817";
                ApiSecret = "5b279a19-132e-401d-b9a2-cb50a816b5607441e0cd-ce33-422b-8829-3b188d008e00";
                DefaultCurrency = "TBTC";
            }
            else
            {
                
            }
        }
    }
}
