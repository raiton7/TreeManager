namespace TreeManager.Database
{
    using TreeManager.Models;
    using System.Data.Entity;

    public partial class NodeContext : DbContext
    {
        public NodeContext()
            : base("name=Node")
        {
        }

        public virtual DbSet<Node> Node { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasMany(e => e.ChildNodes)
                .WithOptional(e => e.Node2)
                .HasForeignKey(e => e.IdParent);
        }
    }
}
