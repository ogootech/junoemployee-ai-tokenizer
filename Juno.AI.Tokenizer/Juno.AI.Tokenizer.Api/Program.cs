using Juno.Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.ApplicationLoadBalancer);

var app = builder.Build();
app.UseCustomExceptionHandler(builder.Configuration);
app.UseTransactionMiddleware();
//app.UseTenantEndDateControlMiddleware(builder.Configuration);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
