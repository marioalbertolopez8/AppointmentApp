namespace MedicalAppUI
{
    partial class FrmDoctorUI
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
            dgvDoctors = new DataGridView();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtId = new TextBox();
            txtFirstName = new TextBox();
            txtSecondLastName = new TextBox();
            txtFirstLastName = new TextBox();
            cmbStatus = new ComboBox();
            btnToggleMode = new Button();
            Identificaci = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).BeginInit();
            SuspendLayout();
            // 
            // dgvDoctors
            // 
            dgvDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoctors.Location = new Point(12, 114);
            dgvDoctors.Name = "dgvDoctors";
            dgvDoctors.RowTemplate.Height = 25;
            dgvDoctors.Size = new Size(551, 175);
            dgvDoctors.TabIndex = 0;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(239, 85);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Actualizar";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(153, 85);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(112, 12);
            txtId.Name = "txtId";
            txtId.Size = new Size(121, 23);
            txtId.TabIndex = 3;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(442, 12);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(121, 23);
            txtFirstName.TabIndex = 4;
            // 
            // txtSecondLastName
            // 
            txtSecondLastName.Location = new Point(442, 70);
            txtSecondLastName.Name = "txtSecondLastName";
            txtSecondLastName.Size = new Size(121, 23);
            txtSecondLastName.TabIndex = 6;
            // 
            // txtFirstLastName
            // 
            txtFirstLastName.Location = new Point(442, 41);
            txtFirstLastName.Name = "txtFirstLastName";
            txtFirstLastName.Size = new Size(121, 23);
            txtFirstLastName.TabIndex = 5;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(112, 41);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(121, 23);
            cmbStatus.TabIndex = 7;
            // 
            // btnToggleMode
            // 
            btnToggleMode.Location = new Point(239, 11);
            btnToggleMode.Name = "btnToggleMode";
            btnToggleMode.Size = new Size(75, 23);
            btnToggleMode.TabIndex = 8;
            btnToggleMode.Text = "Editar ID";
            btnToggleMode.UseVisualStyleBackColor = true;
            btnToggleMode.Click += btnToggleMode_Click_1;
            // 
            // Identificaci
            // 
            Identificaci.AutoSize = true;
            Identificaci.Location = new Point(12, 15);
            Identificaci.Name = "Identificaci";
            Identificaci.Size = new Size(79, 15);
            Identificaci.TabIndex = 10;
            Identificaci.Text = "Identificación";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(342, 15);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 11;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 73);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 13;
            label2.Text = "Segundo Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 44);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 12;
            label3.Text = "Primer Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 44);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 14;
            label4.Text = "Estado";
            // 
            // FrmDoctorUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 301);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(Identificaci);
            Controls.Add(btnToggleMode);
            Controls.Add(cmbStatus);
            Controls.Add(txtSecondLastName);
            Controls.Add(txtFirstLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtId);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(dgvDoctors);
            Name = "FrmDoctorUI";
            Text = "FrmDoctorUI";
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDoctors;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtId;
        private TextBox txtFirstName;
        private TextBox txtSecondLastName;
        private TextBox txtFirstLastName;
        private ComboBox cmbStatus;
        private Button btnToggleMode;
        private Label Identificaci;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}