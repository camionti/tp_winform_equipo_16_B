using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using Conexion2;
using Conexion2;
using Conexion;


namespace Actividad2
{
    public partial class Form1 : Form
    {
        public List<Articulo> listaArticulo;
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            Conexion.ConexionArticulo conexio = new Conexion.ConexionArticulo();
            listaArticulo = conexio.Listar();
            DGVArticulos.DataSource = listaArticulo;
            DGVArticulos.Columns["Id"].Visible = false;
            DGVArticulos.Columns["IdCategoria"].Visible = false;
            DGVArticulos.Columns["IdMarca"].Visible = false;
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            FormAltaArticulo alta = new FormAltaArticulo();
            alta.ShowDialog();
            cargar();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)DGVArticulos.CurrentRow.DataBoundItem;
            FormAltaArticulo modificar = new FormAltaArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarArticulos_Click(object sender, EventArgs e)
        {
            ConexionArticulo conexion = new ConexionArticulo();
            Articulo seleccionado;

            try
            {
                seleccionado = (Articulo)DGVArticulos.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show("¿Seguro que querés eliminar este artículo?",
                                                 "Eliminar artículo",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    conexion.eliminar(seleccionado.Id);
                    MessageBox.Show("Artículo eliminado correctamente.");
                    cargar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }


}
