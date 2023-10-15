namespace MedicalAppUI
{
    partial class BaseForm
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
            menuStrip1 = new MenuStrip();
            registroToolStripMenuItem = new ToolStripMenuItem();
            registroDeCitasToolStripMenuItem = new ToolStripMenuItem();
            registroTiposDeConsultaToolStripMenuItem = new ToolStripMenuItem();
            administraciónToolStripMenuItem = new ToolStripMenuItem();
            administraciónDeClientesToolStripMenuItem = new ToolStripMenuItem();
            administraciónDeDoctoresToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            citasPorFechaToolStripMenuItem = new ToolStripMenuItem();
            citasPorDoctorToolStripMenuItem = new ToolStripMenuItem();
            citasPorClienteToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { registroToolStripMenuItem, administraciónToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // registroToolStripMenuItem
            // 
            registroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registroDeCitasToolStripMenuItem, registroTiposDeConsultaToolStripMenuItem });
            registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            registroToolStripMenuItem.Size = new Size(62, 20);
            registroToolStripMenuItem.Text = "Registro";
            registroToolStripMenuItem.Click += registroToolStripMenuItem_Click;
            // 
            // registroDeCitasToolStripMenuItem
            // 
            registroDeCitasToolStripMenuItem.Name = "registroDeCitasToolStripMenuItem";
            registroDeCitasToolStripMenuItem.Size = new Size(214, 22);
            registroDeCitasToolStripMenuItem.Text = "Registro de Citas";
            registroDeCitasToolStripMenuItem.Click += registroDeCitasToolStripMenuItem_Click;
            // 
            // registroTiposDeConsultaToolStripMenuItem
            // 
            registroTiposDeConsultaToolStripMenuItem.Name = "registroTiposDeConsultaToolStripMenuItem";
            registroTiposDeConsultaToolStripMenuItem.Size = new Size(214, 22);
            registroTiposDeConsultaToolStripMenuItem.Text = "Registro Tipos de Consulta";
            registroTiposDeConsultaToolStripMenuItem.Click += registroTiposDeConsultaToolStripMenuItem_Click;
            // 
            // administraciónToolStripMenuItem
            // 
            administraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { administraciónDeClientesToolStripMenuItem, administraciónDeDoctoresToolStripMenuItem });
            administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            administraciónToolStripMenuItem.Size = new Size(100, 20);
            administraciónToolStripMenuItem.Text = "Administración";
            // 
            // administraciónDeClientesToolStripMenuItem
            // 
            administraciónDeClientesToolStripMenuItem.Name = "administraciónDeClientesToolStripMenuItem";
            administraciónDeClientesToolStripMenuItem.Size = new Size(221, 22);
            administraciónDeClientesToolStripMenuItem.Text = "Administración de Clientes";
            administraciónDeClientesToolStripMenuItem.Click += administraciónDeClientesToolStripMenuItem_Click;
            // 
            // administraciónDeDoctoresToolStripMenuItem
            // 
            administraciónDeDoctoresToolStripMenuItem.Name = "administraciónDeDoctoresToolStripMenuItem";
            administraciónDeDoctoresToolStripMenuItem.Size = new Size(221, 22);
            administraciónDeDoctoresToolStripMenuItem.Text = "Administración de Doctores";
            administraciónDeDoctoresToolStripMenuItem.Click += administraciónDeDoctoresToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { citasPorFechaToolStripMenuItem, citasPorDoctorToolStripMenuItem, citasPorClienteToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // citasPorFechaToolStripMenuItem
            // 
            citasPorFechaToolStripMenuItem.Name = "citasPorFechaToolStripMenuItem";
            citasPorFechaToolStripMenuItem.Size = new Size(180, 22);
            citasPorFechaToolStripMenuItem.Text = "Citas por Fecha";
            // 
            // citasPorDoctorToolStripMenuItem
            // 
            citasPorDoctorToolStripMenuItem.Name = "citasPorDoctorToolStripMenuItem";
            citasPorDoctorToolStripMenuItem.Size = new Size(180, 22);
            citasPorDoctorToolStripMenuItem.Text = "Citas por Doctor";
            // 
            // citasPorClienteToolStripMenuItem
            // 
            citasPorClienteToolStripMenuItem.Name = "citasPorClienteToolStripMenuItem";
            citasPorClienteToolStripMenuItem.Size = new Size(180, 22);
            citasPorClienteToolStripMenuItem.Text = "Citas por Cliente";
            citasPorClienteToolStripMenuItem.Click += citasPorClienteToolStripMenuItem_Click;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            Name = "BaseForm";
            Text = "BaseForm";
            Load += BaseForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem registroToolStripMenuItem;
        private ToolStripMenuItem registroDeCitasToolStripMenuItem;
        private ToolStripMenuItem registroTiposDeConsultaToolStripMenuItem;
        private ToolStripMenuItem administraciónToolStripMenuItem;
        private ToolStripMenuItem administraciónDeClientesToolStripMenuItem;
        private ToolStripMenuItem administraciónDeDoctoresToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem citasPorFechaToolStripMenuItem;
        private ToolStripMenuItem citasPorDoctorToolStripMenuItem;
        private ToolStripMenuItem citasPorClienteToolStripMenuItem;
    }
}