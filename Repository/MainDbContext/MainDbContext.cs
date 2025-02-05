using Microsoft.EntityFrameworkCore;
using Model;
namespace Repository.MainDbContext
{
    public partial class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
        public virtual DbSet<FieldOfOperation> FieldOfOperation { get; set; }
        public virtual DbSet<Professionals> Professionals { get; set; }
        public virtual DbSet<ProfessionalsInProjects> ProfessionalsInProjects { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectTasks> ProjectTasks { get; set; }
        public virtual DbSet<TaskFiles> TaskFiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
            .HasMany(e => e.ProfessionalsInProjects)
            .WithOne(e => e.Project)
            .HasForeignKey(e => e.ProjectId)
            .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Project>()
            .HasMany(e => e.ProjectTasks)
            .WithOne(e => e.Project)
            .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<FieldOfOperation>(entity =>
            {
                entity.HasKey(f => f.Id);
            });
            modelBuilder.Entity<Professionals>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(p => p.FieldOfOperation)
                .WithMany(f => f.Professionals)
                .HasForeignKey(p => p.FieldOfOperationCode)
                .HasPrincipalKey(f => f.Code);
            });
            modelBuilder.Entity<ProfessionalsInProjects>(entity =>
        {
            entity.HasKey(p => p.Id);
        });
            modelBuilder.Entity<ProjectTasks>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(p => p.Professional)
                .WithMany(f => f.ProjectTasks)
                .HasForeignKey(p => p.ProfessionalId);
            });
            modelBuilder.Entity<TaskFiles>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.HasOne(tf => tf.ProjectTasks)
                .WithMany(pt => pt.TaskFiles)
                .HasForeignKey(tf => tf.ProjectTaskId);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}