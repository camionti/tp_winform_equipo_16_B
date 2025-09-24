using System;
using System.Windows.Forms;

namespace Actividad2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGVArticulos = new System.Windows.Forms.DataGridView();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarArticulos = new System.Windows.Forms.Button();
            this.lblFiltroRapido = new System.Windows.Forms.Label();
            this.txtFiltroRapido = new System.Windows.Forms.TextBox();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblCampo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrecioMaximo = new System.Windows.Forms.Label();
            this.txtPrecioMaximo = new System.Windows.Forms.TextBox();
            this.txtPrecioMinimo = new System.Windows.Forms.TextBox();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.btnCategorias = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVArticulos
            // 
            this.DGVArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVArticulos.Location = new System.Drawing.Point(47, 69);
            this.DGVArticulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVArticulos.Name = "DGVArticulos";
            this.DGVArticulos.RowHeadersWidth = 51;
            this.DGVArticulos.RowTemplate.Height = 24;
            this.DGVArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVArticulos.Size = new System.Drawing.Size(889, 363);
            this.DGVArticulos.TabIndex = 1;
            this.DGVArticulos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVArticulos_CellContentDoubleClick);
            this.DGVArticulos.SelectionChanged += new System.EventHandler(this.DGVArticulos_SelectionChanged);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Location = new System.Drawing.Point(47, 455);
            this.btnAgregarArticulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(157, 34);
            this.btnAgregarArticulo.TabIndex = 1;
            this.btnAgregarArticulo.Text = "Agregar Articulo ";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(236, 455);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(157, 34);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar Articulo ";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarArticulos
            // 
            this.btnEliminarArticulos.Location = new System.Drawing.Point(423, 455);
            this.btnEliminarArticulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarArticulos.Name = "btnEliminarArticulos";
            this.btnEliminarArticulos.Size = new System.Drawing.Size(157, 34);
            this.btnEliminarArticulos.TabIndex = 3;
            this.btnEliminarArticulos.Text = "Eliminar Articulo ";
            this.btnEliminarArticulos.UseVisualStyleBackColor = true;
            this.btnEliminarArticulos.Click += new System.EventHandler(this.btnEliminarArticulos_Click);
            // 
            // lblFiltroRapido
            // 
            this.lblFiltroRapido.AutoSize = true;
            this.lblFiltroRapido.Location = new System.Drawing.Point(43, 34);
            this.lblFiltroRapido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroRapido.Name = "lblFiltroRapido";
            this.lblFiltroRapido.Size = new System.Drawing.Size(84, 16);
            this.lblFiltroRapido.TabIndex = 4;
            this.lblFiltroRapido.Text = "Filtro Rápido";
            // 
            // txtFiltroRapido
            // 
            this.txtFiltroRapido.Location = new System.Drawing.Point(139, 31);
            this.txtFiltroRapido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroRapido.Name = "txtFiltroRapido";
            this.txtFiltroRapido.Size = new System.Drawing.Size(272, 22);
            this.txtFiltroRapido.TabIndex = 0;
            this.txtFiltroRapido.TextChanged += new System.EventHandler(this.txtFiltroRapido_TextChanged);
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(1185, 457);
            this.txtFiltroAvanzado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(247, 22);
            this.txtFiltroAvanzado.TabIndex = 8;
            // 
            // cboCriterio
            // 
            this.cboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(1017, 455);
            this.cboCriterio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(159, 24);
            this.cboCriterio.TabIndex = 5;
            // 
            // cboCampo
            // 
            this.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(723, 454);
            this.cboCampo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(155, 24);
            this.cboCampo.TabIndex = 4;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(911, 460);
            this.lblCriterio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(49, 16);
            this.lblCriterio.TabIndex = 24;
            this.lblCriterio.Text = "Criterio";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(601, 459);
            this.lblCampo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(108, 16);
            this.lblCampo.TabIndex = 23;
            this.lblCampo.Text = "Filtrar por campo";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1453, 454);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(607, 506);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Precio mínimo";
            // 
            // lblPrecioMaximo
            // 
            this.lblPrecioMaximo.AutoSize = true;
            this.lblPrecioMaximo.Location = new System.Drawing.Point(899, 505);
            this.lblPrecioMaximo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioMaximo.Name = "lblPrecioMaximo";
            this.lblPrecioMaximo.Size = new System.Drawing.Size(96, 16);
            this.lblPrecioMaximo.TabIndex = 30;
            this.lblPrecioMaximo.Text = "Precio máximo";
            // 
            // txtPrecioMaximo
            // 
            this.txtPrecioMaximo.Location = new System.Drawing.Point(1005, 501);
            this.txtPrecioMaximo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecioMaximo.Name = "txtPrecioMaximo";
            this.txtPrecioMaximo.Size = new System.Drawing.Size(176, 22);
            this.txtPrecioMaximo.TabIndex = 7;
            // 
            // txtPrecioMinimo
            // 
            this.txtPrecioMinimo.Location = new System.Drawing.Point(723, 502);
            this.txtPrecioMinimo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecioMinimo.Name = "txtPrecioMinimo";
            this.txtPrecioMinimo.Size = new System.Drawing.Size(160, 22);
            this.txtPrecioMinimo.TabIndex = 6;
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(964, 69);
            this.pbxArticulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(387, 363);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArticulo.TabIndex = 32;
            this.pbxArticulo.TabStop = false;
            // 
            // btnCategorias
            // 
            this.btnCategorias.Location = new System.Drawing.Point(139, 496);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(164, 36);
            this.btnCategorias.TabIndex = 33;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 572);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPrecioMaximo);
            this.Controls.Add(this.txtPrecioMaximo);
            this.Controls.Add(this.txtPrecioMinimo);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtFiltroRapido);
            this.Controls.Add(this.lblFiltroRapido);
            this.Controls.Add(this.btnEliminarArticulos);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregarArticulo);
            this.Controls.Add(this.DGVArticulos);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.DataGridView DGVArticulos;
        private Button btnAgregarArticulo;
        private Button btnModificar;
        private Button btnEliminarArticulos;
        private Label lblFiltroRapido;
        private TextBox txtFiltroRapido;
        private TextBox txtFiltroAvanzado;
        private ComboBox cboCriterio;
        private ComboBox cboCampo;
        private Label lblCriterio;
        private Label lblCampo;
        private Button btnBuscar;
        private Label label2;
        private Label lblPrecioMaximo;
        private TextBox txtPrecioMaximo;
        private TextBox txtPrecioMinimo;
        private PictureBox pbxArticulo;
        private Button btnCategorias;
    }
}

