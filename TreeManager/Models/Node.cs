namespace TreeManager.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
        [Required, Display(Name = "Nazwa"), MinLength(2, ErrorMessage = "D³ugoœæ nazwy musi byæ wiêksza lub równa 2")]
        public string Value { get; set; }

        [Display(Name = "ID Rodzica")]
        public int? IdParent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Node> ChildNodes { get; set; }

        public virtual Node Node2 { get; set; }
    }
}
