var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

// Add framework services
builder.Services.AddControllers(); // Add MVC controllers


builder.Services.AddCarterWithAssemblies(typeof(CatalogModule).Assembly);

// Add custom modules BEFORE Build
builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();
app.UseSerilogRequestLogging();
app.UseExceptionHandler(options => { });

app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();


app.Run();