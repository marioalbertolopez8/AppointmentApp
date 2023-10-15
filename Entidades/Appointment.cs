using System;

namespace MedicalAppModels
{
    public class Appointment
    {
        public int Id { get; private set; }
        public DateTime AppointmentDateTime { get; private set; }
        public ConsultationType ConsultationType { get; private set; }
        public Patient Patient { get; private set; }
        public Doctor Doctor { get; private set; }

        public Appointment(int id, DateTime appointmentDateTime, ConsultationType consultationType, Patient patient, Doctor doctor)
        {
            Id = id;
            AppointmentDateTime = appointmentDateTime;
            ConsultationType = consultationType ?? throw new ArgumentNullException(nameof(consultationType));
            Patient = patient ?? throw new ArgumentNullException(nameof(patient));
            Doctor = doctor ?? throw new ArgumentNullException(nameof(doctor));
        }
    }
}
