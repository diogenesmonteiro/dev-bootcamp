namespace student_enrolment
{
    internal class CourseMembership
    {
        public CourseMembership(string id, string studentId, string courseId)
        {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;
        }
        public CourseMembership(){}
        public string Id { get; set; }
        public string StudentId { get; set; }
        public string CourseId { get; set; }
    }
}
