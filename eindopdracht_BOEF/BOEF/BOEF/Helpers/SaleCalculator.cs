using BOEF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOEF.Helpers
{
    public class SaleCalculator
    {
        public void CalculatePrice(BoekingVM boekingVM)
        {
            decimal totalPrice = 0;
            decimal discountPrice = 0;
            decimal difference = 0;
            int totalDiscount = 0;
            int discountLimit = 60;

            //bereken totaal prijs
            foreach (var item in boekingVM.SelectedBeests)
            {
                totalPrice += item.Key.Prijs;
            }

            if (boekingVM.Accessoires.Count != 0)
            {
                foreach (var item in boekingVM.Accessoires.Keys)
                {
                    totalPrice += item.Price;
                }
            }

            boekingVM.TotalPrice = totalPrice;
            discountPrice = totalPrice;

            #region TypeChecker
            if (CalculateTypes(boekingVM))
            {
                if (!boekingVM.Discounts.ContainsKey("3 types"))
                {
                    boekingVM.Discounts.Add("3 types", 10);
                }
            }
            #endregion

            #region NameChecker
            if (NameCheckForSale(boekingVM))
            {
                var rd = new Random();
                var rdNum = rd.Next(0, 7);
                var specialNum = 3;
                if (!boekingVM.Discounts.ContainsKey("Eend (kans 1 op 6)"))
                {
                    if (specialNum == rdNum)
                    {
                        boekingVM.Discounts.Add("Eend (kans 1 op 6)", 50);
                    }
                    else
                    {
                        boekingVM.Discounts.Add("Eend (kans 1 op 6)", 0);
                    }
                }
            }
            #endregion

            #region DayChecker
            if (DayCheckForSale(boekingVM))
            {
                if (!boekingVM.Discounts.ContainsKey("ma / di"))
                {
                    boekingVM.Discounts.Add("ma / di", 15);
                }
            }
            #endregion

            #region LetterChecker
            if (LetterCheckForSale(boekingVM) != 0)
            {
                if (!boekingVM.Discounts.ContainsKey("Letter"))
                {
                    boekingVM.Discounts.Add("Letter", LetterCheckForSale(boekingVM));
                }
            }
            #endregion

            #region DiscountLimitChecker
            foreach (var item in boekingVM.Discounts)
            {
                if (totalDiscount + item.Value <= discountLimit)
                {
                    totalDiscount += item.Value;

                }
                else
                {
                    boekingVM.Discounts.Remove(item.Key);
                    boekingVM.Discounts.Add("kortingslimiet bereikt van ", 60);
                    break;
                }
            }
            #endregion

            //bereken alle kortingen
            if (boekingVM.Discounts.Count != 0)
            {
                foreach (var item in boekingVM.Discounts)
                {
                    if (item.Value != 0)
                    {
                        discountPrice -= (discountPrice / 100) * item.Value;
                    }
                }
            }
            difference = totalPrice - discountPrice;
            totalPrice = discountPrice;

            boekingVM.TotalPrice = totalPrice;
            boekingVM.TotalDiscount = difference;
        }

        #region DiscountValidators
        public bool CalculateTypes(BoekingVM boekingVM)
        {
            bool hasDiscount = false;
            Dictionary<string, int> types = new Dictionary<string, int>();
            types.Add("Jungle", 0);
            types.Add("Woestijn", 0);
            types.Add("Sneeuw", 0);
            types.Add("Boerderij", 0);

            foreach (var item in boekingVM.SelectedBeests.Keys)
            {
                foreach (var beest in types.Keys)
                {
                    if (item.Type.Equals(beest))
                    {
                        types[beest]++;
                        break;
                    }
                }
            }

            foreach (var item in types)
            {
                if (item.Value == 3)
                {
                    hasDiscount = true;
                    break;
                }
            }

            return hasDiscount;
        }

        public bool NameCheckForSale(BoekingVM boekingVM)
        {
            bool hasDiscount = false;
            string thisNameIsNeeded = "eend";

            foreach (var beest in boekingVM.SelectedBeests.Keys)
            {
                if (beest.Name.ToLower().Equals(thisNameIsNeeded))
                {
                    hasDiscount = true;
                }
            }

            return hasDiscount;
        }

        public bool DayCheckForSale(BoekingVM boeking)
        {
            bool hasDiscount = false;
            string date = boeking.Date.DayOfWeek.ToString();

            if (date.Equals("Monday") || date.Equals("Tuesday"))
            {
                hasDiscount = true;
            }

            return hasDiscount;
        }

        public int LetterCheckForSale(BoekingVM boeking)
        {
            int discountPerc = 0;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            foreach (var beest in boeking.SelectedBeests.Keys)
            {
                string sortedName = String.Concat(beest.Name.ToLower().OrderBy(c => c));
                string leftOverOfName = sortedName;
                string leftOverOfAplhabet = alphabet;
                bool processing = true;
                string foundLetters = "";
                int counter = 0;

                if (foundLetters.Length == 0)
                {
                    while (processing)
                    {
                        if (counter <= leftOverOfName.Length - 1)
                        {
                            if (leftOverOfName[counter].Equals(leftOverOfAplhabet[0]))
                            {
                                foundLetters += leftOverOfName[counter];
                                leftOverOfAplhabet = leftOverOfAplhabet.Substring(1);
                                counter++;
                            }
                            else
                            {
                                processing = false;
                            }
                        }
                        else
                        {
                            processing = false;
                        }
                    }
                }

                discountPerc += foundLetters.Length * 2;
            }

            return discountPerc;
        }

        #endregion
    }
}