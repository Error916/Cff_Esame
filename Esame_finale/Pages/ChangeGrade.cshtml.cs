using Esame_finale.Models;
using Esame_finale.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Esame_finale.Pages
{
    public class ChangeGradeModel : PageModel
    {
        [BindProperty]
        public float Evaluation { get; set; }
        public Grade Grade { get; set; }
        public Subject Subject { get; set; }
       
        private DbProvider _db;

        public ChangeGradeModel(DbProvider db)
        {
            _db = db;
        }

        public void OnGet(int gradeid)
        {
            Grade = _db.GetGradeById(gradeid);
            Subject = _db.GetSubjectById(Grade.Id_subject);
            Evaluation = Grade.Evaluation;
        }

        public IActionResult OnPost(int gradeid)
        {
            if (Evaluation > 0 && Evaluation <= 10.0)
            {
                Grade = _db.GetGradeById(gradeid);
                Grade.Evaluation = Evaluation;
                _db.EditGrade(Grade);
            }
            return RedirectToPage("Index");
        }
    }
}
