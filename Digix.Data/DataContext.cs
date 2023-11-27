using Digix.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Digix.Data
{
    public class DataContext : DbContext 
    {

        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext) {

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Family> Families { get; set; }

        public DbSet<FamilyAnalysis> FamilyAnalyses { get; set; }

        public DbSet<AnalysisRules> AnalysisRules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Cpf);

            base.OnModelCreating(modelBuilder);
        }
    }
}

/*
 * dotnet ef migrations add Initial --context DataContext --startup-project .\Digix.Application.csproj --project ..\Digix.Data\ --output-dir ..\Digix.Data\Migrations
 * dotnet ef database update --project ..\Digix.Data\ --startup-project .\Digix.Application.csproj
 * dotnet ef migrations remove --project ..\Digix.Data --startup-project .\Digix.Application.csproj
*/