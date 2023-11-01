using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTrain_P2Gr1.Models.CustomValidations
{
    public class DateNaissanceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime now = DateTime.Now;
            DateTime date = Convert.ToDateTime(value);
            if (date > now)
            {
                return false;
            }
            int age = now.Year - date.Year;
            if (date > now.AddYears(-age))
            {
                age--;
            }
            return age >= 18;
        }
    }
}
