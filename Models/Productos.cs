using System.ComponentModel.DataAnnotations;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }
    public String? Descripcion { get; set; }
    public decimal Costo { get; set; }
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public double Existencia { get; set; }
}

public class Categorias
{
    [Key]
    public int CategoriaId { get; set; }
    public String? Descripcion { get; set;}
}