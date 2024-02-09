namespace RainfallApi.Constants
{
    public static class ConfigurationConstants
    {
        public static string EnvironmentApiBaseUrl = "https://environment.data.gov.uk";
        public static string RainfallMeasureUrl = "/flood-monitoring/id/stations/{0}/readings?_sorted&_limit={1}";
    }
}
