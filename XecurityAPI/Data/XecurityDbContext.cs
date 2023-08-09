using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XecurityAPI.Models;

public partial class XecurityDbContext : DbContext
{
    public XecurityDbContext()
    {
    }

    public XecurityDbContext(DbContextOptions<XecurityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<KeyCard> KeyCards { get; set; }

    public virtual DbSet<KeyCardDataHistory> KeyCardDataHistories { get; set; }

    public virtual DbSet<KeycardServerroom> KeycardServerrooms { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Sensor> Sensors { get; set; }

    public virtual DbSet<SensorType> SensorTypes { get; set; }

    public virtual DbSet<ServerRoom> ServerRooms { get; set; }

    public virtual DbSet<TemperatureDatum> TemperatureData { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-H2F0CAB;Database=XecurityDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3213E83F2147D0EE");

            entity.ToTable("Address");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Addresse)
                .HasMaxLength(1)
                .HasColumnName("addresse");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Postnr).HasColumnName("postnr");

            entity.HasOne(d => d.Company).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Address__company__440B1D61");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3213E83FD076AF81");

            entity.ToTable("Company");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Mail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<KeyCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Key_Card__3213E83F02F1DE05");

            entity.ToTable("Key_Card");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.ExpDate)
                .HasColumnType("datetime")
                .HasColumnName("exp_date");
            entity.Property(e => e.Password)
                .HasMaxLength(1)
                .HasColumnName("password");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.KeyCards)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Key_Card__user_i__3C69FB99");
        });

        modelBuilder.Entity<KeyCardDataHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Key_Card__3213E83F1C0305FC");

            entity.ToTable("Key_Card_Data_History");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateUploaded)
                .HasColumnType("datetime")
                .HasColumnName("date_uploaded");
            entity.Property(e => e.ImageData)
                .HasMaxLength(1)
                .HasColumnName("image_data");
            entity.Property(e => e.KeyCardId).HasColumnName("key_card_id");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status");

            entity.HasOne(d => d.KeyCard).WithMany(p => p.KeyCardDataHistories)
                .HasForeignKey(d => d.KeyCardId)
                .HasConstraintName("FK__Key_Card___key_c__3F466844");
        });

        modelBuilder.Entity<KeycardServerroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Keycard___3213E83F2A7F9D53");

            entity.ToTable("Keycard_Serverroom");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.KeyCardId).HasColumnName("key_card_id");
            entity.Property(e => e.ServerRoomId).HasColumnName("server_room_id");

            entity.HasOne(d => d.KeyCard).WithMany(p => p.KeycardServerrooms)
                .HasForeignKey(d => d.KeyCardId)
                .HasConstraintName("FK__Keycard_S__key_c__5629CD9C");

            entity.HasOne(d => d.ServerRoom).WithMany(p => p.KeycardServerrooms)
                .HasForeignKey(d => d.ServerRoomId)
                .HasConstraintName("FK__Keycard_S__serve__5535A963");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3213E83F9E4E6173");

            entity.ToTable("Location");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .HasColumnName("name");

            entity.HasOne(d => d.Address).WithMany(p => p.Locations)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Location__addres__48CFD27E");
        });

        modelBuilder.Entity<Sensor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sensor__3213E83F71E8D8D8");

            entity.ToTable("Sensor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .HasColumnName("name");
            entity.Property(e => e.SensorTypeId).HasColumnName("sensor_type_id");
            entity.Property(e => e.ServerRoomId).HasColumnName("server_room_id");

            entity.HasOne(d => d.SensorType).WithMany(p => p.Sensors)
                .HasForeignKey(d => d.SensorTypeId)
                .HasConstraintName("FK__Sensor__sensor_t__4F7CD00D");

            entity.HasOne(d => d.ServerRoom).WithMany(p => p.Sensors)
                .HasForeignKey(d => d.ServerRoomId)
                .HasConstraintName("FK__Sensor__server_r__4E88ABD4");
        });

        modelBuilder.Entity<SensorType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sensor_T__3213E83F7AEEA24B");

            entity.ToTable("Sensor_Type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ServerRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Server_R__3213E83F83B6C1C9");

            entity.ToTable("Server_Room");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name).HasMaxLength(1);

            entity.HasOne(d => d.Location).WithMany(p => p.ServerRooms)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Server_Ro__locat__4BAC3F29");
        });

        modelBuilder.Entity<TemperatureDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Temperat__3213E83FF42DF6F2");

            entity.ToTable("Temperature_Data");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateUploaded)
                .HasColumnType("datetime")
                .HasColumnName("date_uploaded");
            entity.Property(e => e.Humidity).HasColumnName("humidity");
            entity.Property(e => e.SensorId).HasColumnName("sensor_id");
            entity.Property(e => e.Temperature).HasColumnName("temperature");

            entity.HasOne(d => d.Sensor).WithMany(p => p.TemperatureData)
                .HasForeignKey(d => d.SensorId)
                .HasConstraintName("FK__Temperatu__senso__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83FA996C257");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(1)
                .HasColumnName("password");
            entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK__User__user_type___398D8EEE");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_Typ__3213E83F410448B2");

            entity.ToTable("User_Type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
