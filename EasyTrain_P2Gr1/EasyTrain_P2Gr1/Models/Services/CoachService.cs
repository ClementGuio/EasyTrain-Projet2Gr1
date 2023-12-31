﻿using System.Collections.Generic;
using System;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class CoachService : DisposableService, IDalCoach
    {
        public List<Coach> GetCoachs()
        {
            return this._bddContext.Coachs.ToList();
        }
        public Coach GetCoach(int id)
        {
            return this._bddContext.Coachs.Find(id);
        }

        public Coach GetCoach(string strId)
        {
            int id;
            if (int.TryParse(strId, out id))
            {
                return GetCoach(id);
            }
            return null;
        }

        public int CreateCoach(Coach coach)
        {
            coach.MotDePasse = UtilisateurService.EncodeMD5(coach.MotDePasse);
            this._bddContext.Coachs.Add(coach);
            this._bddContext.SaveChanges();
            return coach.Id;
        }


        public void UpdateCoach(Coach coach)
        {
            coach.MotDePasse = UtilisateurService.EncodeMD5(coach.MotDePasse);
            this._bddContext.Coachs.Update(coach);
            this._bddContext.SaveChanges();
        }

        public void DeleteCoach(int id) // TODO : supprimer ses CoursProgramme 
        {
            Coach nouveauCoach = this._bddContext.Coachs.Find(id);
            if (nouveauCoach != null)
            {
                _bddContext.Coachs.Remove(nouveauCoach);
                _bddContext.SaveChanges();
            }
        }
    }
}
