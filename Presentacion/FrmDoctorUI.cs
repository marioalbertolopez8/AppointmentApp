using MedicalAppServices;

namespace MedicalAppUI
{
    public partial class FrmDoctorUI : Form
    {
        private enum Mode { Add, Edit }
        private Mode _currentMode;
        private DoctorService _doctorService;

        public FrmDoctorUI(DoctorService? doctorService)
        {
            // Si doctorServices es nulo, lanzar una excepción
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));

            InitializeComponent();
            doctorService = new DoctorService();
            _currentMode = Mode.Add; // Modo inicial

            // Añadir elementos al ComboBox
            cmbStatus.Items.Add("Activo");
            cmbStatus.Items.Add("Inactivo");

            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            // Obtener todos los doctores y actualizar DataGridView
            var doctors = _doctorService.GetAllDoctors();
            dgvDoctors.DataSource = doctors.ToList();

            dgvDoctors.Columns["Id"].HeaderText = "ID";
            dgvDoctors.Columns["FirstName"].HeaderText = "Nombre";
            dgvDoctors.Columns["FirstLastName"].HeaderText = "Primer Apellido";
            dgvDoctors.Columns["SecondLastName"].HeaderText = "Segundo Apellido";
            dgvDoctors.Columns["Status"].HeaderText = "Estado";
        }

        private void ClearFields()
        {
            // Limpiar los campos de entrada
            txtId.Text = "";
            txtFirstName.Text = "";
            txtFirstLastName.Text = "";
            txtSecondLastName.Text = "";
            cmbStatus.SelectedIndex = -1; // Ninguna selección por defecto
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Intenta agregar un nuevo doctor
                _doctorService.AddDoctor(txtId.Text, txtFirstName.Text, txtFirstLastName.Text, txtSecondLastName.Text, cmbStatus.SelectedItem as string);

                MessageBox.Show("Doctor agregado exitosamente."); // Mensaje de éxito
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
                // Intenta actualizar la información del doctor
                _doctorService.UpdateDoctor(txtId.Text, txtFirstName.Text, txtFirstLastName.Text, txtSecondLastName.Text, cmbStatus.SelectedItem as string);


                MessageBox.Show("Doctor actualizado exitosamente."); // Mensaje de éxito
                RefreshDataGridView(); // Actualizar la vista de datos

                // Volver al modo 'Agregar' después de una actualización exitosa
                _currentMode = Mode.Add;
                btnToggleMode.Text = "Editar ID";
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

        private void dgvDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que la fila seleccionada sea válida
            if (e.RowIndex >= 0 && e.RowIndex < dgvDoctors.Rows.Count - 1)
            {
                _currentMode = Mode.Edit; // Cambiar a modo de edición
                btnToggleMode.Text = "Cambiar a Agregar";

                // Rellenar campos de entrada con datos del doctor seleccionado
                DataGridViewRow row = dgvDoctors.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtFirstName.Text = row.Cells[1].Value.ToString();
                txtFirstLastName.Text = row.Cells[2].Value.ToString();
                txtSecondLastName.Text = row.Cells[3].Value.ToString();
                cmbStatus.SelectedItem = (char)row.Cells[4].Value == 'A' ? "Activo" : "Inactivo"; // Establecer estado

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
