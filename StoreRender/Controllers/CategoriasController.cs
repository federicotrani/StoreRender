using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreRender.Data;

namespace StoreRender.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly DataContext _context;

    public CategoriasController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]  
    public IActionResult GetCategorias()
    {
        var categorias = _context.Categorias.ToList();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoria(int id)
    {
        var categoria = _context.Categorias.Find(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

}
