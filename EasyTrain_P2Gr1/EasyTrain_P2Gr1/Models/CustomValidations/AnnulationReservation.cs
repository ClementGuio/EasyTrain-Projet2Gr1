using System;
using System.ComponentModel.DataAnnotations;


namespace EasyTrain_P2Gr1.Models.CustomValidations
{
    public class AnnulationReservation : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            DateTime firstDate = DateTime.Now;
            DateTime secondDate = DateTime.Now.AddDays(2);
            TimeSpan diffOfDate = firstDate - secondDate;

            if (diffOfDate.Hours > 48)
            {
                Console.WriteLine(" vous avez droit à un remboursement...");
            }
            
            return true;
        }
    }
}

