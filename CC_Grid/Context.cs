using Microsoft.EntityFrameworkCore;

namespace CC_Grid
{
    public class Context : DbContext
  {
    public DbSet<Circuit> Circuit { get; set; }

    public DbSet<Measure> Measure { get; set; }

    public DbSet<HistoryCircuit> HistoryCircuit { get; set; }

    public DbSet<Configuration> Configuration { get; set; }

    public DbSet<Battery> Battery {get; set;}

    public DbSet<Operation> Operation {get; set;}

    public DbSet<HistoryBattery> HistoryBattery {get; set;}



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("server=localhost;database=CC_Grid;user=tulio;password=tulio");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Circuit>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Name).IsRequired();
      });

      modelBuilder.Entity<HistoryBattery>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Datetime).IsRequired();
        entity.Property(e => e.State).IsRequired();
        entity.Property(e => e.StateCurrent).IsRequired();
        entity.Property(e => e.StatePower).IsRequired();
      });

       modelBuilder.Entity<Operation>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Datetime).IsRequired();
        entity.Property(e => e.PriorityLevel).IsRequired();
        entity.Property(e => e.Status).IsRequired();
        entity.Property(e => e.GeneralInfo).IsRequired();
      });

      modelBuilder.Entity<Measure>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd(); // inserido
        entity.Property(e => e.VoltagePhaseA).IsRequired();
        entity.Property(e => e.VoltagePhaseB).IsRequired();
        entity.Property(e => e.VoltagePhaseC).IsRequired();
        entity.Property(e => e.CurrentPhaseA).IsRequired();
        entity.Property(e => e.CurrentPhaseB).IsRequired();
        entity.Property(e => e.CurrentPhaseC).IsRequired();
        entity.Property(e => e.PowerFactor_A).IsRequired();
        entity.Property(e => e.PowerFactor_B).IsRequired();
        entity.Property(e => e.PowerFactor_C).IsRequired();
        entity.Property(e => e.ReactivePower).IsRequired();
        entity.Property(e => e.ActivePower).IsRequired();
        entity.Property(e => e.Datetime).IsRequired();
        entity.HasOne(d => d.Circuit)
          .WithMany(p => p.Measures);
      });

      modelBuilder.Entity<HistoryCircuit>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd(); // inserido
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Datetime).IsRequired();
        entity.Property(e => e.Action).IsRequired();
        entity.HasOne(d => d.Circuit)
          .WithMany(p => p.HistoryCircuits);
      });

      modelBuilder.Entity<Configuration>(entity =>
      {
        entity.Property(e => e.MinTimeAutonomy).IsRequired();
        entity.Property(e => e.StartComutationOFF_On).IsRequired();
        entity.Property(e => e.StartComutationOn_Off).IsRequired();
        entity.HasKey(e => e.Level_1_Shutdown);
        entity.Property(e => e.Level_2_Shutdown).IsRequired();
        entity.Property(e => e.Level_3_Shutdown).IsRequired();
        entity.Property(e => e.Level_4_Shutdown).IsRequired();
      });

       modelBuilder.Entity<Battery>(entity =>
      {
        entity.Property(e => e.ChargePower).IsRequired();
        entity.Property(e => e.DischargePower).IsRequired();
        entity.Property(e => e.Technology).IsRequired();
        entity.Property(e => e.ChargeCurrent).IsRequired();
        entity.HasKey(e => e.DepthOfCharge);
        entity.Property(e => e.DischargeCurrent).IsRequired();
      });

      
    }
  }
}