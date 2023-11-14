using MedicalAppServices;


namespace MedicalAppUI
{
    public partial class FrmAppointmentReportByDate : Form
    {
        private readonly AppointmentService appointmentService;
        private readonly DoctorService doctorService;
        private readonly PatientService patientService;

        public FrmAppointmentReportByDate(AppointmentService appointmentService,
                                          DoctorService doctorService,
                                          PatientService patientService)
        {
            InitializeComponent();

            // Inicializar los servicios
            this.appointmentService = appointmentService;
            this.doctorService = doctorService;
            this.patientService = patientService;

            // Cargar las fechas en el ComboBox
            LoadDates();
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
                HeaderText = "Numero de Cita", // Título de la columna
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
                HeaderText = "Paciente", // Título de la columna
                ReadOnly = true, // La columna será solo de lectura
                ValueType = typeof(string) // El tipo de datos de la columna
            };
            DataGridViewTextBoxColumn doctorNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "colDoctorName",
                HeaderText = "Doctor", // Título de la columna
                ReadOnly = true, // La columna será solo de lectura
                ValueType = typeof(string) // El tipo de datos de la columna
            };

            // Añadir las columnas al control DataGridView
            dgridReportOutput.Columns.AddRange(new DataGridViewColumn[] { idColumn, dateTimeColumn, consultationTypeColumn, patientNameColumn, doctorNameColumn });
        }

        private void LoadDates()
        {
            // Obtener las fechas de las citas
            var appointments = appointmentService.GetAppointmentDates();

            // Limpiar los elementos existentes
            cBoxSearch.Items.Clear();

            foreach (var appointment in appointments)
            {
                if (appointment != null)
                {
                    // Considerar solo la parte de la fecha
                    DateTime dateOnly = appointment.AppointmentDateTime.Date;

                    // Verificar si la fecha ya está en el ComboBox
                    bool alreadyExists = false;
                    foreach (var item in cBoxSearch.Items)
                    {
                        // Si el elemento es una fecha y esa fecha ya existe, marcamos que ya existe
                        if (item is DateTime existingDate && existingDate.Date == dateOnly)
                        {
                            alreadyExists = true;
                            break; // Salir del bucle porque ya encontramos una fecha existente
                        }
                    }

                    // Si la fecha no está en el ComboBox, la agregamos
                    if (!alreadyExists)
                    {
                        cBoxSearch.Items.Add(dateOnly);
                    }
                }
            }

            // Carga los datos en el ComboBox
            cBoxSearch.DisplayMember = "Date";
            cBoxSearch.ValueMember = "Date";
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Limpiar el DataGridView
            dgridReportOutput.Rows.Clear();

            if (cBoxSearch.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una fecha para realizar la búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedItem = (DateTime)cBoxSearch.SelectedItem;
            var selectedValue = selectedItem.Date;

            foreach (var a in appointmentService.GetAppointmentDates())
            {
                if (a != null && a.AppointmentDateTime.Date == selectedValue)
                {
                    dgridReportOutput.Rows.Add(a.Id, a.AppointmentDateTime, a.ConsultationType.Number, a.Patient.FirstName + " " + a.Patient.LastName1 + " " + a.Patient.LastName2, a.Doctor.FirstName + " " + a.Doctor.FirstLastName + " " + a.Doctor.SecondLastName);
                }
            }
        }
    }
}
