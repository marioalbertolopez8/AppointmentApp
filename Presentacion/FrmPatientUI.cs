using MedicalAppServices;

namespace MedicalAppUI
{
    public partial class FrmPatientUI : Form
    {
        private enum Mode { Add, Edit }
        private Mode _currentMode;
        private PatientService _patientService;

        public FrmPatientUI(PatientService? patientService)
        {
            // Si patientServices es nulo, lanzar una excepción
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));

            InitializeComponent();
            patientService = new PatientService();
            _currentMode = Mode.Add; // Modo inicial

            // Añadir elementos al ComboBox
            
            cmbGenero.Items.Add("Femenino");
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("No_Definido");


            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            // Obtener todos los patientes y actualizar DataGridView
            var patients = _patientService.GetAllPatients();
            dgvPatients.DataSource = patients.ToList();

            dgvPatients.Columns["Id"].HeaderText = "ID";
            dgvPatients.Columns["FirstName"].HeaderText = "Nombre";
            dgvPatients.Columns["LastName1"].HeaderText = "Primer Apellido";
            dgvPatients.Columns["LastName2"].HeaderText = "Segundo Apellido";
            dgvPatients.Columns["Gender"].HeaderText = "Genero";
            dgvPatients.Columns["BirthDate"].HeaderText = "Fecha Nacimiento";

        }

        private void ClearFields()
        {
            // Limpiar los campos de entrada
            txtId.Text = "";
            txtFirstName.Text = "";
            txtFirstLastName.Text = "";
            txtSecondLastName.Text = "";
            cmbGenero.SelectedIndex = -1; // Ninguna selección por defecto
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Intenta agregar un nuevo patient
                _patientService.AddPatient(txtId.Text, txtFirstName.Text, txtFirstLastName.Text, txtSecondLastName.Text, dateTimePickerBirthDay.Value, cmbGenero.SelectedItem as string );

                MessageBox.Show("Patient agregado exitosamente."); // Mensaje de éxito
                RefreshDataGridView(); // Actualizar la vista de datos
            }
            catch (ArgumentException ex)
            {
                // Mensaje de error para el usuario, en caso de error conocido
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                // Mensaje de error genérico
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Intenta actualizar la información del patient
                //_patientService.UpdatePatient(txtId.Text, txtFirstName.Text, txtFirstLastName.Text, txtSecondLastName.Text, cmbStatus.SelectedItem as string);


                MessageBox.Show("Patient actualizado exitosamente."); // Mensaje de éxito
                RefreshDataGridView(); // Actualizar la vista de datos

                // Volver al modo 'Agregar' después de una actualización exitosa
                _currentMode = Mode.Add;
                btnToggleMode.Text = "Cambiar a Edición";
                ClearFields(); // Limpiar campos de entrada

                // Controlar la disponibilidad de controles basados en el modo
                txtId.Enabled = true;
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                // Mensaje de error para el usuario, en caso de error conocido
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                // Mensaje de error genérico
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message);
            }
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que la fila seleccionada sea válida
            if (e.RowIndex >= 0 && e.RowIndex < dgvPatients.Rows.Count - 1)
            {
                _currentMode = Mode.Edit; // Cambiar a modo de edición
                btnToggleMode.Text = "Cambiar a Agregar";

                // Rellenar campos de entrada con datos del patient seleccionado
                DataGridViewRow row = dgvPatients.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtFirstName.Text = row.Cells[1].Value.ToString();
                txtFirstLastName.Text = row.Cells[2].Value.ToString();
                txtSecondLastName.Text = row.Cells[3].Value.ToString();
                cmbGenero.SelectedItem = (char)row.Cells[4].Value == 'A' ? "Activo" : "Inactivo"; // Establecer estado

                // Controlar la disponibilidad de controles basados en el modo
                txtId.Enabled = false;
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
            }
        }

        private void btnToggleMode_Click_1(object sender, EventArgs e)
        {
            // Cambiar entre modos 'Agregar' y 'Editar'
            if (_currentMode == Mode.Add)
            {
                _currentMode = Mode.Edit;
                btnToggleMode.Text = "Cancelar";
            }
            else
            {
                _currentMode = Mode.Add;
                btnToggleMode.Text = "Editar ID";
                ClearFields(); // Limpiar campos de entrada
            }

            // Controlar la disponibilidad de controles basados en el modo
            txtId.Enabled = _currentMode == Mode.Add;
            btnUpdate.Enabled = _currentMode == Mode.Edit;
            btnAdd.Enabled = _currentMode == Mode.Add;
        }
    }
}
