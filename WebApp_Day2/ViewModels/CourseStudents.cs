namespace WebApp_Day2.ViewModels
{
    public class CourseStudents
    {
        public int Crs_Id { get; set; }

        public string Crs_Name { get; set; }

       public List<Students> stds { get; set; }    = new List<Students>();
    }

    public class Students
    {
        public int Std_Id { get; set; }
        public string Std_Name { get; set; }

        public int Grade { get; set; }
    }
}
