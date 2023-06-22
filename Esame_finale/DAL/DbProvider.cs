using Dapper;
using Esame_finale.Models;
using Microsoft.Data.SqlClient;

namespace Esame_finale.DAL
{
    public class DbProvider : IDisposable
    {
        private string connStr = "Data Source=DESKTOP-PMHSS20\\SQLEXPRESS;Database=test; User ID=Ettore;Password=password;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection connection;

        public DbProvider()
        {
            connection = new SqlConnection(connStr);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public Grade[] GetGrades()
        {
            string query = "SELECT * FROM grades ";
            return connection.Query<Grade>(query).ToArray();
        }

        public Subject[] GetSubjects()
        {
            string query = "SELECT * FROM subjects ";
            return connection.Query<Subject>(query).ToArray();
        }
        public Subject[] GetSubjectsNotGraded()
        {
            string query = "SELECT * FROM subjects WHERE graded = 0";
            return connection.Query<Subject>(query).ToArray();
        }

        public void DeleteGrade(int gradeid)
        {
            string query = "DELETE FROM grades WHERE id = @gradeid";
            if (connection.Execute(query, new { gradeid }) != 1)
            {
                throw new Exception("Error");
            }
        }

        public void AddGrade(Grade g) {
            string query = "INSERT INTO grades (id_subject, evaluation) VALUES (@Id_subject, @Evaluation)";
            if (connection.Execute(query, g) != 1)
            {
                throw new Exception("Error");
            }
        }

        public void EditGrade(Grade g)
        {
            string query = "UPDATE grades SET evaluation = @evaluation WHERE id = @id";
            if (connection.Execute(query, g) != 1)
            {
                throw new Exception("Error");
            }
        }
        public void EditSubject(Subject s)
        {
            string query = "UPDATE subjects SET graded = @graded WHERE id = @id";
            if (connection.Execute(query, s) != 1)
            {
                throw new Exception("Error");
            }
        }

        public Grade GetGradeById(int gradeid)
        {
            string query = "SELECT * FROM grades WHERE id = @gradeid";
            return connection.QuerySingle<Grade>(query, new { gradeid });
        }

        public Subject GetSubjectById(int subjectid)
        {
            string query = "SELECT * FROM subjects WHERE id = @subjectid";
            return connection.QuerySingle<Subject>(query, new { subjectid });
        }
    }
}

