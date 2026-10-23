using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreRender.Data;
using StoreRender.Data.DTOs;

namespace StoreRender.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly DataContext _context;

    public ProductosController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos()
    {
        return await _context.Productos
            .Select(p => new ProductoDto(
                p.Id,
                p.Nombre,
                p.Precio,
                p.StockActual,
                p.StockMinimo,
                p.Activo
            ))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDto>> GetProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        var productoDto = new ProductoDto(
            producto.Id,
            producto.Nombre,
            producto.Precio,
            producto.StockActual,
            producto.StockMinimo,
            producto.Activo
        );

        return productoDto;
    }

    [HttpPost]
    public async Task<ActionResult<ProductoDto>> PostProducto(ProductoDto productoDto)
    {
        var producto = new StoreRender.Data.Entities.Producto
        {
            Nombre = productoDto.Nombre,
            Precio = productoDto.Precio,
            StockActual = productoDto.StockActual,
            StockMinimo = productoDto.StockMinimo,
            Activo = productoDto.Activo
        };
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, new ProductoDto(
            producto.Id,
            producto.Nombre,
            producto.Precio,
            producto.StockActual,
            producto.StockMinimo,
            producto.Activo
        ));
    }
}
