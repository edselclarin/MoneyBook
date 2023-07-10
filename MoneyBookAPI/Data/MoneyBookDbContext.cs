using Microsoft.EntityFrameworkCore;

namespace MoneyBookAPI.Data;

public partial class MoneyBookDbContext : DbContext
{
    private readonly string m_connStr;

    protected MoneyBookDbContext(string connStr)
    {
        m_connStr = connStr;
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Institution> Institutions { get; set; }

    public virtual DbSet<RecurringTransaction> RecurringTransactions { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public static MoneyBookDbContext Create(IDbContextConfig config)
    {
        return new MoneyBookDbContext(config.ConnectionStr);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(m_connStr);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AcctId).HasName("PK__Accounts__402CCBFC2A13C66B");

            entity.Property(e => e.AcctType)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('SAVINGS')");
            entity.Property(e => e.AcctTypeId).HasDefaultValueSql("((1))");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DateModified)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ExtAcctId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ImportFilePath)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('ACCT')");
            entity.Property(e => e.ReserveAmount)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StartingBalance)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TypeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('New AccountType')");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Categori__6A1C8AFA9395F6F3");

            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('New Category')");
        });

        modelBuilder.Entity<Institution>(entity =>
        {
            entity.HasKey(e => e.InstId).HasName("PK__Institut__E2A296864CF9F9AC");

            entity.Property(e => e.InstType)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('BANK')");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('New Institution')");
        });

        modelBuilder.Entity<RecurringTransaction>(entity =>
        {
            entity.HasKey(e => e.RecTrnsId).HasName("PK__Recurrin__E1F61105186A02E7");

            entity.Property(e => e.Amount)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DateModified)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DueDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Frequency)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('Once')");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Memo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Payee)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.TrnsType)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValueSql("('DEBIT')");
            entity.Property(e => e.Website)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TrnsId).HasName("PK__Transact__0342342179183072");

            entity.Property(e => e.Amount)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DateModified)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.ExtTrnsId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Memo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Payee)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.RefNum)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.State)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('Uncleared')");
            entity.Property(e => e.TrnsType)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValueSql("('DEBIT')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
