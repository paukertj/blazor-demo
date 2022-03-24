namespace Client.Settings
{
    internal static class DiCompositor
    {
        internal static void AddOptions(this IServiceCollection services, IConfiguration? configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var connectionSettings = configuration.GetSection(nameof(ConnectionSettings));
            services.Configure<ConnectionSettings>(connectionSettings);
        }
    }
}
