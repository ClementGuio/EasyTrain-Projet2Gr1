using System;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalUtilisateur : IDisposable
    {
        Utilisateur Authentifier(string adresseMail, string motDePasse);

        bool MailExists(string mail);
    }
}
