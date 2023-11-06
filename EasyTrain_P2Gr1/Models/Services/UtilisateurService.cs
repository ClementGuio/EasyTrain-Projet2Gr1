using EasyTrain_P2Gr1.Models.Services.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class UtilisateurService : DisposableService,  IDalUtilisateur
    {
        public Utilisateur Authentifier(string adresseMail, string motDePasse)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            Utilisateur user = this._bddContext.Utilisateurs.FirstOrDefault(u => u.AdresseMail == adresseMail && u.MotDePasse == motDePasseEncode);
            return user;
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "Ag4@ug5@u13MfRRe" + motDePasse + "EasyTrainXPTDR";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public bool MailExists(string mail)
        {
            return _bddContext.Utilisateurs.Any(u => u.AdresseMail == mail);
        }
    }
}
