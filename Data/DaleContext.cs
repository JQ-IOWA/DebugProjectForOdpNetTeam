using Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
  public class DaleContext : DbContext
  {
    public DaleContext()
    {
      ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DaleContext(DbContextOptions options) : base(options)
    {
      ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<BookingBlock> BookingBlocks { get; set; }
    public DbSet<CustomerGroup> CustomerGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //leaving this for now to use for direct db integration/validation in unit test
      if (!optionsBuilder.IsConfigured)
      {
        //if this does remain, then pull data source string from json file where it's NOT stored in git
        optionsBuilder
          .UseLoggerFactory(ConsoleLoggerFactory)
          .UseOracle("Data Source = xxxxx"
          , b => b.UseOracleSQLCompatibility("11"));
      }
    }

    public static readonly ILoggerFactory ConsoleLoggerFactory =
      LoggerFactory.Create(builder =>
      {
        builder.AddFilter((category, level) =>
          category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information).AddConsole();
      });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<BookingBlock>().ToTable("PDF_BOOKING_BLOCK");
      modelBuilder.Entity<CustomerGroup>().ToTable("PDF_CUST_GROUP");

    //tables w/ composite keys
      modelBuilder.Entity<BookingBlock>()
          .HasKey(pk => new { pk.RPTNG_FLOW_PATH_ID, pk.CUST_GROUP_IDFTN });

    }
  }
}
