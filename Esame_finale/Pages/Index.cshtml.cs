using Esame_finale.Models;
using Esame_finale.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Esame_finale.Pages
{
    public class IndexModel : PageModel
    {
        public Grade[] Grades { get; set; }
        public Subject[] Subjects { get; set; }
        public float Media { get; set; } 
        private DbProvider _db;

        public IndexModel(DbProvider db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Grades = _db.GetGrades();
            Subjects = _db.GetSubjects();
            Media = Grades.Sum(x => x.Evaluation) / Grades.Length;
        }
    }
}