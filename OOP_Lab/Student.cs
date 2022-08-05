namespace student_enrolment
{
    internal class Student
    {
        public Student(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public Student(){}
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

}