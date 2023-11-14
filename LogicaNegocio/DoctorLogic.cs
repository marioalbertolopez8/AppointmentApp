using MedicalAppModels;

namespace MedicalAppLogic
{
    public class DoctorLogic
    {
        private readonly Doctor[] doctors; // Array para almacenar los doctores
        private int currentDoctorCount; // Contador de doctores actuales
        private const int MAX_DOCTORS = 4; // Máximo número de doctores permitidos

        public DoctorLogic()
        {
            doctors = new Doctor[MAX_DOCTORS]; // Inicializando el array con el máximo de doctores
            currentDoctorCount = 0; // Inicializando el contador de doctores
        }



        public IEnumerable<Doctor> GetAllDoctors()
        {
            // Devolver solo los elementos que no sean null
            return doctors.Where(d => d != null).ToArray();
        }

        public IEnumerable<Doctor> GetAllActiveDoctors()
        {
            return doctors.Where(d => d != null && d.Status == DoctorStatus.Active).ToArray();
        }


        public bool AddDoctor(string idString, string firstName, string firstLastName, string secondLastName, 
            string status)
        {
            ValidateDoctorDetails(idString, firstName, firstLastName, secondLastName, status); // Validación común

            // Validaciones específicas de AddDoctor
            if (currentDoctorCount >= MAX_DOCTORS)
            {
                throw new InvalidOperationException("No se pueden agregar más doctores, se alcanzó el límite.");
            }

            if (!int.TryParse(idString, out int id))
            {
                throw new ArgumentException("El ID proporcionado no es válido. Debe ser un número entero.", nameof(idString));
            }

            if (doctors.Any(d => d != null && d.Id == id))
            {
                throw new ArgumentException("Ya existe un doctor con el mismo ID.", nameof(id));
            }

            DoctorStatus doctorStatus = GetStatusChar(status) == 'A' ? DoctorStatus.Active : DoctorStatus.Inactive;

            var doctor = new Doctor(id, firstName, firstLastName, secondLastName, doctorStatus);
            doctors[currentDoctorCount] = doctor;
            currentDoctorCount++;

            return true;
        }

        public void UpdateDoctor(string idString, string firstName, string firstLastName, string secondLastName, string status)
        {
            ValidateDoctorDetails(idString, firstName, firstLastName, secondLastName, status); // Validación común

            if (!int.TryParse(idString, out int id))
            {
                throw new ArgumentException("El ID proporcionado no es válido. Debe ser un número entero.", nameof(idString));
            }

            var existingDoctor = doctors.FirstOrDefault(d => d != null && d.Id == id);
            if (existingDoctor == null)
            {
                throw new ArgumentException("No se encontró un doctor con el ID proporcionado.", nameof(id));
            }

            DoctorStatus doctorStatus = GetStatusChar(status) == 'A' ? DoctorStatus.Active : DoctorStatus.Inactive;

            existingDoctor.UpdateDetails(firstName, firstLastName, secondLastName, doctorStatus);
        }


        private void ValidateDoctorDetails(string idString, string firstName, string firstLastName, string secondLastName, string status)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(firstLastName) || string.IsNullOrWhiteSpace(secondLastName))
            {
                throw new ArgumentException("Nombre y apellidos son obligatorios y no pueden estar vacíos o ser solo espacios.");
            }

            if (status == null)
            {
                throw new ArgumentException("El estado es obligatorio y no puede ser nulo.", nameof(status));
            }

            if (!status.Equals("Activo", StringComparison.OrdinalIgnoreCase) && !status.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("El estado proporcionado no es válido. Debe ser 'Activo' o 'Inactivo'.", nameof(status));
            }
        }

        private char GetStatusChar(string status)
        {
            return status.Equals("Activo", StringComparison.OrdinalIgnoreCase) ? 'A' : 'I';
        }

        public Doctor? GetDoctor(int id)
        {
            for (int i = 0; i < currentDoctorCount; i++)
            {
                if (doctors[i] != null && doctors[i].Id == id)
                {
                    return doctors[i];
                }
            }
            return null; // Returns null if no doctor is found with the given ID
        }



    }
}
