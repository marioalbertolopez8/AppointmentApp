namespace MedicalAppUI
{
    partial class FrmAppointmentReportByDoctor
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
            cBoxSearch = new ComboBox();
            dgridReportOutput = new DataGridView();
            label1 = new Label();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgridReportOutput).BeginInit();
            SuspendLayout();
            // 
            // cBoxSearch
            // 
            cBoxSearch.FormattingEnabled = true;
            cBoxSearch.Location = new Point(12, 27);
            cBoxSearch.Name = "cBoxSearch";
            cBoxSearch.Size = new Size(201, 23);
            cBoxSearch.TabIndex = 36;
            // 
            // dgridReportOutput
            // 
            dgridReportOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgridReportOutput.Location = new Point(219, 12);
            dgridReportOutput.MultiSelect = false;
            dgridReportOutput.Name = "dgridReportOutput";
            dgridReportOutput.RowTemplate.Height = 25;
            dgridReportOutput.Size = new Size(524, 136);
            dgridReportOutput.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 34;
            label1.Text = "Doctor";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(138, 56);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 33;
            btnSearch.Text = "Buscar";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // FrmAppointmentReportByDoctor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cBoxSearch);
            Controls.Add(dgridReportOutput);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Name = "FrmAppointmentReportByDoctor";
            Text = "FrmAppointmentReportByDoctor";
            ((System.ComponentModel.ISupportInitialize)dgridReportOutput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cBoxSearch;
        private DataGridView dgridReportOutput;
        private Label label1;
        private Button btnSearch;
    }
}