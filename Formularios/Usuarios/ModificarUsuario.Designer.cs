namespace Gestionador.Formularios.Empleados
{
    partial class ModificarUsuario
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtContrasena2 = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.lblfecha = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificarContrasena = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(398, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 131;
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
            this.panel1.Location = new System.Drawing.Point(471, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 212);
            this.panel1.TabIndex = 130;
            // 
            // cbAReportes
            // 
            this.cbAReportes.AutoSize = true;
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
            this.cbAUsuarios.Location = new System.Drawing.Point(3, 72);
            this.cbAUsuarios.Name = "cbAUsuarios";
            this.cbAUsuarios.Size = new System.Drawing.Size(119, 17);
            this.cbAUsuarios.TabIndex = 111;
            this.cbAUsuarios.Text = "Administrar usuarios";
            this.cbAUsuarios.UseVisualStyleBackColor = true;
            // 
            // cbAProductos
            // 
            this.cbAProductos.AutoSize = true;
            this.cbAProductos.Location = new System.Drawing.Point(3, 49);
            this.cbAProductos.Name = "cbAProductos";
            this.cbAProductos.Size = new System.Drawing.Size(127, 17);
            this.cbAProductos.TabIndex = 110;
            this.cbAProductos.Text = "Administrar productos";
            this.cbAProductos.UseVisualStyleBackColor = true;
            // 
            // cbAClientes
            // 
            this.cbAClientes.AutoSize = true;
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
            this.cbAdmin.Location = new System.Drawing.Point(3, 3);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(171, 17);
            this.cbAdmin.TabIndex = 108;
            this.cbAdmin.Text = "Administrador general(TODOS)";
            this.cbAdmin.UseVisualStyleBackColor = true;
            this.cbAdmin.CheckedChanged += new System.EventHandler(this.cbAdmin_CheckedChanged);
            // 
            // cbACaja
            // 
            this.cbACaja.AutoSize = true;
            this.cbACaja.Location = new System.Drawing.Point(3, 141);
            this.cbACaja.Name = "cbACaja";
            this.cbACaja.Size = new System.Drawing.Size(95, 17);
            this.cbACaja.TabIndex = 107;
            this.cbACaja.Text = "Actualizar caja";
            this.cbACaja.UseVisualStyleBackColor = true;
            // 
            // cbAProveedores
            // 
            this.cbAProveedores.AutoSize = true;
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
            this.cbACompras.Location = new System.Drawing.Point(3, 118);
            this.cbACompras.Name = "cbACompras";
            this.cbACompras.Size = new System.Drawing.Size(120, 17);
            this.cbACompras.TabIndex = 105;
            this.cbACompras.Text = "Administrar compras";
            this.cbACompras.UseVisualStyleBackColor = true;
            // 
            // cbAVentas
            // 
            this.cbAVentas.AutoSize = true;
            this.cbAVentas.Location = new System.Drawing.Point(3, 164);
            this.cbAVentas.Name = "cbAVentas";
            this.cbAVentas.Size = new System.Drawing.Size(99, 17);
            this.cbAVentas.TabIndex = 104;
            this.cbAVentas.Text = "Generar ventas";
            this.cbAVentas.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "Repetir contraseña:";
            // 
            // txtContrasena2
            // 
            this.txtContrasena2.Enabled = false;
            this.txtContrasena2.Location = new System.Drawing.Point(119, 158);
            this.txtContrasena2.Name = "txtContrasena2";
            this.txtContrasena2.Size = new System.Drawing.Size(174, 20);
            this.txtContrasena2.TabIndex = 128;
            this.txtContrasena2.UseSystemPasswordChar = true;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Enabled = false;
            this.txtContrasena.Location = new System.Drawing.Point(119, 132);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(174, 20);
            this.txtContrasena.TabIndex = 127;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 126;
            this.label3.Text = "Contraseña:";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(119, 106);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(174, 20);
            this.txtLogin.TabIndex = 125;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 124;
            this.label15.Text = "Usuario (login) :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 123;
            this.label13.Text = "Observaciones:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(119, 184);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(276, 77);
            this.txtObservacion.TabIndex = 122;
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(116, 60);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(40, 13);
            this.lblfecha.TabIndex = 121;
            this.lblfecha.Text = "Fecha:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 120;
            this.label10.Text = "Fecha:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGuardar.Location = new System.Drawing.Point(193, 295);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 45);
            this.btnGuardar.TabIndex = 116;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 33);
            this.label1.TabIndex = 118;
            this.label1.Text = "Modificar usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 119;
            this.label2.Text = "Nombre completo: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(119, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(174, 20);
            this.txtNombre.TabIndex = 115;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCancelar.Location = new System.Drawing.Point(359, 295);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 45);
            this.btnCancelar.TabIndex = 117;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificarContrasena
            // 
            this.btnModificarContrasena.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnModificarContrasena.Location = new System.Drawing.Point(299, 132);
            this.btnModificarContrasena.Name = "btnModificarContrasena";
            this.btnModificarContrasena.Size = new System.Drawing.Size(90, 46);
            this.btnModificarContrasena.TabIndex = 133;
            this.btnModificarContrasena.Text = "Modificar contraseña";
            this.btnModificarContrasena.UseVisualStyleBackColor = false;
            this.btnModificarContrasena.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ModificarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 350);
            this.ControlBox = false;
            this.Controls.Add(this.btnModificarContrasena);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContrasena2);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCancelar);
            this.Name = "ModificarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar usuario";
            this.Load += new System.EventHandler(this.ModificarUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContrasena2;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificarContrasena;
    }
}