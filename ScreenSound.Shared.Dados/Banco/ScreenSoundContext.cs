﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
public class ScreenSoundContext: DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    //private string connectionString = "Server=tcp:screensoundserver.database.windows.net,1433;Initial Catalog=screensoundV0;Persist Security Info=False;User ID=andre;Password=Senh@001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    public ScreenSoundContext()
    {
        
    }
    public ScreenSoundContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musica>()
            .HasMany(c => c.Generos)
            .WithMany(c => c.Musicas);
    }

}
