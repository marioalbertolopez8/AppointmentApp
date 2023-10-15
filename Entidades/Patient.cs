namespace MedicalAppModels
{
    public enum Gender
    {
        No_Especificado,
        Masculino,
        Femenino
    }

    public class Patient
    {
        // Propiedades
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName1 { get; private set; }
        public string LastName2 { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }

        // Constructor
        public Patient(int id, string firstName, string lastName1, string lastName2, DateTime birthDate, Gender gender)
        {
            Id = id;
            FirstName = firstName;
            LastName1 = lastName1;
            LastName2 = lastName2;
            BirthDate = birthDate;
            Gender = gender;
        }

        public void UpdateDetails(DateTime newBirthDate, Gender newGender)
        {
            if (newBirthDate >= DateTime.Today)
            {
                throw new ArgumentException("Fecha de nacimiento no puede ser en el futuro.", nameof(newBirthDate));
            }

            // Update properties
            BirthDate = newBirthDate;
            Gender = newGender;
        }


    }

}
