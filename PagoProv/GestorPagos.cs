using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoProv
{
    public class GestorPagos
    {
        public List<Proveedor> Proveedores { get; set; }
        public List<Pago> Pagos { get; set; }

        public GestorPagos()
        {
            Proveedores = new List<Proveedor>();
            Pagos = new List<Pago>();
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                Proveedores.Add(proveedor);
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al agregar proveedor: " + ex.Message);
            }
        }

        public void ModificarProveedor(Proveedor proveedor)
        {
            try
            {
                var prov = Proveedores.FirstOrDefault(p => p.Legajo == proveedor.Legajo);
                if (prov != null)
                {
                    prov.Nombre = proveedor.Nombre;
                }
                else
                {
                    Console.WriteLine("Proveedor no encontrado");
                }
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al modificar proveedor: " + ex.Message);
            }
        }

        public void EliminarProveedor(int legajo)
        {
            try
            {
                var proveedor = Proveedores.FirstOrDefault(p => p.Legajo == legajo);
                if (proveedor != null)
                {
                    Proveedores.Remove(proveedor);
                }
                else
                {
                    Console.WriteLine("Proveedor no encontrado");
                }
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al eliminar proveedor: " + ex.Message);
            }
        }

        public void RealizarPago(Pago pago)
        {
            try
            {
                pago.CalcularRecargo();
                pago.CalcularTotalAbonado();
                Pagos.Add(pago);
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al realizar el pago: " + ex.Message);
            }
        }
    }

}
