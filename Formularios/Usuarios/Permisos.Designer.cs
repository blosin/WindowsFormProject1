namespace Gestionador.Formularios.Usuarios
{
    partial class Permisos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAReportes = new System.Windows.Forms.CheckBox();
            this.cbAUsuarios = new System.Windows.Forms.CheckBox();
            this.cbAProductos = new System.Windows.Forms.CheckBox();
            this.cbAClientes = new System.Windows.Forms.CheckBox();
            this.cbAdmin = new System.Windows.Forms.CheckBox();
            this.cbACaja = new System.Windows.Forms.CheckBox();
            this.cbAProveedores = new System.Windows.Forms.CheckBox();
            this.cbACompras = new System.Windows.Forms.CheckBox();
            this.cbAVentas = new System.Windows.Forms.CheckBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(64, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 118;
            this.label5.Text = "Permisos:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbAReportes);
            this.panel1.Controls.Add(this.cbAUsuarios);
            this.panel1.Controls.Add(this.cbAProductos);
            this.panel1.Controls.Add(this.cbAClientes);
            this.panel1.Controls.Add(this.cbAdmin);
            this.panel1.Controls.Add(this.cbACaja);
            this.panel1.Controls.Add(this.cbAProveedores);
            this.panel1.Controls.Add(this.cbACompras);
            this.panel1.Controls.Add(this.cbAVentas);
            this.panel1.Location = new System.Drawing.Point(79, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 213);
            this.panel1.TabIndex = 117;
            // 
            // cbAReportes
            // 
            this.cbAReportes.AutoSize = true;
            this.cbAReportes.Enabled = false;
            this.cbAReportes.Location = new System.Drawing.Point(3, 187);
            this.cbAReportes.Name = "cbAReportes";
            this.cbAReportes.Size = new System.Drawing.Size(151, 17);
            this.cbAReportes.TabIndex = 113;
            this.cbAReportes.Text = "Generar e imprimir reportes";
            this.cbAReportes.UseVisualStyleBackColor = true;
            // 
            // cbAUsuarios
            // 
            this.cbAUsuarios.AutoSize = true;
            this.cbAUsuarios.Enabled = false;
            this.cbAUsuarios.Location = new System.Drawing.Point(3, 118);
            this.cbAUsuarios.Name = "cbAUsuarios";
            this.cbAUsuarios.Size = new System.Drawing.Size(119, 17);
            this.cbAUsuarios.TabIndex = 111;
            this.cbAUsuarios.Text = "Administrar usuarios";
            this.cbAUsuarios.UseVisualStyleBackColor = true;
            // 
            // cbAProductos
            // 
            this.cbAProductos.AutoSize = true;
            this.cbAProductos.Enabled = false;
            this.cbAProductos.Location = new System.Drawing.Point(3, 72);
            this.cbAProductos.Name = "cbAProductos";
            this.cbAProductos.Size = new System.Drawing.Size(127, 17);
            this.cbAProductos.TabIndex = 110;
            this.cbAProductos.Text = "Administrar productos";
            this.cbAProductos.UseVisualStyleBackColor = true;
            // 
            // cbAClientes
            // 
            this.cbAClientes.AutoSize = true;
            this.cbAClientes.Enabled = false;
            this.cbAClientes.Location = new System.Drawing.Point(3, 26);
            this.cbAClientes.Name = "cbAClientes";
            this.cbAClientes.Size = new System.Drawing.Size(116, 17);
            this.cbAClientes.TabIndex = 109;
            this.cbAClientes.Text = "Administrar clientes";
            this.cbAClientes.UseVisualStyleBackColor = true;
            // 
            // cbAdmin
            // 
            this.cbAdmin.AutoSize = true;
            this.cbAdmin.Enabled = false;
            this.cbAdmin.Location = new System.Drawing.Point(3, 3);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(171, 17);
            this.cbAdmin.TabIndex = 108;
            this.cbAdmin.Text = "Administrador general(TODOS)";
            this.cbAdmin.UseVisualStyleBackColor = true;
            // 
            // cbACaja
            // 
            this.cbACaja.AutoSize = true;
            this.cbACaja.Enabled = false;
            this.cbACaja.Location = new System.Drawing.Point(3, 164);
            this.cbACaja.Name = "cbACaja";
            this.cbACaja.Size = new System.Drawing.Size(95, 17);
            this.cbACaja.TabIndex = 107;
            this.cbACaja.Text = "Actualizar caja";
            this.cbACaja.UseVisualStyleBackColor = true;
            // 
            // cbAProveedores
            // 
            this.cbAProveedores.AutoSize = true;
            this.cbAProveedores.Enabled = false;
            this.cbAProveedores.Location = new System.Drawing.Point(3, 95);
            this.cbAProveedores.Name = "cbAProveedores";
            this.cbAProveedores.Size = new System.Drawing.Size(139, 17);
            this.cbAProveedores.TabIndex = 106;
            this.cbAProveedores.Text = "Administrar proveedores";
            this.cbAProveedores.UseVisualStyleBackColor = true;
            // 
            // cbACompras
            // 
            this.cbACompras.AutoSize = true;
            this.cbACompras.Enabled = false;
            this.cbACompras.Location = new System.Drawing.Point(2, 49);
            this.cbACompras.Name = "cbACompras";
            this.cbACompras.Size = new System.Drawing.Size(120, 17);
            this.cbACompras.TabIndex = 105;
            this.cbACompras.Text = "Administrar compras";
            this.cbACompras.UseVisualStyleBackColor = true;
            // 
            // cbAVentas
            // 
            this.cbAVentas.AutoSize = true;
            this.cbAVentas.Enabled = false;
            this.cbAVentas.Location = new System.Drawing.Point(3, 141);
            this.cbAVentas.Name = "cbAVentas";
            this.cbAVentas.Size = new System.Drawing.Size(112, 17);
            this.cbAVentas.TabIndex = 104;
            this.cbAVentas.Text = "Administrar ventas";
            this.cbAVentas.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnVolver.Location = new System.Drawing.Point(170, 248);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 45);
            this.btnVolver.TabIndex = 116;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 304);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label1);
            this.Name = "Permisos";
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.Permisos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbAReportes;
        private System.Windows.Forms.CheckBox cbAUsuarios;
        private System.Windows.Forms.CheckBox cbAProductos;
        private System.Windows.Forms.CheckBox cbAClientes;
        private System.Windows.Forms.CheckBox cbAdmin;
        private System.Windows.Forms.CheckBox cbACaja;
        private System.Windows.Forms.CheckBox cbAProveedores;
        private System.Windows.Forms.CheckBox cbACompras;
        private System.Windows.Forms.CheckBox cbAVentas;
        private System.Windows.Forms.Button btnVolver;
    }
}