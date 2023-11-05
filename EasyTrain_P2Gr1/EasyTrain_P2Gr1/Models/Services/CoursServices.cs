using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class CoursService : DisposableService, IDalCours
    {
        public List<Cours> GetCours()
        {
            return this._bddContext.Cours.Include(c => c.Coach).Include(c => c.Salle).Where(c => c.Supprime == false).ToList();
        }


        public Cours GetCours(int id)
        {
            return this._bddContext.Cours.Include(c => c.Coach).Include(c => c.Salle).FirstOrDefault(c => c.Supprime == false && c.Id == id);
        }

        public Cours GetCours(string strId)
        {
            int id;
            if (int.TryParse(strId, out id))
            {
                return GetCours(id);
            }
            return null;
        }

        public int CreateCours(Cours cours)
        {
            cours.Supprime = false;
            this._bddContext.Attach(cours.Salle);
            this._bddContext.Attach(cours.Coach);
            this._bddContext.Cours.Add(cours);
            this._bddContext.SaveChanges();
            return cours.Id;
        }

        public void UpdateCours(Cours cours)
        {
            _bddContext.Cours.Update(cours);
            _bddContext.SaveChanges();
        }

        public void DeleteCours(int id)
        {
            Cours nouveauCours = this._bddContext.Cours.Find(id);
            if (nouveauCours != null)
            {
                _bddContext.Cours.Remove(nouveauCours);
                _bddContext.SaveChanges();
            }
        }

        public List<Cours> GetCoursByCoach(int CoachId)
        {
           
            
                List<Cours> coursList = _bddContext.Cours
                    .Include(c => c.Coach)
                    .Include(c => c.Salle)
                    .Where(c => c.Supprime == false && c.CoachId == CoachId)
                    .ToList();

                return coursList;
           
        }

        /*public List<Cours> GetCoursByCoach(string strCoachId)
        {
            int coachId;
            if (int.TryParse(strCoachId, out coachId))
            {
                List<Cours> coursList = _bddContext.Cours
                    .Include(c => c.Coach)
                    .Include(c => c.Salle)
                    .Where(c => c.Supprime == false && c.CoachId == coachId)
                    .ToList();

                return coursList;
            }

            return null;
        }*/
    }
}
