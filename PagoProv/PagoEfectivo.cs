using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoProv
{
    // Esta clase hereda de Pago
    public class PagoEfectivo : Pago
    {
        // constructor
        public PagoEfectivo(int codigo, DateTime fechaVencimiento, decimal importe)
            : base(codigo, fechaVencimiento, importe)
        {
        }

        // calcular el recargo dl 10% si la fecha de hoy es despues que la del vencimiento
        public override void CalcularRecargo()
        {
            if (DateTime.Now > FechaVencimiento)
            {
                Recargo = Importe * 0.01m; 
            }
            else
            {
                Recargo = 0;
            }
        }

        // suma el recargo para calcular el total a pagar
        public override void CalcularTotalAbonado()
        {
            TotalAbonado = Importe + Recargo;
        }
    }

}
