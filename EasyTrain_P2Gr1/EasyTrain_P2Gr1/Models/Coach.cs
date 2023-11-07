using System;

namespace EasyTrain_P2Gr1.Models
{
    public class Coach : Utilisateur
    {
        //public DateTime DateCreationCompte { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; internal set; }
        public string Specialité { get; internal set; }
    }
}
