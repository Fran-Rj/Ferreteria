using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        private void Mostrar()
        {
            using (ferreteriaEntities db = new ferreteriaEntities())
            {
                var list = from product in db.Herramienta
                           select product;
                ListaHerramientas.DataSource = list.ToList();
            }
        }

        private void ClearInformation()
        {
            txtName.Clear();
            txtPrecio.Clear();
            txtMarca.Clear();
            txtExist.Clear();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ferreteriaEntities db = new ferreteriaEntities())
                {
                    Herramienta herramienta = new Herramienta();

                    herramienta.nombre = txtName.Text;       
                    herramienta.precio = decimal.Parse(txtPrecio.Text);
                    herramienta.marca = txtMarca.Text;
                    herramienta.existencias = int.Parse(txtExist.Text);
    

                    db.Herramienta.Add(herramienta);
                    db.SaveChanges();

                    ClearInformation();
                    MessageBox.Show("Registro agregado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los campos no pueden quedar vacios!");
            }

            Mostrar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
