namespace MedicalAppModels
{
    public enum ConsultationStatus
    {
        Active,
        Inactive
    }

    public class ConsultationType
    {
        public int Number { get; private set; }
        public string Description { get; private set; }
        public char Status { get; private set; } // Use char to store 'A' or 'I'
        public ConsultationStatus DisplayStatus // Use enum for displaying
        {
            get
            {
                return Status == 'A' ? ConsultationStatus.Active : ConsultationStatus.Inactive;
            }
        }

        public ConsultationType(int number, string description, ConsultationStatus status)
        {
            Number = number;
            Description = description ?? throw new ArgumentNullException(nameof(description), "Es necesaria.");
            Status = status == ConsultationStatus.Active ? 'A' : 'I'; // Store 'A' or 'I'
        }
    }
}
