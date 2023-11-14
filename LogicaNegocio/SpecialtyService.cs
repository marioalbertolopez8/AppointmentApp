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
                throw new InvalidOperationException("No se pueden añadir mas tipos de consulta.");
            }

            if (consultationTypes.Any(ct => ct != null && ct.Number == number))
            {
                throw new ArgumentException("Ya existe una consulta con ese ID.", nameof(number));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Se requiere una descripción válida.", nameof(description));
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

        public IEnumerable<ConsultationType> GetAllActiveSpecialties()
        {
            return consultationTypes.Where(s => s != null && s.Status == 'A').ToArray();
        }



        public bool UpdateConsultationType(int number, string newDescription, ConsultationStatus newStatus)
            {
            var index = Array.FindIndex(consultationTypes, 0, currentTypesCount, ct => ct.Number == number);
            if (index == -1)
            {
                throw new ArgumentException("No hay tipos de consulta con ese ID.", nameof(number));
            }

            // Se usa la nueva descripcion
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
