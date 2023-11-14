using MedicalAppLogic;
using System.Diagnostics;


namespace MedicalAppUI
{
    public partial class FrmAppointmentReportByClient : Form
    {
        private readonly AppointmentService appointmentService;
        private readonly DoctorLogic doctorService;
        private readonly PatientLogic patientService;

        public FrmAppointmentReportByClient(AppointmentService appointmentService,
                                            DoctorLogic doctorService,
                                            PatientLogic patientService)
        {
            InitializeComponent();


            // Inicializar los servicios
            this.appointmentService = appointmentService;
            this.doctorService = doctorService;
            this.patientService = patientService;

            // Cargar los pacientes en el ComboBox
            LoadPatients();
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
            DataGridViewTextBoxColumn doctorNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "colDoctorName",
                HeaderText = "Nombre del Doctor", // Título de la columna
                ReadOnly = true, // La columna será solo de lectura
                ValueType = typeof(string) // El tipo de datos de la columna
            };

            // Agregar las columnas al DataGridView
            dgridReportOutput.Columns.AddRange(new DataGridViewColumn[] { idColumn, dateTimeColumn, consultationTypeColumn, doctorNameColumn });
        }


        private void LoadPatients()
        {
            var patients = patientService.GetAllPatients(); //
            cBoxSearch.Items.Clear();
            foreach (var patient in patients)
            {
                string displayText = $"{patient.Id} - {patient.FirstName} {patient.LastName1} {patient.LastName2}";
                cBoxSearch.Items.Add(new { Text = displayText, Value = patient.Id });
            }

            cBoxSearch.DisplayMember = "Text";
            cBoxSearch.ValueMember = "Value";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Limpiar los datos antiguos
            dgridReportOutput.Rows.Clear();

            if (cBoxSearch.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un paciente.");
                return;
            }

            var selectedItem = (dynamic)cBoxSearch.SelectedItem;
            var selectedValue = Convert.ToString(selectedItem.Value);


            //Para debug
            string debugValue = selectedValue.ToString(); 
            Debug.WriteLine(debugValue);


            int selectedValueId = int.Parse(selectedValue);

            var appointments = appointmentService.GetAppointmentsByPatient(selectedValueId);


            foreach (var appointment in appointments)
            {
                var doctor = doctorService.GetDoctor(appointment.Doctor.Id);

                // Añadir fila al DataGridView
                dgridReportOutput.Rows.Add(
                    appointment.Id,
                    appointment.AppointmentDateTime.ToString("g"), // Formato corto de fecha y hora
                    appointment.ConsultationType.Description,
                    doctor.FirstName + doctor.FirstLastName + doctor.SecondLastName
                );
            }


        }

    }
}
