namespace student_enrolment
{
    internal class CourseSubject
    {
        public CourseSubject(string id, string courseId, string subjectId)
        {
            Id = id;
            CourseId = courseId;
            SubjectId = subjectId;
        }
        public CourseSubject(){}
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string SubjectId { get; set; }
    }
}