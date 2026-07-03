namespace Practica2_Grupo4_PrograAvanzadaWeb.DAL.Entidades;

public partial class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public int FkCategoria { get; set; }

    public virtual Categoria FkCategoriaNavigation { get; set; } = null!;
}