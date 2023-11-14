using MedicalAppModels;
using System;

namespace MedicalAppLogic
{
    public class PatientLogic
    {
        private readonly Patient[] patients; // Array para almacenar los pacientes
        private int currentPatientCount; // Contador de pacientes actuales
        private const int MAX_PATIENTS = 20; // Máximo número de pacientes permitidos

        public PatientLogic()
        {
            patients = new Patient[MAX_PATIENTS]; // Inicializando el array con el máximo de pacientes
            currentPatientCount = 0; // Inicializando el contador de pacientes
        }



        public IEnumerable<Patient> GetAllPatients()
        {
            // Devolver solo los elementos que no sean null
            return patients.Where(p => p != null).ToArray();
        }



        public bool AddPatient(string idString, string firstName, string firstLastName, 
            string secondLastName, DateTime birthDate, string gender)
        {
            ValidatePatientDetails(idString, firstName, firstLastName, secondLastName, birthDate, gender); // Validación común

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


        private bool IsBirthdateValid(DateTime birthDate)
        {
            // Obtener la fecha de mañana, con la hora establecida a medianoche
            DateTime tomorrowAtMidnight = DateTime.Today.AddDays(1);

            // Si la fecha de nacimiento es igual o posterior a mañana (en el futuro), devolvemos false
            return birthDate < tomorrowAtMidnight;
        }

        private void ValidatePatientDetails(string idString, string firstName, string firstLastName, string secondLastName, DateTime birthDate, string gender)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(firstLastName) || string.IsNullOrWhiteSpace(secondLastName))
            {
                throw new ArgumentException("Nombre y apellidos son obligatorios y no pueden estar vacíos o ser solo espacios.");
            }
            if (gender == null)
            {
                throw new ArgumentException("El género es obligatorio y no puede ser nulo.", nameof(gender));

            }
            if (!IsBirthdateValid(birthDate))
            {
                throw new ArgumentException("La fecha de nacimiento no puede ser en el futuro.", nameof(birthDate));
            }
        }



        public void UpdatePatient(string idString, DateTime newBirthDate, string genderString)
        {

            ValidatePatientDetails(idString, "a", "a", "a", newBirthDate, genderString); // Validación común
            if (!int.TryParse(idString, out int id))
            {
                throw new ArgumentException("El ID proporcionado no es válido. Debe ser un número entero.", nameof(idString));
            }
            //Find the patient by ID
            var existingpatient = Array.Find(patients, p => p != null && p.Id == id);

                    if (existingpatient == null)
                    {
                        throw new ArgumentException("No existe paciente con ese ID.");
                    }

            Gender newGender;

            if (genderString.Equals("Masculino", StringComparison.OrdinalIgnoreCase))
            {
                newGender = Gender.Masculino;
            }
            else if (genderString.Equals("Femenino", StringComparison.OrdinalIgnoreCase))
            {
                newGender = Gender.Femenino;
            }
            else
            {
                newGender = Gender.No_Especificado;
            }



            existingpatient.UpdateDetails(newBirthDate, newGender);
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
