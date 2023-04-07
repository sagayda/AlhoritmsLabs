namespace AlgorithmsLab4_WinForms
{
    [Serializable]
    public class Students
    {
        public List<Student> students { get; set; } = new List<Student>();

        public Students()
        {

        }
    }

    [Serializable]
    public class Student
    {
        public string FullName { get; set; }
        public int Sex { get; set; }
        public string Group { get; set; }
        public string Description { get => FullName + ", " + Group; }

        public Student() { }

        public Student(string fullName, int sex, string group) 
        {
            FullName= fullName;
            Sex=sex;
            Group= group;
        }
    }
}
