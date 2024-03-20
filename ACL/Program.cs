using ACL;
using ACL.Synchronizers;
using ACL.Synchronizers.Delivery;
using ACL.Synchronizers.Delivery.FromBubbleToLegacy;
using ACL.Synchronizers.Delivery.FromLegacyToBubble;
using ACL.Utils;
using ACL.Workers;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<DeliverySynchronizerWorker>();
builder.Services.AddHostedService<ProductSynchronizerWorker>();

ConnectionStrings connectionStrings = new ConnectionStrings(
    "Server=localhost;Database=PackageDelivery;User Id=packageDelivery;Password=pd;TrustServerCertificate=True;",
    "Server=localhost;Database=PackageDeliveryNew;User Id=packageDelivery;Password=pd;TrustServerCertificate=True;"
);
builder.Services.AddSingleton(connectionStrings);

builder.Services.AddSingleton<DeliverySynchronizer>();
builder.Services.AddSingleton<ProductSynchronizer>();

builder.Services.AddSingleton<FromLegacyToBubbleDeliverySynchronizer>();
builder.Services.AddSingleton<FromBubbleToLegacyDeliverySynchronizer>();

var host = builder.Build();
host.Run();
