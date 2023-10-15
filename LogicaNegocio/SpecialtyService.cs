using MedicalAppModels;


namespace MedicalAppServices
{
    public class SpecialtyService
    {
        private ConsultationType[] consultationTypes;
        private const int MAX_CONSULTATION_TYPES = 10;
        private int currentTypesCount = 0; // Lleva la cuenta de cuántos tipos de consulta se han añadido

        public SpecialtyService()
        {
            consultationTypes = new ConsultationType[MAX_CONSULTATION_TYPES];
        }

        public bool AddConsultationType(int number, string description, ConsultationStatus status)
        {
            if (currentTypesCount >= MAX_CONSULTATION_TYPES)
            {
                throw new InvalidOperationException("Cannot add more consultation types, limit reached.");
            }

            if (consultationTypes.Any(ct => ct != null && ct.Number == number))
            {
                throw new ArgumentException("A consultation type with the same number already exists.", nameof(number));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description is required and cannot be empty or whitespace.", nameof(description));
            }

            var consultationType = new ConsultationType(number, description, status);
            consultationTypes[currentTypesCount] = consultationType;
            currentTypesCount++;

            return true;
        }

        public ConsultationType[] GetAllConsultationTypes()
        {
            // Retorna una copia del arreglo actual hasta el indice de elementos añadidos para evitar elementos nulos
            var result = new ConsultationType[currentTypesCount];
            Array.Copy(consultationTypes, result, currentTypesCount);
            return result;
        }

        public bool UpdateConsultationType(int number, string newDescription, ConsultationStatus newStatus)
            {
            var index = Array.FindIndex(consultationTypes, 0, currentTypesCount, ct => ct.Number == number);
            if (index == -1)
            {
                throw new ArgumentException("No consultation type found with the provided number.", nameof(number));
            }

            // Use the new description here instead of the old one
            var updatedConsultationType = new ConsultationType(number, newDescription, newStatus);

            // Updating the consultation type
            consultationTypes[index] = updatedConsultationType;

            return true;
        }

        public ConsultationType? GetConsultationType(int id)
        {
            for (int i = 0; i < currentTypesCount; i++)
            {
                if (consultationTypes[i] != null && consultationTypes[i].Number == id)
                {
                    return consultationTypes[i];
                }
            }
            return null; // Null si no existe el paciente con ese Id
        }


    }
}
