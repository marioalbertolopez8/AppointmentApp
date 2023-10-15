using System;

namespace MedicalAppModels
{

    public enum DoctorStatus
    {
        Active,
        Inactive
    }

    public class Doctor
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string FirstLastName { get; private set; }
        public string SecondLastName { get; private set; }
        public DoctorStatus Status { get; private set; }

        public Doctor(int id, string firstName, string firstLastName, string secondLastName, DoctorStatus status)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.FirstLastName = firstLastName ?? throw new ArgumentNullException(nameof(firstLastName));
            SecondLastName = secondLastName ?? throw new ArgumentNullException(nameof(secondLastName));
            Status = status;
        }



        public void UpdateDetails(string newFirstName, string newFirstLastName, string newSecondLastName, DoctorStatus newStatus)
        {
            if (string.IsNullOrWhiteSpace(newFirstName))
                throw new ArgumentException("First name must not be empty.", nameof(newFirstName));
            if (string.IsNullOrWhiteSpace(newFirstLastName))
                throw new ArgumentException("First last name must not be empty.", nameof(newFirstLastName));
            if (string.IsNullOrWhiteSpace(newSecondLastName))
                throw new ArgumentException("Second last name must not be empty.", nameof(newSecondLastName));

            FirstName = newFirstName;
            FirstLastName = newFirstLastName;
            SecondLastName = newSecondLastName;
            Status = newStatus;
        }
    }
}
