using System.Xml.Serialization;

namespace AlgorithmsLab4_WinForms
{
    public static class Serializer
    {
        public static void SerializeStudentsXML(Students students)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Students));

            using (FileStream fs = new FileStream("Students.xml", FileMode.Create))
            {
                xml.Serialize(fs, students);
            }
        }

        public static Students DeserializeStudentsXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Students));

            try
            {
                using (FileStream fs = new FileStream("Students.xml", FileMode.Open))
                {
                    Students students = xml.Deserialize(fs) as Students;

                    return students;
                }

            }
            catch (Exception)
            {
                return new Students();
            }

        }
    }
}
