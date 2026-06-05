using DotPulsar;
using DotPulsar.Extensions;

namespace {{ PrefixName }}{{ SuffixName }}.Resources;

public static class MessagingExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, Settings settings)
    {
        services.AddSingleton(_ =>
        {
            var builder = PulsarClient.Builder()
                .ServiceUrl(new Uri(settings.MessagingBrokerUrl));

            // Attach JWT token if provided (MESSAGING_JWT_TOKEN)
            if (!string.IsNullOrEmpty(settings.MessagingJwtToken))
                builder.Authentication(AuthenticationFactory.Token(settings.MessagingJwtToken));

            return builder.Build();
        });
        return services;
    }
}
