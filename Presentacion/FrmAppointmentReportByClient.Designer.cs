namespace MedicalAppUI
{
    partial class FrmAppointmentReportByClient
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
            btnSearch = new Button();
            dgridReportOutput = new DataGridView();
            labelPaciente = new Label();
            cBoxSearch = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgridReportOutput).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(138, 56);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 28;
            btnSearch.Text = "Buscar";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgridReportOutput
            // 
            dgridReportOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgridReportOutput.Location = new Point(219, 12);
            dgridReportOutput.MultiSelect = false;
            dgridReportOutput.Name = "dgridReportOutput";
            dgridReportOutput.RowTemplate.Height = 25;
            dgridReportOutput.Size = new Size(524, 136);
            dgridReportOutput.TabIndex = 30;
            dgridReportOutput.CellContentClick += dgridReportOutput_CellContentClick;
            // 
            // labelPaciente
            // 
            labelPaciente.AutoSize = true;
            labelPaciente.Location = new Point(12, 9);
            labelPaciente.Name = "labelPaciente";
            labelPaciente.Size = new Size(52, 15);
            labelPaciente.TabIndex = 29;
            labelPaciente.Text = "Paciente";
            // 
            // cBoxSearch
            // 
            cBoxSearch.FormattingEnabled = true;
            cBoxSearch.Location = new Point(12, 27);
            cBoxSearch.Name = "cBoxSearch";
            cBoxSearch.Size = new Size(201, 23);
            cBoxSearch.TabIndex = 32;
            cBoxSearch.SelectedIndexChanged += cBoxSearch_SelectedIndexChanged;
            // 
            // FrmAppointmentReportByClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cBoxSearch);
            Controls.Add(dgridReportOutput);
            Controls.Add(labelPaciente);
            Controls.Add(btnSearch);
            Name = "FrmAppointmentReportByClient";
            Text = "FrmAppointmentReportByClient";
            ((System.ComponentModel.ISupportInitialize)dgridReportOutput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private DataGridView dgridReportOutput;
        private Label labelPaciente;
        private ComboBox cBoxSearch;
    }
}