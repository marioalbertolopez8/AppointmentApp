﻿namespace MedicalAppUI
{
    partial class FrmPatientUI
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
            dgvPatients = new DataGridView();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtId = new TextBox();
            txtFirstName = new TextBox();
            txtSecondLastName = new TextBox();
            txtFirstLastName = new TextBox();
            cmbGenero = new ComboBox();
            btnToggleMode = new Button();
            Identificaci = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dateTimePickerBirthDay = new DateTimePicker();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(12, 169);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowTemplate.Height = 25;
            dgvPatients.Size = new Size(551, 175);
            dgvPatients.TabIndex = 0;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(239, 140);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Actualizar";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(153, 140);
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
            // cmbGenero
            // 
            cmbGenero.FormattingEnabled = true;
            cmbGenero.Location = new Point(112, 41);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(121, 23);
            cmbGenero.TabIndex = 7;
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
            label4.Size = new Size(45, 15);
            label4.TabIndex = 14;
            label4.Text = "Género";
            // 
            // dateTimePickerBirthDay
            // 
            dateTimePickerBirthDay.Location = new Point(12, 94);
            dateTimePickerBirthDay.Name = "dateTimePickerBirthDay";
            dateTimePickerBirthDay.Size = new Size(200, 23);
            dateTimePickerBirthDay.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 78);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 16;
            label5.Text = "Fecha de Nacimiento";
            // 
            // FrmPatientUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 356);
            Controls.Add(label5);
            Controls.Add(dateTimePickerBirthDay);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(Identificaci);
            Controls.Add(btnToggleMode);
            Controls.Add(cmbGenero);
            Controls.Add(txtSecondLastName);
            Controls.Add(txtFirstLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtId);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(dgvPatients);
            Name = "FrmPatientUI";
            Text = "FrmPatientUI";
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPatients;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtId;
        private TextBox txtFirstName;
        private TextBox txtSecondLastName;
        private TextBox txtFirstLastName;
        private ComboBox cmbGenero;
        private Button btnToggleMode;
        private Label Identificaci;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePickerBirthDay;
        private Label label5;
    }
}