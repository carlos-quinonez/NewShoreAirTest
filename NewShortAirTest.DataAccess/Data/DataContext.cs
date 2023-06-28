using Microsoft.EntityFrameworkCore;
using NewShortAirTest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShortAirTest.DataAccess.Data;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transport> Transport { get; set; }
    public virtual DbSet<Flight> Flight { get; set; }
    public virtual DbSet<Journey> Journey { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
