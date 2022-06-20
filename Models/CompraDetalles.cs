using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CompraDetalles
    {
       
        public int CompraDetallesId { get; set; }
        public int ProductoId { get; set; }
        public int CompraId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la Descripcion")]
        public String? Descripcion { get; set; }
        public decimal Costo { get; set; }

        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
        public int MyProperty { get; set; }
        
        public CompraDetalles()
        {
            this.CompraDetallesId = 0;
            this.ProductoId = 0;
            this.Descripcion = "";
            this.Costo = 0;
            this.Cantidad = 0;
            this.Importe = 0;
        }
        public CompraDetalles(string descripcion, decimal costo, int cantidad, decimal importe)
        {
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.Cantidad = cantidad;
            this.Importe = importe;
        }
    }




}