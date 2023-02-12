using ChallengeTecnicoEngee.Crosscutting.Extensions;
using ChallengeTecnicoEngee.Domain.Entities;
using Domain.Entities;
using Domain.Entities.EntityBases;
using Domain.Interfaces.Entities;
using Infraestructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetOnDeleteBehavior(modelBuilder, DeleteBehavior.Restrict);
            AddSoftDeleteQueryFilter(modelBuilder);
            base.OnModelCreating(modelBuilder);

            BuildLogVistaModel(modelBuilder);
            BuildEmpleadoModel(modelBuilder);

            AddInitialDataSets(modelBuilder);
        }

        #region DATA SETS

        public DbSet<LogVisita> LogsVisitas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sector> Sectores { get; set; }

        #endregion

        #region DATA SETS CONFIGURATION

        private static void BuildLogVistaModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogVisita>()
                .Property(e => e.NombresVisitante)
                .IsRequired();

            modelBuilder.Entity<LogVisita>()
                .Property(e => e.ApellidosVisitante)
                .IsRequired();

            modelBuilder.Entity<LogVisita>()
                .Property(e => e.NumeroDocumentoVisitante)
                .IsRequired();

            modelBuilder.Entity<LogVisita>()
                .Property(e => e.SectorId)
                .IsRequired();

            modelBuilder.Entity<LogVisita>()
                .HasOne(e => e.Sector)
                .WithMany()
                .HasForeignKey(x => x.SectorId);
        }
        private static void BuildEmpleadoModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Nombres)
                .IsRequired();

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Apellidos)
                .IsRequired();

            modelBuilder.Entity<Empleado>()
                .HasOne(x => x.Sector)
                .WithMany(x => x.Empleados)
                .HasForeignKey(x => x.SectorId);
        }

        #endregion

        #region INITIAL DATA SETS

        private void AddInitialDataSets(ModelBuilder modelBuilder)
        {
            InitialDataSectores(modelBuilder);
            InitialDataEmpleados(modelBuilder);
        }
        private static void InitialDataSectores(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sector>().HasData(
                new List<Sector>()
                {
                    new Sector
                    {
                        Id = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.QA,
                        Descripcion = ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.QA.GetDescription(),
                        Codigo = "QA",
                        Activo = true
                    },
                    new Sector
                    {
                        Id = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH,
                        Descripcion = ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH.GetDescription(),
                        Codigo = "RRHH",
                        Activo = true
                    },
                    new Sector
                    {
                        Id = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.COMME,
                        Descripcion = ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.COMME.GetDescription(),
                        Codigo = "COMME",
                        Activo = true
                    },
                    new Sector
                    {
                        Id = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.HQ,
                        Descripcion = ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.HQ.GetDescription(),
                        Codigo = "HQ",
                        Activo = true
                    }
                });
        }
        private static void InitialDataEmpleados(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasData(
                new List<Empleado>
                {
                    new Empleado
                        { Id = 1, Nombres = "Daniel", Apellidos = "de Almeida", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH },
                    new Empleado
                        { Id = 2, Nombres = "Dario", Apellidos = "Riva", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.QA },
                    new Empleado
                        { Id = 3, Nombres = "Diego", Apellidos = "Pellegrini", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.COMME },
                    new Empleado
                        { Id = 4, Nombres = "Federico", Apellidos = "Musso", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH },
                    new Empleado
                        { Id = 5, Nombres = "Laura", Apellidos = "Rodriguez", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.QA },
                    new Empleado
                        { Id = 6, Nombres = "Lautaro Ariel", Apellidos = "Basanta", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.COMME },
                    new Empleado
                        { Id = 7, Nombres = "Manuel", Apellidos = "Castello", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH },
                    new Empleado
                        { Id = 8, Nombres = "Paula", Apellidos = "Barrios", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.QA },
                    new Empleado
                        { Id = 9, Nombres = "Rocio", Apellidos = "Diaz", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.COMME },
                    new Empleado
                        { Id = 10, Nombres = "Sebastian", Apellidos = "Parasis", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH },
                    new Empleado
                        { Id = 11, Nombres = "Walter", Apellidos = "Marcote", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.QA },
                    new Empleado
                        { Id = 12, Nombres = "Guillermo", Apellidos = "Balcarcel", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.COMME },
                    new Empleado
                        { Id = 13, Nombres = "Esteban", Apellidos = "Gawron", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH },
                    new Empleado
                        { Id = 14, Nombres = "Enzo", Apellidos = "Peddini", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH },
                    new Empleado
                        { Id = 15, Nombres = "Andrea", Apellidos = "Russo", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.COMME },
                    new Empleado
                        { Id = 16, Nombres = "Adrian", Apellidos = "Zarate", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH },
                    new Empleado
                        { Id = 17, Nombres = "Melisa", Apellidos = "Yune", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.QA },
                    new Empleado
                        { Id = 18, Nombres = "Nicolas", Apellidos = "Russmann", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.COMME },
                    new Empleado
                        { Id = 19, Nombres = "Galo", Apellidos = "Trillo", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.RRHH },
                    new Empleado
                        { Id = 20, Nombres = "Diego", Apellidos = "Pellegrini", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.QA },
                    new Empleado
                        { Id = 21, Nombres = "Horus, 'El Architraidor'", Apellidos = "Lupercal", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.HQ },
                    new Empleado
                        { Id = 22, Nombres = "Leman, 'El Rey Lobo'", Apellidos = "Russ", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.HQ },
                    new Empleado
                        { Id = 23, Nombres = "Robute, 'El Maestro de Ultramar'", Apellidos = "Guilliman", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.HQ },
                    new Empleado
                        { Id = 24, Nombres = "Lion, 'La Bestia'", Apellidos = "El'Jhonson", Activo = true, SectorId = (long)ChallengeTecnicoEngee.Crosscutting.Enums.Sectores.HQ },
                });
        }

        #endregion

        #region DATA CONFIGURATION

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            entryStateHandler();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void entryStateHandler()
        {
            DateTime timestamp = DateTime.Now.ToLocalTime();

            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                bool hasSoftDelete = entry.Entity is ISoftDelete;
                bool hasAudit = entry.Entity is IAuditable;

                switch (entry.State)
                {
                    case EntityState.Deleted:
                        DeleteSoftDeleteAuditableEntity(timestamp, entry, hasSoftDelete, hasAudit);
                        break;
                    case EntityState.Modified:
                        ModifySoftDeleteAuditableEntity(timestamp, entry, hasSoftDelete, hasAudit);
                        break;
                    case EntityState.Added:
                        AddSoftDeleteAuditableEntity(timestamp, entry, hasSoftDelete, hasAudit);
                        break;
                }
            }
        }
        private static void AddSoftDeleteQueryFilter(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes()
                .Where(e =>
                    (typeof(ISoftDelete).IsAssignableFrom(e.ClrType) && e.ClrType != null && e.BaseType == null)
                    || e.BaseType is EntityBase
                    || e.BaseType is TypeBase
                    )
                )
            {
                entityType.AddSoftDeleteQueryFilter();
            }
        }
        private static void SetOnDeleteBehavior(ModelBuilder builder, DeleteBehavior deleteBehavior)
        {
            var cascadeFKs = builder.Model.GetEntityTypes()
                            .SelectMany(t => t.GetForeignKeys())
                            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = deleteBehavior;
            }
        }

        #endregion

        #region AUDIT PROPERTIES

        private static void AddSoftDeleteAuditableEntity(DateTime timestamp, EntityEntry entry, bool hasSoftDelete, bool hasAudit)
        {
            if (hasSoftDelete)
                entry.CurrentValues["Activo"] = true;
            if (hasAudit)
                entry.CurrentValues["FechaAlta"] = timestamp;
        }
        private static void ModifySoftDeleteAuditableEntity(DateTime timestamp, EntityEntry entry, bool hasSoftDelete, bool hasAudit)
        {
            if (hasSoftDelete)
                entry.CurrentValues["Activo"] = true;
            if (hasAudit)
                entry.CurrentValues["FechaModificacion"] = timestamp;
        }
        private static void DeleteSoftDeleteAuditableEntity(DateTime timestamp, EntityEntry entry, bool hasSoftDelete, bool hasAudit)
        {
            if (hasSoftDelete)
                entry.CurrentValues["Activo"] = false;
            if (hasAudit)
                entry.CurrentValues["FechaEliminacion"] = timestamp;
        }

        #endregion
    }
}
