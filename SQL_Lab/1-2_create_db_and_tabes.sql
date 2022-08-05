/*
1.Create a database called StudentEnrolment using a SQL query.
2.Create the following database tables, applying primary and foreign keys to each of the tables as necessary:
	1.Table name: Students (Columns: Identifier, First Name, Last Name)
	2.Table name: Courses (Columns: Identifier, Name, Description)
	3.Table name: Subjects (Columns: Identifier, Name, Description)
	4.Table name: CourseSubjects
	5.Table name: CourseMemberships
*/
CREATE DATABASE StudentEnrolment;

USE StudentEnrolment;

CREATE TABLE Students (
	Id INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(45) NOT NULL,
    LastName VARCHAR(45) NOT NULL
);

CREATE TABLE Courses (
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(45) NOT NULL,
    Description VARCHAR(1000) NOT NULL
);

CREATE TABLE Subjects (
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(45) NOT NULL,
    Description VARCHAR(1000) NOT NULL
);

CREATE TABLE CourseSubjects (
	Id INT PRIMARY KEY AUTO_INCREMENT,
    CourseId INT NOT NULL,
    SubjectId INT NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES Courses(Id),
    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
);

CREATE TABLE CourseMemberships (
	Id INT PRIMARY KEY AUTO_INCREMENT,
	StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);