namespace TestWebApi;

public static class Extensions
{
    public static IApplicationBuilder ApplyDevelopmentMiddleware(this IApplicationBuilder webApplication)
    {
        return webApplication.UseExceptionHandler("/error").UseSwagger().UseSwaggerUI();
    }
}