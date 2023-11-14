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
            FirstName = newFirstName;
            FirstLastName = newFirstLastName;
            SecondLastName = newSecondLastName;
            Status = newStatus;
        }
    }
}
