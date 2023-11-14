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
        public char Status { get; private set; }
        public ConsultationStatus DisplayStatus
        {
            get
            {
                return Status == 'A' ? ConsultationStatus.Active : ConsultationStatus.Inactive;
            }
        }

        public ConsultationType(int number, string description, ConsultationStatus status)
        {
            Number = number;
            Description = description ?? throw new ArgumentNullException(nameof(description), "Una descripción es necesaria.");
            Status = status == ConsultationStatus.Active ? 'A' : 'I';
        }
    }
}
