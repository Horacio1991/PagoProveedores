using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoProv
{
    // esta clase hereda de Pago
    public class PagoCheque : Pago
    {
        // constructor
        public PagoCheque(int codigo, DateTime fechaVencimiento, decimal importe)
            : base(codigo, fechaVencimiento, importe)
        {
        }

        // Calcula el recargo por pago en fuera de fecha, en este caso del 10%
        public override void CalcularRecargo()
        {
            if (DateTime.Now > FechaVencimiento)
            {
                Recargo = Importe * 0.10m; // 10% recargo
            }
            else
            {
                Recargo = 0;
            }
        }

        // Calcula el total a pagar con el recargo incluido
        public override void CalcularTotalAbonado()
        {
            TotalAbonado = Importe + Recargo;
        }
    }

}
