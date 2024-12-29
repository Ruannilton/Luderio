using Luderia.Infrastructure;
using Luderia.Presentation.Shared.Extensions;

namespace Luderia.Presentation.Shared.Extensions;

public static class Migrations
{
    public static void ApplyMigrations(this WebApplication app)
    {
        app.Services.ApplyMigrations();
    }
}
