using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend_1.Models
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

        public virtual DbSet<Dodatek> Dodatek { get; set; }
        public virtual DbSet<DodatekKoszyk> DodatekKoszyk { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Koszyk> Koszyk { get; set; }
        public virtual DbSet<PizzaKosz> PizzaKosz { get; set; }
        public virtual DbSet<PizzaMenu> PizzaMenu { get; set; }
        public virtual DbSet<PizzaSklad> PizzaSklad { get; set; }
        public virtual DbSet<PizzaZamowienie> PizzaZamowienie { get; set; }
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

            modelBuilder.Entity<Dodatek>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ilosc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DodatekKoszyk>(entity =>
            {
                entity.ToTable("Dodatek_koszyk");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DodatekId).HasColumnName("Dodatek_Id");

                entity.Property(e => e.KoszykId).HasColumnName("Koszyk_Id");

                entity.HasOne(d => d.Dodatek)
                    .WithMany(p => p.DodatekKoszyk)
                    .HasForeignKey(d => d.DodatekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatek_koszyk_Dodatek");

                entity.HasOne(d => d.Koszyk)
                    .WithMany(p => p.DodatekKoszyk)
                    .HasForeignKey(d => d.KoszykId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatek_koszyk_Koszyk");
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
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PizzaKosz>(entity =>
            {
                entity.ToTable("Pizza_kosz");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.KoszykId).HasColumnName("Koszyk_Id");

                entity.Property(e => e.PizzaZamowienieId).HasColumnName("Pizza_zamowienie_id");

                entity.HasOne(d => d.Koszyk)
                    .WithMany(p => p.PizzaKosz)
                    .HasForeignKey(d => d.KoszykId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_20_Koszyk");

                entity.HasOne(d => d.PizzaZamowienie)
                    .WithMany(p => p.PizzaKosz)
                    .HasForeignKey(d => d.PizzaZamowienieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_20_Pizza_zamowienie");
            });

            modelBuilder.Entity<PizzaMenu>(entity =>
            {
                entity.ToTable("Pizza_menu");

                entity.Property(e => e.Id).ValueGeneratedNever();

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

            modelBuilder.Entity<PizzaSklad>(entity =>
            {
                entity.ToTable("Pizza_sklad");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PizzaZamowienieId).HasColumnName("Pizza_zamowienie_id");

                entity.Property(e => e.SkladDodId).HasColumnName("Sklad_dod_Id");

                entity.HasOne(d => d.PizzaZamowienie)
                    .WithMany(p => p.PizzaSklad)
                    .HasForeignKey(d => d.PizzaZamowienieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_sklad_Pizza_zamowienie");

                entity.HasOne(d => d.SkladDod)
                    .WithMany(p => p.PizzaSklad)
                    .HasForeignKey(d => d.SkladDodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_21_Sklad_dod");
            });

            modelBuilder.Entity<PizzaZamowienie>(entity =>
            {
                entity.ToTable("Pizza_zamowienie");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PizzaMenuId).HasColumnName("Pizza_menu_Id");

                entity.Property(e => e.RozmiarId).HasColumnName("Rozmiar_Id");

                entity.HasOne(d => d.PizzaMenu)
                    .WithMany(p => p.PizzaZamowienie)
                    .HasForeignKey(d => d.PizzaMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_zamowienie_Pizza_menu");

                entity.HasOne(d => d.Rozmiar)
                    .WithMany(p => p.PizzaZamowienie)
                    .HasForeignKey(d => d.RozmiarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_zamowienie_Rozmiar");
            });

            modelBuilder.Entity<Rozmiar>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MnoznikCeny).HasColumnName("Mnoznik_ceny");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkladDod>(entity =>
            {
                entity.ToTable("Sklad_dod");

                entity.Property(e => e.Id).ValueGeneratedNever();

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

                entity.Property(e => e.KoszykId).HasColumnName("Koszyk_Id");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Koszyk)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KoszykId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Koszyk");
            });
        }
    }
}
