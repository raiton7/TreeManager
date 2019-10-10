namespace TreeManager.Database
{
    using System;
    using TreeManager.Models;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

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
                .HasMany(e => e.Node1)
                .WithOptional(e => e.Node2)
                .HasForeignKey(e => e.IdParent);
        }
    }
}
