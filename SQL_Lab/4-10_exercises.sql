/*
4.Write a SQL query that will return a list of all students ordered by surname. Write a second query ordering by first name.
*/
SELECT * FROM Students
ORDER BY LastName;

SELECT * FROM Students
ORDER BY FirstName;

/*
5.Write a SQL query that will return all students who are studying a course consisting of more than 3 subjects.
*/
SELECT s.FirstName, s.LastName, cm.CourseId FROM Students s
JOIN CourseMemberships cm ON s.Id = cm.StudentId
JOIN CourseSubjects cs ON cm.CourseId = cs.CourseId
GROUP BY s.FirstName
HAVING count(SubjectId) > 3
ORDER BY s.FirstName;

/*
6.Write a SQL query to add an additional Boolean column called IsPartFunded to the Courses table.
*/
ALTER TABLE Courses
ADD COLUMN IsPartFunded bool;

/*
9.Write a SQL query to update two courses to be partially funded.
*/
UPDATE Courses
SET IsPartFunded = true
WHERE Id = 1;

UPDATE Courses
SET IsPartFunded = true
WHERE Id = 3;

/*
10.Write a SQL query to return a list of students that are enrolled on a partially funded course, in alphabetical order.
*/
SELECT s.FirstName, s.LastName, cm.CourseId FROM Students s
JOIN CourseMemberships cm ON s.Id = cm.StudentId
JOIN Courses c ON cm.CourseId = c.Id
WHERE c.IsPartFunded = true
ORDER BY s.FirstName;