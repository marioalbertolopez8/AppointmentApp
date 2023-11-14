using MedicalAppModels;
using MedicalAppServices;


namespace MedicalAppUI
{
    public partial class FrmAppointmentUI : Form
    {
        private readonly PatientService _patientService; // Servicio para manejo de pacientes
        private readonly DoctorService _doctorService; // Servicio para manejo de doctores
        private readonly SpecialtyService _specialityService; // Servicio para manejo de especialidades

        private readonly AppointmentService _appointmentService;

        private DateTime selectedDateTime;

        public FrmAppointmentUI(PatientService patientService, DoctorService doctorService, SpecialtyService specialtyService, AppointmentService appointmentService)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            _specialityService = specialtyService ?? throw new ArgumentNullException(nameof(specialtyService));

            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));


            InitializeComponent();


            try
            {
                datePicker.Value = DateTime.Today.AddDays(1);
                PopulateTimeSlots(8, 18, 30); // Para establecer los horarios de atención de los dentistas

                // Completar DataGridView dgridPacient con PatientService
                var patients = patientService.GetAllPatients();
                dgridPacient.DataSource = patients.ToList();

                // Completar ListBox listDoctor con DoctorService

                var doctors = doctorService.GetAllActiveDoctors();
                foreach (var doctor in doctors)
                {
                    listDoctor.Items.Add($"{doctor.Id} -  {doctor.FirstName} {doctor.FirstLastName}");
                }

                // Completar ComboBox cboxSpeciality con SpecialtyService

                var consultationTypes = specialtyService.GetAllActiveSpecialties();
                foreach (var consultationType in consultationTypes)
                {
                    cboxSpeciality.Items.Add($"{consultationType.Number} - {consultationType.Description}");
                }


                if (dgridPacient.Rows.Count == 0)
                {
                    MessageBox.Show("No hay pacientes cargados. El formulario se cerrará ahora.");
                    this.Close();
                    return;
                }

                if (listDoctor.Items.Count == 0)
                {
                    MessageBox.Show("No hay doctores cargados. El formulario se cerrará ahora.");
                    this.Close();
                    return;
                }

                if (cboxSpeciality.Items.Count == 0)
                {
                    MessageBox.Show("No hay especialidades cargadas. El formulario se cerrará ahora.");
                    this.Close();
                    return;
                }


            }
            catch (Exception ex)
            {
                // Registrar y/o informar al usuario
                MessageBox.Show("Ocurrió un error durante la carga: " + ex.Message);
                this.Close(); // Cerrar el formulario en caso de error
            }




        }


        private void FrmAppointmentRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                List<Patient> patients = _patientService.GetAllPatients().ToList();
                // Populate your DataGridView here using the patients list. For example:
                dgridPacient.DataSource = patients;
            }
            catch (Exception ex)
            {
                // Log and/or inform the user
                MessageBox.Show("An error occurred while loading patients: " + ex.Message);
            }
        }





        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = datePicker.Value.Date;
            if (!IsDateValid(selectedDate))
            {
                datePicker.Value = DateTime.Today.AddDays(1); // Regresar a un valor valido
            }
        }

        private bool IsDateValid(DateTime date)
        {
            if (date < DateTime.Today)
            {
                MessageBox.Show("Por favor seleccione una fecha en el futuro.");
                return false;
            }
            if (date == DateTime.Today)
            {
                MessageBox.Show("Para citas en el mismo día comuníquese con el Doctor.");
                return false;
            }
            return true;
        }

        private bool ValidateForm()
        {
            if (timeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una hora para su cita.");
                return false;
            }

            return IsDateValid(datePicker.Value.Date);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            DateTime horario = SaveDateTime();

            if (!IsPatientSelected())
            {
                MessageBox.Show("Elija un paciente para continuar.");
                return;
            }

            if (!IsDoctorSelected())
            {
                MessageBox.Show("Elija un doctor para continuar.");
                return;
            }

            if (!IsConsultationTypeSelected())
            {
                MessageBox.Show("Elija un tipo de consulta para continuar.");
                return;
            }

            try
            {

                int selectedRowIndex = dgridPacient.SelectedCells[0].RowIndex;
                object valueInFirstColumn = dgridPacient.Rows[selectedRowIndex].Cells[0].Value;

                int selectedPatientId, selectedDoctorId, selectedConsultationTypeId;

                if (!int.TryParse(valueInFirstColumn.ToString(), out selectedPatientId))
                {
                    MessageBox.Show("Seleccione un paciente de la lista.");
                    return;
                }

                if (!int.TryParse(listDoctor.Text.Split('-')[0].Trim(), out selectedDoctorId))
                {
                    MessageBox.Show("Seleccione un Doctor disponible.");
                    return;
                }

                if (!int.TryParse(cboxSpeciality.Text.Split('-')[0].Trim(), out selectedConsultationTypeId))
                {
                    MessageBox.Show("Tipo de consulta inválido.");
                    return;
                }


                var appointment = _appointmentService.CreateAppointment(
                    txtId.Text,
                    horario,
                    consultationTypeId: selectedConsultationTypeId,
                    patientId: selectedPatientId,
                    doctorId: selectedDoctorId);

                MessageBox.Show("Cita agendada exitosamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sucedió un error al intentar registrar la cita: " + ex.Message);
            }
        }

        private bool IsPatientSelected()
        {
            return dgridPacient.SelectedRows.Count > 0;
        }

        private bool IsDoctorSelected()
        {
            return listDoctor.SelectedIndex >= 0;
        }

        private bool IsConsultationTypeSelected()
        {
            return cboxSpeciality.SelectedIndex >= 0;
        }


        private void PopulateTimeSlots(int startHour, int endHour, int intervalMinutes)
        {
            // Resetear valores del combobox de Hora
            timeComboBox.Items.Clear();

            // Crear los bloques de horario
            for (int hour = startHour; hour <= endHour; hour++)
            {
                for (int min = 0; min < 60; min += intervalMinutes)
                {
                    if (hour == endHour && min > 0) break; // No superar el endHour
                    DateTime timeSlot = DateTime.Today.AddHours(hour).AddMinutes(min);
                    timeComboBox.Items.Add(timeSlot.ToString("hh:mm tt"));
                }
            }

            // Marcar la primera opcion por defecto
            if (timeComboBox.Items.Count > 0)
                timeComboBox.SelectedIndex = 0;
        }

        private DateTime SaveDateTime()
        {
            // Recuperar la fecha y la hora
            DateTime selectedDate = datePicker.Value.Date;
            DateTime selectedTime = DateTime.ParseExact(timeComboBox.SelectedItem.ToString(), "hh:mm tt", null);

            // Combinar fecha y hora en selectedDateTime
            selectedDateTime = selectedDate.AddHours(selectedTime.Hour).AddMinutes(selectedTime.Minute);
            return selectedDateTime;
            // Test
            //MessageBox.Show("Fecha y hora: " + selectedDateTime.ToString());
        }


        private int GetSelectedPatientId()
        {
            return Convert.ToInt32(dgridPacient.SelectedRows[0].Cells[0].Value);
        }

        private int GetSelectedDoctorId()
        {
            // Replace with logic to get the actual doctor ID based on the selected name
            return 1; // Placeholder, replace with actual ID retrieval
        }

        private int GetSelectedConsultationTypeId()
        {
            // Replace with logic to get the actual consultation type ID based on the selected description
            return 1; // Placeholder, replace with actual ID retrieval
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }


    }
}
