using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PagoProv
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Lista donde se van a ir guardando los proveedores
        private List<Proveedor> proveedores;
        // Este diccionario va a mapear el legajo de un proveedor con una lista de deudas
        private Dictionary<int, List<Pago>> deudasPorProveedor;

        public MainWindow()
        {
            InitializeComponent();
            // Llama al método que va a crear los proveedores y deudas para ejemplificar
            InicializarProveedoresYDeudas();
            // Se llena la grid de proveedores con la lista de proveedores
            dgProveedores.ItemsSource = proveedores;
            // a los botones del ABM se le asocia los eventos click
            btnAgregar.Click += btnAgregar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void InicializarProveedoresYDeudas()
        {
            // Crear proveedores
            proveedores = new List<Proveedor>
            {
                new Proveedor(1, "Fibertel"),
                new Proveedor(2, "Telecentro"),
                new Proveedor(3, "Movistar"),
                new Proveedor(4, "Claro")
            };

            // Crear deudas por proveedor (Para ejemplo)
            deudasPorProveedor = new Dictionary<int, List<Pago>>
            {
                { 1, new List<Pago>
                    {
                        new PagoEfectivo(101, DateTime.Now.AddDays(-10), 1000m), // Deuda vencida
                        new PagoCheque(102, DateTime.Now.AddDays(5), 2000m) // Deuda no vencida
                    }
                },
                { 2, new List<Pago>
                    {
                        new PagoEfectivo(201, DateTime.Now.AddDays(-5), 1500m), // Deuda vencida
                        new PagoCheque(202, DateTime.Now.AddDays(10), 2500m) // Deuda no vencida
                    }
                },
                { 3, new List<Pago>
                    {
                        new PagoEfectivo(301, DateTime.Now.AddDays(-1), 3000m), // Deuda vencida
                        new PagoCheque(302, DateTime.Now.AddDays(15), 3500m) // Deuda no vencida
                    }
                },
                { 4, new List<Pago>
                    {
                        new PagoEfectivo(401, DateTime.Now.AddDays(-7), 4000m), // Deuda vencida
                        new PagoCheque(402, DateTime.Now.AddDays(20), 4500m) // Deuda no vencida
                    }
                }
            };
        }

        // Este método se ejecuta cuando se selecciona a un proveedor de la lista y muestra las deudas que pueda tener
        private void dgProveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProveedores.SelectedItem is Proveedor proveedorSeleccionado)
            {
                dgPagos.ItemsSource = deudasPorProveedor[proveedorSeleccionado.Legajo];
                dgPagos.Items.Refresh();

                // Mostrar los datos del proveedor seleccionado en los campos de texto
                txtLegajo.Text = proveedorSeleccionado.Legajo.ToString();
                txtNombre.Text = proveedorSeleccionado.Nombre;
            }
        }

        // Evento de clic en botón Pagar en Efectivo
        private void btnEfectivo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Verificar si se seleccionó un pago
                if (dgPagos.SelectedItem is Pago pagoSeleccionado)
                {
                    // Crear nuevo pago en efectivo y calcular recargo y total abonado
                    var nuevoPago = new PagoEfectivo(pagoSeleccionado.Codigo, pagoSeleccionado.FechaVencimiento, pagoSeleccionado.Importe);
                    nuevoPago.CalcularRecargo();
                    nuevoPago.CalcularTotalAbonado();

                    // Actualizar el pago en la lista de deudas del proveedor
                    ActualizarPagoEnLista(pagoSeleccionado, nuevoPago);
                }
                else
                {
                    MessageBox.Show("Seleccione un pago para realizar la operación.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago en efectivo: {ex.Message}");
            }
        }

        // Evento de clic en botón Pagar con Cheque
        private void btnCheque_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Verificar si se seleccionó un pago
                if (dgPagos.SelectedItem is Pago pagoSeleccionado)
                {
                    // Crear nuevo pago con cheque y calcular recargo y total abonado
                    var nuevoPago = new PagoCheque(pagoSeleccionado.Codigo, pagoSeleccionado.FechaVencimiento, pagoSeleccionado.Importe);
                    nuevoPago.CalcularRecargo();
                    nuevoPago.CalcularTotalAbonado();

                    // Actualizar el pago en la lista de deudas del proveedor
                    ActualizarPagoEnLista(pagoSeleccionado, nuevoPago);
                }
                else
                {
                    MessageBox.Show("Seleccione un pago para realizar la operación.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago con cheque: {ex.Message}");
            }
        }

        // Captura las deudas del proveedor seleccionado y actualiza la grilla con los valores correspondientes
        private void ActualizarPagoEnLista(Pago pagoAnterior, Pago nuevoPago)
        {
            try
            {
                if (dgProveedores.SelectedItem is Proveedor proveedorSeleccionado)
                {
                    var listaPagos = deudasPorProveedor[proveedorSeleccionado.Legajo];
                    var indice = listaPagos.IndexOf(pagoAnterior);
                    if (indice != -1)
                    {
                        listaPagos[indice] = nuevoPago;
                        dgPagos.ItemsSource = null;
                        dgPagos.ItemsSource = listaPagos;
                        dgPagos.Items.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el pago: {ex.Message}");
            }
        }

        // Botón para agregar proveedor a lista y después refrescar la grilla con los nuevos valores de la lista
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int legajo;
                if (int.TryParse(txtLegajo.Text, out legajo) && !string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    Proveedor nuevoProveedor = new Proveedor(legajo, txtNombre.Text);
                    proveedores.Add(nuevoProveedor);
                    deudasPorProveedor[legajo] = new List<Pago>();
                    dgProveedores.Items.Refresh();

                    // Limpiar los campos de texto después de agregar
                    txtLegajo.Text = "";
                    txtNombre.Text = "";
                }
                else
                {
                    MessageBox.Show("Ingrese un legajo y nombre válidos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el proveedor: {ex.Message}");
            }
        }

        // Botón para modificar proveedor a lista y después refrescar la grilla con los nuevos valores de la lista
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProveedores.SelectedItem is Proveedor proveedorSeleccionado)
                {
                    int legajo;
                    if (int.TryParse(txtLegajo.Text, out legajo) && !string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        proveedorSeleccionado.Legajo = legajo;
                        proveedorSeleccionado.Nombre = txtNombre.Text;
                        dgProveedores.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un legajo y nombre válidos.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un proveedor para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el proveedor: {ex.Message}");
            }
        }

        // Botón para eliminar proveedor a lista y después refrescar la grilla con los nuevos valores de la lista
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProveedores.SelectedItem is Proveedor proveedorSeleccionado)
                {
                    proveedores.Remove(proveedorSeleccionado);
                    deudasPorProveedor.Remove(proveedorSeleccionado.Legajo);
                    dgProveedores.Items.Refresh();
                    dgPagos.ItemsSource = null;
                }
                else
                {
                    MessageBox.Show("Seleccione un proveedor para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}");
            }
        }
    }
}


