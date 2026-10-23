using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreRender.Data.Entities;

[Table("productos")]
public class Producto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }
    [MaxLength(100)]
    [Column("nombre")]
    [Required]
    public string Nombre { get; set; } = string.Empty;
    [Column("precio")]
    [Precision(18, 2)]
    public decimal Precio { get; set; }
    [Column("stock_actual")]
    public int StockActual { get; set; }
    [Column("stock_minimo")]
    public int StockMinimo { get; set; }
    [Column("activo")]
    public bool Activo { get; set; }
    [ForeignKey("Categoria")]
    [Column("categoria_id")]
    public int? CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}
