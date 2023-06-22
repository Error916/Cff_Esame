using Esame_finale.DAL;
using Esame_finale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Esame_finale.Pages
{
    public class DeleteGradeModel : PageModel
    {
        public Grade Grade { get; set; }
        public Subject Subject { get; set; }
        private DbProvider _db;

        public DeleteGradeModel(DbProvider db)
        {
            _db = db;
        }

        public IActionResult OnGet(int gradeid, bool confirm)
        {
            Grade = _db.GetGradeById(gradeid);
            Subject = _db.GetSubjectById(Grade.Id_subject);
            if (confirm)
            {
                _db.DeleteGrade(gradeid);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
