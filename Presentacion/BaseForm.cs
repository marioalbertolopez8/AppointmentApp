using MedicalAppServices;


namespace MedicalAppUI
{
    public partial class BaseForm : Form
    {
        private readonly SpecialtyService _specialityService;
        private readonly DoctorService _doctorServices;
        private readonly PatientService _patientServices;

        private readonly AppointmentService _appointmentServices;


        public BaseForm()
        {
            InitializeComponent();
            // Initialize the SpecialtyService instance

            _doctorServices = new DoctorService();
            _patientServices = new PatientService();
            _specialityService = new SpecialtyService();

            _appointmentServices = new AppointmentService(_doctorServices, _patientServices, _specialityService);
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        private void registroDeCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new instance of the appointment registration form
            FrmAppointmentUI appointmentForm = new FrmAppointmentUI(_patientServices, _doctorServices, _specialityService, _appointmentServices);

            // Show the form
            try
            {
                appointmentForm.ShowDialog();
            }
            catch (ObjectDisposedException)
            {
                MessageBox.Show("Agregue los componentes faltantes para poder agendar adecuadamente.");
            }
        }

        private void registroTiposDeConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultationType consultationTypeForm = new FrmConsultationType(_specialityService);

            consultationTypeForm.Show();
        }

        private void administraciónDeDoctoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDoctorUI doctorForm = new FrmDoctorUI(_doctorServices);
            doctorForm.Show();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void administraciónDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPatientUI patientForm = new FrmPatientUI(_patientServices);
            patientForm.Show();
        }

        private void citasPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAppointmentReportByClient reportByClientForm = new FrmAppointmentReportByClient(_appointmentServices, _doctorServices, _patientServices);
            reportByClientForm.Show();
        }
    }
}
