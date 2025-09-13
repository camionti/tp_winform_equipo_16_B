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
            ((System.ComponentModel.ISupportInitialize)(this.DGVArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVArticulos
            // 
            this.DGVArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVArticulos.Location = new System.Drawing.Point(44, 28);
            this.DGVArticulos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGVArticulos.Name = "DGVArticulos";
            this.DGVArticulos.RowHeadersWidth = 51;
            this.DGVArticulos.RowTemplate.Height = 24;
            this.DGVArticulos.Size = new System.Drawing.Size(880, 474);
            this.DGVArticulos.TabIndex = 0;
            this.DGVArticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVArticulos_CellContentClick);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Location = new System.Drawing.Point(136, 515);
            this.btnAgregarArticulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(118, 28);
            this.btnAgregarArticulo.TabIndex = 1;
            this.btnAgregarArticulo.Text = "Agregar Articulo ";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(278, 515);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(118, 28);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar Articulo ";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarArticulos
            // 
            this.btnEliminarArticulos.Location = new System.Drawing.Point(418, 515);
            this.btnEliminarArticulos.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarArticulos.Name = "btnEliminarArticulos";
            this.btnEliminarArticulos.Size = new System.Drawing.Size(118, 28);
            this.btnEliminarArticulos.TabIndex = 3;
            this.btnEliminarArticulos.Text = "Eliminar Articulo ";
            this.btnEliminarArticulos.UseVisualStyleBackColor = true;
            this.btnEliminarArticulos.Click += new System.EventHandler(this.btnEliminarArticulos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 553);
            this.Controls.Add(this.btnEliminarArticulos);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregarArticulo);
            this.Controls.Add(this.DGVArticulos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVArticulos)).EndInit();
            this.ResumeLayout(false);

        }

        private void DGVArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView DGVArticulos;
        private Button btnAgregarArticulo;
        private Button btnModificar;
        private Button btnEliminarArticulos;
    }
}

