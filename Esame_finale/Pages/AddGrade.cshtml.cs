using Esame_finale.DAL;
using Esame_finale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Esame_finale.Pages
{
    public class AddGradeModel : PageModel
    {
        [BindProperty]
        public Grade Grade { get; set; }
        public Subject[] Subjects { get; set; }
        private DbProvider _db;

        public AddGradeModel(DbProvider db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Grade = new Grade();

            Subjects = _db.GetSubjectsNotGraded();
        }

        public IActionResult OnPost()
        {
            if (Grade.Evaluation > 0 && Grade.Evaluation <= 10.0)
            {
                Subject s = _db.GetSubjectById(Grade.Id_subject);
                s.Graded = true;
                _db.EditSubject(s);
                _db.AddGrade(Grade);
            }
            return RedirectToPage("Index");
        }
    }
}
