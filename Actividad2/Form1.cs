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
            Conexion conexio = new Conexion();
            listaArticulo = conexio.Listar();
            DGVArticulos.DataSource = listaArticulo;
        }
    }


}
