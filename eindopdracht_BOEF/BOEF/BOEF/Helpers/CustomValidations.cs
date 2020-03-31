using BOEF.Controllers;
using BOEF.Models;
using BOEF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOEF.Helpers
{
    public class CustomValidations : BoekingsController
    {

        public bool SortWithTypeValidate(Dictionary<Beest, string> beesten)
        {
            bool result = false;
            bool hasFarmType = false;
            bool isDangerous = false;
            foreach (var item in beesten)
            {
                if (!result)
                {
                    if (item.Key.Type.Equals("Boerderij"))
                    {
                        hasFarmType = true;
                    }

                    switch (item.Key.Name.ToLower())
                    {
                        case "leeuw":
                        case "ijsbeer":
                            isDangerous = true;
                            break;
                        default:
                            break;
                    }

                    if (hasFarmType && isDangerous)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }


        public bool BookingPinguinInWeeknd(Dictionary<Beest, string> beesten, DateTime date)
        {
            bool result = false;
            bool found = false;

            foreach (var item in beesten)
            {
                if (item.Key.Name.ToLower().Equals("pinguïn"))
                {
                    found = true;
                }

                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Saturday:
                        if (found)
                        {
                            result = true;
                        }
                        break;
                    default:
                        break;
                }
            }

            return result;
        }


        public bool TypeBetweenOctAndFeb(Dictionary<Beest, string> beesten, DateTime date)
        {
            bool result = false;
            bool found = false;
            bool isBetween = false;
            DateTime now = DateTime.Now;
            DateTime oct = new DateTime(now.Year, 10, 1);
            DateTime feb = new DateTime(now.Year + 1, 2, DateTime.DaysInMonth(now.Year + 1, 2));

            foreach (var item in beesten)
            {
                if (item.Key.Type.ToLower().Equals("woestijn"))
                {
                    found = true;
                }
            }

            if (date >= oct && date <= feb)
            {
                isBetween = true;
            }

            if (isBetween && found)
            {
                result = true;
            }

            return result;
        }


        public bool TypeBetweenJuneAndAug(Dictionary<Beest, string> beesten, DateTime date)
        {
            bool result = false;
            bool found = false;
            bool isBetween = false;
            DateTime now = DateTime.Now;
            DateTime june = new DateTime(now.Year, 6, 1);
            DateTime aug = new DateTime(now.Year, 8, DateTime.DaysInMonth(now.Year, 8));

            foreach (var item in beesten)
            {
                if (item.Key.Type.ToLower().Equals("sneeuw"))
                {
                    found = true;
                }
            }

            if (date >= june && date <= aug)
            {
                isBetween = true;
            }

            if (isBetween && found)
            {
                result = true;
            }

            return result;
        }

    }
}