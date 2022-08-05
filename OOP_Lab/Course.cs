namespace student_enrolment
{
    internal class Course
    {
        public Course(string id, string name, string description, string isPartFunded)
        {
            Id = id;
            Name = name;
            Description = description;
            IsPartFunded = isPartFunded;
        }
        public Course(){}
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsPartFunded { get; set; }
    }
}