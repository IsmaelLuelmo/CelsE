namespace CelsE.Web.Data
{
    using CelsE.Web.Data.Entity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;

    public class DataContext : IdentityDbContext<UserEntity>
    {
        #region Propiedades
        public DbSet<AlumnoEntity> Alumnos { get; set; }
        public DbSet<ProfesorEntity> Profesor { get; set; }
        public DbSet<ParteEntity> Parte { get; set; }
        public DbSet<UserGroupEntity> GrupoUsuarios { get; set; }
        #endregion

        #region Constructor
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        #endregion

        #region Métodos
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AlumnoEntity>()
                .HasIndex(a => a.DNI)
                .IsUnique();

            builder.Entity<ProfesorEntity>()
                .HasIndex(a => a.DNI)
                .IsUnique();
        }
        #endregion
    }
}
