
namespace CapaPresentacion
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.statTiempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemArticulos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTimer = new System.Windows.Forms.Timer(this.components);
            this.statusBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statUsuario,
            this.statTiempo});
            this.statusBar.Location = new System.Drawing.Point(0, 428);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(800, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusBar";
            // 
            // statUsuario
            // 
            this.statUsuario.Name = "statUsuario";
            this.statUsuario.Size = new System.Drawing.Size(23, 17);
            this.statUsuario.Text = "usr";
            // 
            // statTiempo
            // 
            this.statTiempo.Name = "statTiempo";
            this.statTiempo.Size = new System.Drawing.Size(31, 17);
            this.statTiempo.Text = "time";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemInventario,
            this.menuItemHistorial,
            this.menuItemArticulos,
            this.menuItemCategorias,
            this.menuItemUsuarios});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuItemInventario
            // 
            this.menuItemInventario.Name = "menuItemInventario";
            this.menuItemInventario.Size = new System.Drawing.Size(72, 20);
            this.menuItemInventario.Text = "Inventario";
            this.menuItemInventario.Click += new System.EventHandler(this.menuItemInventario_Click);
            // 
            // menuItemHistorial
            // 
            this.menuItemHistorial.Name = "menuItemHistorial";
            this.menuItemHistorial.Size = new System.Drawing.Size(63, 20);
            this.menuItemHistorial.Text = "Historial";
            this.menuItemHistorial.Click += new System.EventHandler(this.menuItemHistorial_Click);
            // 
            // menuItemArticulos
            // 
            this.menuItemArticulos.Name = "menuItemArticulos";
            this.menuItemArticulos.Size = new System.Drawing.Size(66, 20);
            this.menuItemArticulos.Text = "Artículos";
            this.menuItemArticulos.Click += new System.EventHandler(this.menuItemArticulos_Click);
            // 
            // menuItemCategorias
            // 
            this.menuItemCategorias.Name = "menuItemCategorias";
            this.menuItemCategorias.Size = new System.Drawing.Size(75, 20);
            this.menuItemCategorias.Text = "Categorías";
            this.menuItemCategorias.Click += new System.EventHandler(this.menuItemCategorias_Click);
            // 
            // menuItemUsuarios
            // 
            this.menuItemUsuarios.Name = "menuItemUsuarios";
            this.menuItemUsuarios.Size = new System.Drawing.Size(64, 20);
            this.menuItemUsuarios.Text = "Usuarios";
            this.menuItemUsuarios.Click += new System.EventHandler(this.menuItemUsuarios_Click);
            // 
            // sysTimer
            // 
            this.sysTimer.Tick += new System.EventHandler(this.sysTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Inventario Void";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statUsuario;
        private System.Windows.Forms.ToolStripStatusLabel statTiempo;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemInventario;
        private System.Windows.Forms.ToolStripMenuItem menuItemHistorial;
        private System.Windows.Forms.ToolStripMenuItem menuItemArticulos;
        private System.Windows.Forms.ToolStripMenuItem menuItemCategorias;
        private System.Windows.Forms.ToolStripMenuItem menuItemUsuarios;
        private System.Windows.Forms.Timer sysTimer;
    }
}