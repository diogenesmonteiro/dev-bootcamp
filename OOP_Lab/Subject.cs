namespace student_enrolment
{
    internal class Subject
    {
        public Subject(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Subject(){}
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}