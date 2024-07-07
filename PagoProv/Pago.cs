using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoProv
{
    // Esta clase recibe la interfaz
    public abstract class Pago : IPago
    {
        // propiedades
        public int Codigo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public decimal Recargo { get; protected set; }
        public decimal TotalAbonado { get; protected set; }

        // constructor
        public Pago(int codigo, DateTime fechaVencimiento, decimal importe)
        {
            Codigo = codigo;
            FechaVencimiento = fechaVencimiento;
            Importe = importe;
        }

        // metodos abstractos
        public abstract void CalcularRecargo();
        public abstract void CalcularTotalAbonado();
    }

}
