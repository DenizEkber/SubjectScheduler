using SubjectScheduler.Context;
using SubjectScheduler.TestDataGenerator;
using SubjectScheduler.SubjectAlgorithm;

namespace SubjectScheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (UniversityContext context = new UniversityContext())
            {
                
                // Veritabanını oluştur ve örnek verilerle doldur
                DataGenerator.Initialize(context);

                // Scheduler sınıfını başlat ve programı oluştur
                var scheduler = new Scheduler(context);
                scheduler.GenerateWeeklySchedule();

                Console.WriteLine("Haftalık program başarıyla oluşturuldu.");
                
            }
        }
    }
}
