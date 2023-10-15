namespace MedicalAppUI
{
    partial class FrmAppointmentUI
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
            labelCodigo = new Label();
            txtId = new TextBox();
            labelPaciente = new Label();
            labelEspecialidad = new Label();
            labelDoctor = new Label();
            labelFecha = new Label();
            dgridPacient = new DataGridView();
            datePicker = new DateTimePicker();
            cboxSpeciality = new ComboBox();
            listDoctor = new ListBox();
            btnSave = new Button();
            btnCancel = new Button();
            timeComboBox = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgridPacient).BeginInit();
            SuspendLayout();
            // 
            // labelCodigo
            // 
            labelCodigo.AutoSize = true;
            labelCodigo.Location = new Point(12, 51);
            labelCodigo.Name = "labelCodigo";
            labelCodigo.Size = new Size(86, 15);
            labelCodigo.TabIndex = 0;
            labelCodigo.Text = "Código de Cita";
            // 
            // txtId
            // 
            txtId.Location = new Point(109, 48);
            txtId.Name = "txtId";
            txtId.Size = new Size(201, 23);
            txtId.TabIndex = 2;
            // 
            // labelPaciente
            // 
            labelPaciente.AutoSize = true;
            labelPaciente.Location = new Point(330, 51);
            labelPaciente.Name = "labelPaciente";
            labelPaciente.Size = new Size(52, 15);
            labelPaciente.TabIndex = 3;
            labelPaciente.Text = "Paciente";
            // 
            // labelEspecialidad
            // 
            labelEspecialidad.AutoSize = true;
            labelEspecialidad.Location = new Point(12, 186);
            labelEspecialidad.Name = "labelEspecialidad";
            labelEspecialidad.Size = new Size(72, 15);
            labelEspecialidad.TabIndex = 5;
            labelEspecialidad.Text = "Especialidad";
            // 
            // labelDoctor
            // 
            labelDoctor.AutoSize = true;
            labelDoctor.Location = new Point(12, 85);
            labelDoctor.Name = "labelDoctor";
            labelDoctor.Size = new Size(43, 15);
            labelDoctor.TabIndex = 4;
            labelDoctor.Text = "Doctor";
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(12, 225);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(38, 15);
            labelFecha.TabIndex = 6;
            labelFecha.Text = "Fecha";
            // 
            // dgridPacient
            // 
            dgridPacient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgridPacient.Location = new Point(388, 48);
            dgridPacient.MultiSelect = false;
            dgridPacient.Name = "dgridPacient";
            dgridPacient.RowTemplate.Height = 25;
            dgridPacient.Size = new Size(240, 150);
            dgridPacient.TabIndex = 23;
            // 
            // datePicker
            // 
            datePicker.CustomFormat = "dd/MM/yy";
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.Location = new Point(109, 219);
            datePicker.MaxDate = new DateTime(3000, 12, 31, 0, 0, 0, 0);
            datePicker.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(201, 23);
            datePicker.TabIndex = 24;
            // 
            // cboxSpeciality
            // 
            cboxSpeciality.FormattingEnabled = true;
            cboxSpeciality.Location = new Point(109, 183);
            cboxSpeciality.Name = "cboxSpeciality";
            cboxSpeciality.Size = new Size(201, 23);
            cboxSpeciality.TabIndex = 25;
            // 
            // listDoctor
            // 
            listDoctor.FormattingEnabled = true;
            listDoctor.ItemHeight = 15;
            listDoctor.Location = new Point(109, 77);
            listDoctor.Name = "listDoctor";
            listDoctor.Size = new Size(200, 94);
            listDoctor.TabIndex = 26;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(553, 221);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 27;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(472, 221);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 28;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // timeComboBox
            // 
            timeComboBox.FormattingEnabled = true;
            timeComboBox.Location = new Point(109, 248);
            timeComboBox.Name = "timeComboBox";
            timeComboBox.Size = new Size(121, 23);
            timeComboBox.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 251);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 30;
            label1.Text = "Hora de la Cita";
            // 
            // FrmAppointmentUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(timeComboBox);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(listDoctor);
            Controls.Add(cboxSpeciality);
            Controls.Add(datePicker);
            Controls.Add(dgridPacient);
            Controls.Add(labelFecha);
            Controls.Add(labelEspecialidad);
            Controls.Add(labelDoctor);
            Controls.Add(labelPaciente);
            Controls.Add(txtId);
            Controls.Add(labelCodigo);
            Name = "FrmAppointmentUI";
            Text = "FrmAppointmentRegistration";
            Load += FrmAppointmentRegistration_Load;
            Controls.SetChildIndex(labelCodigo, 0);
            Controls.SetChildIndex(txtId, 0);
            Controls.SetChildIndex(labelPaciente, 0);
            Controls.SetChildIndex(labelDoctor, 0);
            Controls.SetChildIndex(labelEspecialidad, 0);
            Controls.SetChildIndex(labelFecha, 0);
            Controls.SetChildIndex(dgridPacient, 0);
            Controls.SetChildIndex(datePicker, 0);
            Controls.SetChildIndex(cboxSpeciality, 0);
            Controls.SetChildIndex(listDoctor, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(timeComboBox, 0);
            Controls.SetChildIndex(label1, 0);
            ((System.ComponentModel.ISupportInitialize)dgridPacient).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCodigo;
        private TextBox txtId;
        private Label labelPaciente;
        private Label labelEspecialidad;
        private Label labelDoctor;
        private Label labelFecha;
        private DataGridView dgridPacient;
        private DateTimePicker datePicker;
        private ComboBox cboxSpeciality;
        private ListBox listDoctor;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dateTimePicker1;
        private ComboBox timeComboBox;
        private Label label1;
    }
}