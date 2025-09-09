using Conexion;
using Conexion2;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Conexion.ConexionArticulo;

namespace Actividad2
{
    public partial class FormAltaArticulo : Form
    {
        public FormAltaArticulo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void buttonConfrim_Click(object sender, EventArgs e)
        {
            Articulo ArtNuevo = new Articulo();
            ConexionArticulo conexionArticulo = new ConexionArticulo();
            try
            {
                ArtNuevo.Codigo = textBoxCodigo.Text;
                ArtNuevo.Nombre = textBoxNombre.Text;
                ArtNuevo.Descripcion = textBoxDescrip.Text;
                ArtNuevo.Idmarca = (int)comboBoxMarca.SelectedValue;
                ArtNuevo.Idcategoria = (int)comboBoxCategoria.SelectedValue;
                ArtNuevo.Precio = int.Parse(textBoxPrecio.Text);
                ArtNuevo.TipoMarca = new Marca();
                ArtNuevo.TipoMarca.IDMarca = (int)comboBoxMarca.SelectedValue;

                ArtNuevo.TipoCategoria = new Categoria();
                ArtNuevo.TipoCategoria.IdCategoria = (int)comboBoxCategoria.SelectedValue;

                conexionArticulo.agregar( ArtNuevo );
                MessageBox.Show("agregado exitosamente");
                Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormAltaArticulo_Load(object sender, EventArgs e)
        {
            ConexionArticulo articuloConexion = new ConexionArticulo();
            try
            {
                ConexionMarca conexionMarca = new ConexionMarca();
                ConexionCategoria conexionCategoria = new ConexionCategoria();

                //para que el id no quede como null en la base de datos
                comboBoxMarca.DataSource = conexionMarca.ListarMarcas();
                comboBoxMarca.DisplayMember = "Descripcion"; 
                comboBoxMarca.ValueMember = "IDMarca";
                comboBoxCategoria.DataSource = conexionCategoria.ListarCategorias();
                comboBoxCategoria.DisplayMember = "NombreCategoria";
                comboBoxCategoria.ValueMember = "IdCategoria";


            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
