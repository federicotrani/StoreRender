namespace StoreRender.Data.DTOs
{
    public record ProductoDto(
        long Id,
        string Nombre,
        decimal Precio,
        int StockActual,
        int StockMinimo,
        bool Activo
    );
}
