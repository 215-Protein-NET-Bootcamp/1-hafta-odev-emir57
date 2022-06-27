using InterestApi.Abstract.Validation;

namespace InterestApi.Helpers
{
    public class ValidationHelper
    {
        /// <summary>
        /// Parametre olarak girilen validasyon metotlarını çalıştırır. 
        /// Sonuç false olursa hata objesini döndürür aksi halde null döndürür.
        /// </summary>
        /// <param name="logics">Validasyon Metotları</param>
        /// <returns></returns>
        public static IValidationResult Run(params IValidationResult[] logics)
        {
            foreach (IValidationResult logic in logics)
                if (logic.Succeeded == false)
                    return logic;
            return null;
        }
    }
}
