using MedicalAppServices;
using System.Diagnostics;

namespace MedicalAppUI
{
    public partial class FrmAppointmentReportByDoctor : Form
    {
        private readonly AppointmentService appointmentService;
        private readonly DoctorService doctorService;
        private readonly PatientService patientService;

        public FrmAppointmentReportByDoctor(AppointmentService appointmentService, DoctorService doctorService, PatientService patientService)
        {
            InitializeComponent();
            this.appointmentService = appointmentService;
            this.doctorService = doctorService;
            this.patientService = patientService;

            // Cargar los doctores en el ComboBox
            LoadDoctors();
            SetUpDataGridView();
        }

        private void SetUpDataGridView()
        {
            // Limpiar las columnas existentes
            dgridReportOutput.Columns.Clear();

            // Crear las columnas y establecer sus propiedades
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID", // Título de la columna
                ReadOnly = true, // La columna será solo de lectura
                ValueType = typeof(int) // El tipo de datos de la columna
            };
            DataGridViewTextBoxColumn dateTimeColumn = new DataGridViewTextBoxColumn
            {
                Name = "colDateTime",
                HeaderText = "Fecha/Hora", // Título de la columna
                ReadOnly = true, // La columna será solo de lectura
                ValueType = typeof(string) // El tipo de datos de la columna
            };
            DataGridViewTextBoxColumn consultationTypeColumn = new DataGridViewTextBoxColumn
            {
                Name = "colConsultationType",
                HeaderText = "Tipo de Consulta", // Título de la columna
                ReadOnly = true, // La columna será solo de lectura
                ValueType = typeof(string) // El tipo de datos de la columna
            };
            DataGridViewTextBoxColumn patientNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "colPatientName",
                HeaderText = "Nombre del Paciente", // Título de la columna
                ReadOnly = true, // La columna será solo de lectura
                ValueType = typeof(string) // El tipo de datos de la columna
            };

            // Añadir las columnas al control DataGridView
            dgridReportOutput.Columns.AddRange(new DataGridViewColumn[] { idColumn, dateTimeColumn, consultationTypeColumn, patientNameColumn });


        }

        private void LoadDoctors()
        {
            // Obtener los doctores del servicio
            var doctors = doctorService.GetAllDoctors();

            // Limpiar el ComboBox
            cBoxSearch.Items.Clear();

            foreach ( var doctor in doctors )
            {
                // Agregar el doctor al ComboBox
                cBoxSearch.Items.Add(new { Text = doctor.FirstName + " " + doctor.FirstLastName + " " + doctor.SecondLastName, Value = doctor.Id });
            }
            cBoxSearch.DisplayMember = "Text";
            cBoxSearch.ValueMember = "Value";
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Limpiar los datos antiguos
            //`
            dgridReportOutput.Rows.Clear();

            if (cBoxSearch.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un doctor.");
                return;
            }

            var selectedItem = (dynamic)cBoxSearch.SelectedItem;
            var selectedValue = Convert.ToString(selectedItem.Value);
          
            int selectedValueId = int.Parse(selectedValue);

            var appointments = appointmentService.GetAppointmentsByDoctor(selectedValueId);
            
            foreach (var appointment in appointments)
            {
                var patient = patientService.GetPatient(appointment.Patient.Id);

                // Añadir fila al DataGridView
                dgridReportOutput.Rows.Add(
                    appointment.Id,
                    appointment.AppointmentDateTime.ToString("g"), // Formato corto de fecha y hora
                    appointment.ConsultationType.Description,
                    patient.FirstName + patient.LastName1 + patient.LastName2
                );
            }
        }

    }
}
