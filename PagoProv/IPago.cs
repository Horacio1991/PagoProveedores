using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoProv
{
    // Esta interfaz define los metodos que todas las clases pago deben implementar
    public interface IPago
    {
        void CalcularRecargo();
        void CalcularTotalAbonado();
    }
}
