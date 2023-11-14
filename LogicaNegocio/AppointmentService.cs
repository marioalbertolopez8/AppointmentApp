using MedicalAppModels;
using System;


namespace MedicalAppLogic
{
    public class AppointmentService
    {
        private Appointment[] appointments; // Array para almacenar las citas
        private int appointmentIndex; // Índice para llevar el conteo de las citas agregadas
        private readonly DoctorLogic doctorService;
        private readonly PatientLogic patientService;
        private readonly SpecialtyLogic specialtyService;

        public AppointmentService(DoctorLogic doctorService, PatientLogic patientService, SpecialtyLogic specialtyService)
        {
            appointments = new Appointment[20]; 
            appointmentIndex = 0;
            this.doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            this.patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            this.specialtyService = specialtyService ?? throw new ArgumentNullException(nameof(specialtyService));
        }

        public IEnumerable<Appointment> GetAppointmentDates()
        {
            // Devolver solo los elementos que no sean null
            return appointments.Where(d => d != null).ToArray();
        }

public Appointment CreateAppointment(string StringAppointmentId, DateTime dateTime, int consultationTypeId, int patientId, int doctorId)
        {
            // Verificar si el array ya está lleno
            if (appointmentIndex >= appointments.Length)
            {
                throw new InvalidOperationException("No se pueden agregar más citas, se ha alcanzado el máximo permitido.");
            }

            if (!int.TryParse(StringAppointmentId, out int appointmentId))
            {
                throw new ArgumentException("El ID proporcionado no es válido. Debe ser un número entero.", nameof(StringAppointmentId));
            }

            if (appointments.Any(a => a != null && a.Id == appointmentId))
            {
                throw new InvalidOperationException($"Ya existe una cita con el ID proporcionado: {appointmentId}. Los IDs de las citas deben ser únicos.");
            }

            // Validar si el doctor existe
            var doctor = doctorService.GetDoctor(doctorId);
            if (doctor == null)
            {
                throw new ArgumentException("Doctor no encontrado", nameof(doctorId));
            }

            // Validar si el paciente existe
            var patient = patientService.GetPatient(patientId);
            if (patient == null)
            {
                throw new ArgumentException("Paciente no encontrado", nameof(patientId));
            }

            // Validar si el tipo de consulta existe
            var consultationType = specialtyService.GetConsultationType(consultationTypeId);
            if (consultationType == null)
            {
                throw new ArgumentException("Tipo de consulta no encontrado", nameof(consultationTypeId));
            }

            // Verificar si el doctor ya tiene una cita a esa hora
            foreach (var a in appointments)
            {
                if (a != null && a.Doctor.Id == doctorId && a.AppointmentDateTime == dateTime)
                {
                    throw new InvalidOperationException("El doctor ya tiene una cita programada para esta fecha y hora.");
                }
            }

           //Creacion nuevo appointment

            var appointment = new Appointment(appointmentId, dateTime, consultationType, patient, doctor);
            
            //Se añade al array
            appointments[appointmentIndex++] = appointment; // Agregar la cita y luego incrementar el índice

            return appointment;
        }

        public Appointment[] GetAllAppointments()
        {
            // Filtramos los elementos nulos y creamos un nuevo array
            var validAppointments = appointments.Where(a => a != null).ToArray();
            return validAppointments;
        }


        public Appointment[] GetAppointmentsByDate(DateTime date)
        {
            Appointment[] result = new Appointment[appointments.Length];
            int count = 0;

            for (int i = 0; i < appointments.Length; i++)
            {
                if (appointments[i] != null && appointments[i].AppointmentDateTime.Date == date.Date)
                {
                    result[count++] = appointments[i];
                }
            }

            // Reducir el tamaño del array para excluir posiciones vacías
            //Por referencia para que se refleje en el método llamador 
            Array.Resize(ref result, count);
            return result;
        }

        public Appointment[] GetAppointmentsByDoctor(int doctorId)
        {
            Appointment[] result = new Appointment[appointments.Length];
            int count = 0;

            for (int i = 0; i < appointments.Length; i++)
            {
                if (appointments[i] != null && appointments[i].Doctor.Id == doctorId)
                {
                    result[count++] = appointments[i];
                }
            }

            // Reducir el tamaño del array para excluir posiciones vacías
            Array.Resize(ref result, count);
            return result;
        }

        public Appointment[] GetAppointmentsByPatient(int patientId)
        {
            Appointment[] result = new Appointment[appointments.Length];
            int count = 0;

            for (int i = 0; i < appointments.Length; i++)
            {
                if (appointments[i] != null && appointments[i].Patient.Id == patientId)
                {
                    result[count++] = appointments[i];
                }
            }

            // Reducir el tamaño del array para excluir posiciones vacías
            Array.Resize(ref result, count);
            return result;
        }
    }
}
