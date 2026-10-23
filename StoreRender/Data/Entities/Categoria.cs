using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreRender.Data.Entities;

[Table("categorias")]
public class Categoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;
    [Column("activo")]
    public bool Activo { get; set; }
}
