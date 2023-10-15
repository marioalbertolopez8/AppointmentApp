using MedicalAppModels;
using MedicalAppServices;


namespace MedicalAppUI
{
    public partial class FrmConsultationType : Form
    {
        private readonly SpecialtyService _specialtyService;

        public FrmConsultationType(SpecialtyService specialtyService)
        {
            InitializeComponent();

            this.dataGridViewConsultationTypes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConsultationTypes_RowEnter);


            _specialtyService = specialtyService ?? throw new ArgumentNullException(nameof(specialtyService));

            // Initialize status ComboBox items
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");

            // Clear existing columns
            dataGridViewConsultationTypes.Columns.Clear();

            // Configure DataGridView
            dataGridViewConsultationTypes.AutoGenerateColumns = false; // Prevent auto-creation of columns

            // Set up the columns
            var numberColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Código",
                DataPropertyName = "Number"
            };
            dataGridViewConsultationTypes.Columns.Add(numberColumn);

            var descriptionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Descripción",
                DataPropertyName = "Description"
            };
            dataGridViewConsultationTypes.Columns.Add(descriptionColumn);

            var statusColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Estado",
                DataPropertyName = "Status",
                Visible = true
            };
            dataGridViewConsultationTypes.Columns.Add(statusColumn);


            // Load existing consultation types into DataGridView
            LoadConsultationTypes();
        }


        private void FrmConsultationType_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtNumber.Text) || !int.TryParse(txtNumber.Text, out int number))
                {
                    MessageBox.Show("Please enter a valid number.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please enter a description.");
                    return;
                }

                if (cmbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please select a status.");
                    return;
                }


                // Translate ComboBox selection to ConsultationStatus enum
                ConsultationStatus consultationStatus = (ConsultationStatus)Enum.Parse(typeof(ConsultationStatus), cmbStatus.SelectedItem.ToString());

                // Verifica si se está actualizando un tipo de consulta existente
                var existingType = _specialtyService.GetAllConsultationTypes().FirstOrDefault(ct => ct.Number == number);
                if (existingType != null)
                {
                    // Actualizar el tipo de consulta existente
                    _specialtyService.UpdateConsultationType(number, existingType.Description, consultationStatus);
                    MessageBox.Show("Consultation type updated successfully.");
                }
                else
                {
                    // Agregar nuevo tipo de consulta
                    _specialtyService.AddConsultationType(number, txtDescription.Text, consultationStatus);
                    MessageBox.Show("Consultation type added successfully.");
                }

                dataGridViewConsultationTypes.ClearSelection();

                dataGridViewConsultationTypes.DataSource = null;
                dataGridViewConsultationTypes.DataSource = _specialtyService.GetAllConsultationTypes();
                dataGridViewConsultationTypes.ClearSelection(); // Clears the default selection

                // Clear the input fields
                txtNumber.Clear();
                txtDescription.Clear();
                cmbStatus.SelectedIndex = -1; // Reset combo box

                // Refresh the DataGridView
                LoadConsultationTypes();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadConsultationTypes()
        {
            dataGridViewConsultationTypes.DataSource = null;
            dataGridViewConsultationTypes.DataSource = _specialtyService.GetAllConsultationTypes();
            dataGridViewConsultationTypes.ClearSelection(); // Add this line to clear selection
        }



        private void dataGridViewConsultationTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que se ha seleccionado una fila válida
            {
                // Obtén el objeto ConsultationType de la fila seleccionada
                var selectedType = dataGridViewConsultationTypes.Rows[e.RowIndex].DataBoundItem as ConsultationType;

                if (selectedType != null)
                {
                    // Coloca los datos en los campos correspondientes para editar
                    txtNumber.Text = selectedType.Number.ToString();
                    txtDescription.Text = selectedType.Description;
                    cmbStatus.SelectedItem = selectedType.Status.ToString(); // Asegúrate de que los nombres en cmbStatus coincidan con los nombres de enum
                }
            }
        }

        private void dataGridViewConsultationTypes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the object ConsultationType from the selected row
                var selectedType = dataGridViewConsultationTypes.Rows[e.RowIndex].DataBoundItem as ConsultationType;

                if (selectedType != null)
                {
                    // Set the data in the corresponding fields for editing
                    txtNumber.Text = selectedType.Number.ToString();
                    txtDescription.Text = selectedType.Description;
                    cmbStatus.SelectedItem = selectedType.Status.ToString(); // Make sure the names in cmbStatus match the enum names
                }
            }
        }


    }
}
