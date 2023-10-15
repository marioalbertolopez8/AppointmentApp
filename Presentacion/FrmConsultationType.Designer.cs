namespace MedicalAppUI
{
    partial class FrmConsultationType
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
            cmbStatus = new ComboBox();
            txtNumber = new TextBox();
            txtDescription = new TextBox();
            btnAdd = new Button();
            dataGridViewConsultationTypes = new DataGridView();
            NumberColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            StatusColumn = new DataGridViewComboBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConsultationTypes).BeginInit();
            SuspendLayout();
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(459, 102);
            cmbStatus.MaxDropDownItems = 2;
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(121, 23);
            cmbStatus.TabIndex = 2;
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(459, 44);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(121, 23);
            txtNumber.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(459, 73);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(121, 23);
            txtDescription.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(459, 164);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(121, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Guardar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridViewConsultationTypes
            // 
            dataGridViewConsultationTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewConsultationTypes.Columns.AddRange(new DataGridViewColumn[] { NumberColumn, DescriptionColumn, StatusColumn });
            dataGridViewConsultationTypes.Location = new Point(12, 33);
            dataGridViewConsultationTypes.Name = "dataGridViewConsultationTypes";
            dataGridViewConsultationTypes.RowTemplate.Height = 25;
            dataGridViewConsultationTypes.Size = new Size(350, 154);
            dataGridViewConsultationTypes.TabIndex = 5;
            dataGridViewConsultationTypes.CellContentClick += dataGridViewConsultationTypes_CellContentClick;
            // 
            // NumberColumn
            // 
            NumberColumn.HeaderText = "Código";
            NumberColumn.Name = "NumberColumn";
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.HeaderText = "Descripción";
            DescriptionColumn.Name = "DescriptionColumn";
            // 
            // StatusColumn
            // 
            StatusColumn.HeaderText = "Estado";
            StatusColumn.Name = "StatusColumn";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(384, 47);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 6;
            label1.Text = "Código";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(384, 76);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 7;
            label2.Text = "Descripción";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(384, 105);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 8;
            label3.Text = "Estado";
            // 
            // FrmConsultationType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewConsultationTypes);
            Controls.Add(btnAdd);
            Controls.Add(cmbStatus);
            Controls.Add(txtDescription);
            Controls.Add(txtNumber);
            Name = "FrmConsultationType";
            Text = "FrmConsultationType";
            Load += FrmConsultationType_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewConsultationTypes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumber;
        private TextBox txtDescription;
        private ComboBox cmbStatus;
        private Button btnAdd;
        private DataGridView dataGridViewConsultationTypes;
        private DataGridViewTextBoxColumn NumberColumn;
        private DataGridViewTextBoxColumn DescriptionColumn;
        private DataGridViewComboBoxColumn StatusColumn;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}