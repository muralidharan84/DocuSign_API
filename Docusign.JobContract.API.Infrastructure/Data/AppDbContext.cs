using Docusign.JobContract.API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Docusign.JobContract.API.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<EnvelopeLog> EnvelopeLog { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EnvelopeLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.EnvelopeId).IsRequired();
                entity.Property(e => e.RecipientEmail).IsRequired();
                entity.Property(e => e.RecipientName).IsRequired();
            });

            builder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Message).IsRequired();
            });
        }
    }
}
