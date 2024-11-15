using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TVShowsAPI.Data.Models;

public partial class TVShowDataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public TVShowDataContext ( )
    {
    }

    public TVShowDataContext ( DbContextOptions<TVShowDataContext> options , IConfiguration configuration )
        : base ( options )
    {
        _configuration = configuration;
    }

    public virtual DbSet<TvShow> TvShows { get; set; }

    // protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder ) => optionsBuilder.UseSqlServer ( "Data Source=LAPTOP-63IP0I8H;Initial Catalog=TVShowData;Integrated Security=True" );

    protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
    {
        if (optionsBuilder.IsConfigured)
        {
            // Obtén la cadena de conexión desde IConfiguration
            var connectionString = _configuration.GetConnectionString ( "DefaultConnection" );
            optionsBuilder.UseSqlServer ( connectionString );
        }
    }

    protected override void OnModelCreating ( ModelBuilder modelBuilder )
    {
        modelBuilder.Entity<TvShow> ( entity =>
        {
            entity.HasKey ( e => e.Id ).HasName ( "PK__TvShows__3214EC0763762B10" );
        } );

        OnModelCreatingPartial ( modelBuilder );
    }

    partial void OnModelCreatingPartial ( ModelBuilder modelBuilder );
}