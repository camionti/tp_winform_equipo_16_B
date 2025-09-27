using Conexion;
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

                if (string.IsNullOrWhiteSpace(textBoxCodigo.Text))
                {
                    MessageBox.Show("Debe ingresar un código para el artículo.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre para el artículo.");
                    return;
                }

                if (comboBoxMarca.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una marca.");
                    return;
                }

                if (comboBoxCategoria.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una categoría.");
                    return;
                }

                decimal precio;
                if (!decimal.TryParse(textBoxPrecio.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out precio))
                {
                    MessageBox.Show("El precio ingresado no es válido.");
                    return;
                }

                if (precio <= 0)
                {
                    MessageBox.Show("El precio debe ser mayor a cero.");
                    return;
                }

                articulo.Codigo = textBoxCodigo.Text;
                articulo.Nombre = textBoxNombre.Text;
                articulo.Descripcion = textBoxDescrip.Text;
                articulo.Idmarca = (int)comboBoxMarca.SelectedValue;
                articulo.Idcategoria = (int)comboBoxCategoria.SelectedValue;
                articulo.Precio = precio;

                articulo.TipoMarca = new Marca { IDMarca = articulo.Idmarca };
                articulo.TipoCategoria = new Categoria { Id = articulo.Idcategoria };

                if (articulo.Id != 0)
                {
                    conexionArticulo.modificar(articulo);
                    MessageBox.Show("Articulo modificado exitosamente");
                }
                else 
                {
                    conexionArticulo.agregar(articulo);
                    MessageBox.Show("Articulo agregado exitosamente");
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
                ConexionCategorias conexionCategoria = new ConexionCategorias();

                //para que el id no quede como null en la base de datos
                comboBoxMarca.DataSource = conexionMarca.Listar();
                comboBoxMarca.DisplayMember = "Descripcion"; 
                comboBoxMarca.ValueMember = "IDMarca";
                comboBoxCategoria.DataSource = conexionCategoria.Listar();
                comboBoxCategoria.DisplayMember = "Descripcion";
                comboBoxCategoria.ValueMember = "Id";

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
