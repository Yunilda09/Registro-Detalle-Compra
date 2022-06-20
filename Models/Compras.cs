using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace DAL
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public String? Descripcion { get; set; }
    
        public DateTime Fecha { get; set; }
        [ForeignKey("CompraId")]

        public List<CompraDetalles> Detalle { get; set; } = new List<CompraDetalles>();

        public double Total { get; set; }

        public override string? ToString()
        {
            return $"Compra: Id={CompraId}, Fecha={Fecha}, Total={Total}";
        }
    }
    /* public Compras()
     {
         CompraId = 0;
         Fecha = DateTime.Now;

         CompraDetalles = new List<CompraDetalles>();
     }*/
}
