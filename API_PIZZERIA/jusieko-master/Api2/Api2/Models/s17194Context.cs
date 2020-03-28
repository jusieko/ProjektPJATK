using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api2.Models
{
    public partial class s17194Context : DbContext
    {
        public s17194Context()
        {
        }

        public s17194Context(DbContextOptions<s17194Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dodatki> Dodatki { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Koszyk> Koszyk { get; set; }
        public virtual DbSet<Napoje> Napoje { get; set; }
        public virtual DbSet<PizzaMenu> PizzaMenu { get; set; }
        public virtual DbSet<PizzaZam> PizzaZam { get; set; }
        public virtual DbSet<Przekaski> Przekaski { get; set; }
        public virtual DbSet<Rozmiar> Rozmiar { get; set; }
        public virtual DbSet<SkladDod> SkladDod { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17194;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Dodatki>(entity =>
            {
                entity.HasKey(e => e.IdDod)
                    .HasName("Dodatki_pk");

                entity.Property(e => e.IdDod)
                    .HasColumnName("Id_dod")
                    .ValueGeneratedNever();

                entity.Property(e => e.NapojeIdNap).HasColumnName("Napoje_Id_nap");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrzekaskiIdPrzek).HasColumnName("Przekaski_Id_przek");

                entity.HasOne(d => d.NapojeIdNapNavigation)
                    .WithMany(p => p.Dodatki)
                    .HasForeignKey(d => d.NapojeIdNap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatki_Napoje");

                entity.HasOne(d => d.PrzekaskiIdPrzekNavigation)
                    .WithMany(p => p.Dodatki)
                    .HasForeignKey(d => d.PrzekaskiIdPrzek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatki_Przekaski");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("PK__EMP__14CCF2EE0F7B4C68");

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<Koszyk>(entity =>
            {
                entity.HasKey(e => e.IdKosz)
                    .HasName("Koszyk_pk");

                entity.Property(e => e.IdKosz)
                    .HasColumnName("Id_kosz")
                    .ValueGeneratedNever();

                entity.Property(e => e.DodatkiIdDod).HasColumnName("Dodatki_Id_dod");

                entity.Property(e => e.PizzaIdPizz).HasColumnName("Pizza_Id_pizz");

                entity.HasOne(d => d.DodatkiIdDodNavigation)
                    .WithMany(p => p.Koszyk)
                    .HasForeignKey(d => d.DodatkiIdDod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Koszyk_Dodatki");

                entity.HasOne(d => d.PizzaIdPizzNavigation)
                    .WithMany(p => p.Koszyk)
                    .HasForeignKey(d => d.PizzaIdPizz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Koszyk_Pizza");
            });

            modelBuilder.Entity<Napoje>(entity =>
            {
                entity.HasKey(e => e.IdNap)
                    .HasName("Napoje_pk");

                entity.Property(e => e.IdNap)
                    .HasColumnName("Id_nap")
                    .ValueGeneratedNever();

                entity.Property(e => e.ObjetoscMl).HasColumnName("Objetosc_ml");
            });

            modelBuilder.Entity<PizzaMenu>(entity =>
            {
                entity.HasKey(e => e.IdMen)
                    .HasName("Pizza_menu_pk");

                entity.ToTable("Pizza_menu");

                entity.Property(e => e.IdMen)
                    .HasColumnName("Id_men")
                    .ValueGeneratedNever();

                entity.Property(e => e.ListaSkladnikow)
                    .IsRequired()
                    .HasColumnName("Lista_skladnikow")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaZam>(entity =>
            {
                entity.HasKey(e => e.IdPizz)
                    .HasName("Id_pizz");

                entity.ToTable("Pizza_zam");

                entity.Property(e => e.IdPizz)
                    .HasColumnName("Id_pizz")
                    .ValueGeneratedNever();

                entity.Property(e => e.PizzaMenuIdMen).HasColumnName("Pizza_menu_Id_men");

                entity.Property(e => e.RozmiarIdRoz).HasColumnName("Rozmiar_Id_roz");

                entity.Property(e => e.SkladDodIdSklad).HasColumnName("Sklad_dod_Id_sklad");

                entity.HasOne(d => d.PizzaMenuIdMenNavigation)
                    .WithMany(p => p.PizzaZam)
                    .HasForeignKey(d => d.PizzaMenuIdMen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_zam_Pizza_menu");

                entity.HasOne(d => d.RozmiarIdRozNavigation)
                    .WithMany(p => p.PizzaZam)
                    .HasForeignKey(d => d.RozmiarIdRoz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Rozmiar");

                entity.HasOne(d => d.SkladDodIdSkladNavigation)
                    .WithMany(p => p.PizzaZam)
                    .HasForeignKey(d => d.SkladDodIdSklad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Sklad_dod");
            });

            modelBuilder.Entity<Przekaski>(entity =>
            {
                entity.HasKey(e => e.IdPrzek)
                    .HasName("Przekaski_pk");

                entity.Property(e => e.IdPrzek)
                    .HasColumnName("Id_przek")
                    .ValueGeneratedNever();

                entity.Property(e => e.IloscSzt).HasColumnName("Ilosc_szt");
            });

            modelBuilder.Entity<Rozmiar>(entity =>
            {
                entity.HasKey(e => e.IdRoz)
                    .HasName("Id_roz");

                entity.Property(e => e.IdRoz)
                    .HasColumnName("Id_roz")
                    .ValueGeneratedNever();

                entity.Property(e => e.MnoznikCeny).HasColumnName("Mnoznik_ceny");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkladDod>(entity =>
            {
                entity.HasKey(e => e.IdSklad)
                    .HasName("Sklad_dod_pk");

                entity.ToTable("Sklad_dod");

                entity.Property(e => e.IdSklad)
                    .HasColumnName("Id_sklad")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZam)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZam)
                    .HasColumnName("Id_zam")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KoszykIdKosz).HasColumnName("Koszyk_Id_kosz");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.KoszykIdKoszNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KoszykIdKosz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Koszyk");
            });
        }
    }
}
