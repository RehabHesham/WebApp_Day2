namespace WebApp_Day2.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        // Navigation Property
        public List<Student> Students { get; set; }
    }
}
