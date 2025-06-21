using System;
using System.Data.SQLite;

namespace Student_Management_System.Data
{
    internal static class Migration
    {
        public static void CreateTable()
        {
            using (var getDbconn = DatabaseManager.GetConnection())
            {
                getDbconn.Open();

                string[] createTableCommands = new string[]
                {
                    @"CREATE TABLE IF NOT EXISTS Students (
                        StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentName TEXT NOT NULL,
                        UserName TEXT NOT NULL,
                        PhoneNumber TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        Password TEXT NOT NULL
                    );",

                    @"CREATE TABLE IF NOT EXISTS Courses (
                        CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL
                    );",

                    @"CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        CourseID INTEGER,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                    );",

                    @"CREATE TABLE IF NOT EXISTS Admins (
                        AdminID INTEGER PRIMARY KEY AUTOINCREMENT,
                        AdminName TEXT NOT NULL,
                        PhoneNumber TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        UserName TEXT NOT NULL,
                        Password TEXT NOT NULL
                    );",

                    @"CREATE TABLE IF NOT EXISTS Staffs (
                        StaffID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StaffName TEXT NOT NULL,
                        PhoneNumber TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        UserName TEXT NOT NULL,
                        Password TEXT NOT NULL
                    );",

                    @"CREATE TABLE IF NOT EXISTS Lecturers (
                        LecturersID INTEGER PRIMARY KEY AUTOINCREMENT,
                        LecturersName TEXT NOT NULL,
                        PhoneNumber TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        UserName TEXT NOT NULL,
                        Password TEXT NOT NULL
                    );",

                    @"CREATE TABLE IF NOT EXISTS Exams (
                        ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        SubjectID INTEGER,
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                    );",

                    @"CREATE TABLE IF NOT EXISTS Marks (
                        CourseID INTEGER,
                        SubjectID INTEGER,
                        StudentID INTEGER,
                        StudentName TEXT,
                        Mark INTEGER NOT NULL,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
                    );"
                };

                foreach (var cmdText in createTableCommands)
                {
                    using (var cmd = new SQLiteCommand(cmdText, getDbconn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
