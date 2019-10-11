namespace TreeManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Node")]
    public partial class Node
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Node()
        {
            ChildNodes = new HashSet<Node>();
        }

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Nazwa")]
        public string Value { get; set; }

        [Display(Name = "ID Rodzica")]
        public int? IdParent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Node> ChildNodes { get; set; }

        public virtual Node Node2 { get; set; }
    }
}
