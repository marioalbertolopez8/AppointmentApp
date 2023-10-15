using MedicalAppModels;

namespace MedicalAppServices
{
    public class PatientService
    {
        private readonly Patient[] patients; // Array para almacenar los pacientes
        private int currentPatientCount; // Contador de pacientes actuales
        private const int MAX_PATIENTS = 4; // Máximo número de pacientes permitidos

        public PatientService()
        {
            patients = new Patient[MAX_PATIENTS]; // Inicializando el array con el máximo de pacientes
            currentPatientCount = 0; // Inicializando el contador de pacientes
        }



        public IEnumerable<Patient> GetAllPatients()
        {
            // Devolver solo los elementos que no sean null
            return patients.Where(d => d != null).ToArray();
        }



        public bool AddPatient(string idString, string firstName, string firstLastName, 
            string secondLastName, DateTime birthDate, string gender)
        {
            //ValidatePatientDetails(idString, firstName, firstLastName, secondLastName,birthDate, gender); // Validación común

            // Validaciones específicas de AddPatient
            if (currentPatientCount >= MAX_PATIENTS)
            {
                throw new InvalidOperationException("No se pueden agregar más pacientes, se alcanzó el límite.");
            }

            if (!int.TryParse(idString, out int id))
            {
                throw new ArgumentException("El ID proporcionado no es válido. Debe ser un número entero.", nameof(idString));
            }

            if (patients.Any(d => d != null && d.Id == id))
            {
                throw new ArgumentException("Ya existe un patient con el mismo ID.", nameof(id));
            }

            Gender newGender;

            if (gender.Equals("Masculino", StringComparison.OrdinalIgnoreCase))
            {
                newGender = Gender.Masculino;
            }
            else if (gender.Equals("Femenino", StringComparison.OrdinalIgnoreCase))
            {
                newGender = Gender.Femenino;
            }
            else
            {
                newGender = Gender.No_Especificado;
            }
            
               
            var patient = new Patient(id, firstName, firstLastName, secondLastName, birthDate, 
                newGender); 
            patients[currentPatientCount] = patient;
            currentPatientCount++;

            return true;
        }




        private void ValidatePatientDetails(string idString, string firstName, string firstLastName, string secondLastName, string status)
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

        private char GetGenderChar(string gender)
        {
            if (string.IsNullOrEmpty(gender) || gender.Length < 1)
            {
                throw new ArgumentException("Invalid gender string.", nameof(gender));
            }

            // Convert the first letter of the gender to uppercase and return it as a char
            return char.ToUpper(gender[0]);
        }






        public void UpdatePatientDetails(int id, DateTime newBirthDate, char newGender)
                {
                    // Find the patient by ID
                    var patient = Array.Find(patients, p => p != null && p.Id == id);

                    if (patient == null)
                    {
                        throw new ArgumentException("No patient with the specified ID exists.");
                    }

                    // Update the patient's birth date
                    //patient.UpdateBirthDate(newBirthDate);

                    // Update the patient's gender
                    Gender gender = newGender switch
                    {
                        'F' => Gender.Femenino,
                        'M' => Gender.Masculino,
                        'N' => Gender.No_Especificado,
                        _ => throw new ArgumentException("Invalid gender. Gender must be 'F' for Female, 'M' for Male, or 'N' for Unspecified.", nameof(newGender))
                    };

                    //patient.UpdateGender(gender);
                }


        private void ValidatePatient(int id, string firstName, string lastName1, string lastName2, DateTime birthDate, char gender)
        {
            // Check if the ID is already used
            if (Array.Exists(patients, p => p != null && p.Id == id))
            {
                throw new InvalidOperationException("A patient with this ID already exists.");
            }

            // Check for valid names and last names
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName1) || string.IsNullOrWhiteSpace(lastName2))
            {
                throw new ArgumentException("Names and last names cannot be null or whitespace.");
            }

            // Check for valid birth date
            if (birthDate >= DateTime.Today)
            {
                throw new ArgumentException("Birth date should be in the past.", nameof(birthDate));
            }

            // Check for valid gender
            if (gender != 'F' && gender != 'M' && gender != 'N')
            {
                throw new ArgumentException("Invalid gender. Gender must be 'F' for Female, 'M' for Male, or 'N' for Unspecified.", nameof(gender));
            }
        }

        public Patient? GetPatient(int id)
        {
            for (int i = 0; i < currentPatientCount; i++)
            {
                if (patients[i] != null && patients[i].Id == id)
                {
                    return patients[i];
                }
            }
            return null; // Null si no existe el paciente con ese Id
        }

    }
}
