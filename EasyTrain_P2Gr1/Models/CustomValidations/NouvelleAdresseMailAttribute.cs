using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTrain_P2Gr1.Models.CustomValidations
{
    public class NouvelleAdresseMailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string mail = Convert.ToString(value);
            using (IDalUtilisateur service = new UtilisateurService())
            {
                return !service.MailExists(mail);
            }
        }
    }
}
