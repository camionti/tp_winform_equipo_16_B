using Conexion;
using Conexion2;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Conexion.ConexionArticulo;

namespace Actividad2
{
    public partial class FormAltaArticulo : Form
    {

        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        public FormAltaArticulo()
        {
            InitializeComponent();
        }
        public FormAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
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
            
            ConexionArticulo conexionArticulo = new ConexionArticulo();
            try
            {
                if(articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = textBoxCodigo.Text;
                articulo.Nombre = textBoxNombre.Text;
                articulo.Descripcion = textBoxDescrip.Text;
                articulo.Idmarca = (int)comboBoxMarca.SelectedValue;
                articulo.Idcategoria = (int)comboBoxCategoria.SelectedValue;
                decimal precio;

                if (decimal.TryParse(textBoxPrecio.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out precio))
                {
                    articulo.Precio = precio;
                }
                else
                {
                    MessageBox.Show("El precio ingresado no es válido.");
                    return;
                }

                articulo.TipoMarca = new Marca();
                articulo.TipoMarca.IDMarca = (int)comboBoxMarca.SelectedValue;

                articulo.TipoCategoria = new Categoria();
                articulo.TipoCategoria.IdCategoria = (int)comboBoxCategoria.SelectedValue;

                articulo.Imagen = new Imagen();
                articulo.Imagen.UrlImagen = txtURLImagen.Text;

               if(articulo.Id != 0)
                {
                    conexionArticulo.modificar(articulo);
                    MessageBox.Show("modificado exitosamente");
                }
                else 
                {
                    conexionArticulo.agregar(articulo);
                    MessageBox.Show("agregado exitosamente");
                }

                //Guardo imagen local
                if (archivo != null && !(txtURLImagen.Text.ToUpper().Contains("HTTP")))
                {
                    guardarImagenLocal(archivo);
                }

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

                if (articulo != null) 
                {
                    textBoxCodigo.Text = articulo.Codigo;
                    textBoxNombre.Text = articulo.Nombre;
                    textBoxDescrip.Text = articulo.Descripcion;
                    textBoxPrecio.Text = articulo.Precio.ToString();
                    txtURLImagen.Text = ((articulo.Imagen.UrlImagen != null) ? articulo.Imagen.UrlImagen : "");
                    comboBoxMarca.SelectedValue = articulo.Idmarca;
                    comboBoxCategoria.SelectedValue = articulo.Idcategoria;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png;|webp|*.webp;|jpeg|*.jpeg;|bmp|*.bmp";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtURLImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }

        public void guardarImagenLocal(OpenFileDialog archivo)
        {
            Directory.CreateDirectory(ConfigurationManager.AppSettings["img-folder"]);
            File.Copy(archivo.FileName, ConfigurationManager.AppSettings["img-folder"] + archivo.SafeFileName);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void txtURLImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtURLImagen.Text);
        }
    }
}
