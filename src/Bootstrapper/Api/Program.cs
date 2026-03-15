var builder = WebApplication.CreateBuilder(args);

// Add framework services
builder.Services.AddControllers(); // Add MVC controllers

// Add custom modules BEFORE Build
builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();

app.Run();