using BOEF.Helpers;
using BOEF.Models;
using BOEF.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOEF.Test
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void SortWithType_correct()
        {
            //arrange
            CustomValidations customValidations = new CustomValidations();
            BoekingVM boekingVM = new BoekingVM();
            Beest beest1 = new Beest();
            beest1.Type = "Boerderij";
            beest1.Name = "";
            Beest beest2 = new Beest();
            beest2.Name = "Leeuw";
            beest2.Type = "";
            boekingVM.SelectedBeests.Add(beest1, "");
            boekingVM.SelectedBeests.Add(beest2, "");

            //act
            var result = customValidations.SortWithTypeValidate(boekingVM.SelectedBeests);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BookingPinguinInWeekend_Correct()
        {
            //arrange
            CustomValidations customValidations = new CustomValidations();
            BoekingVM boekingVM = new BoekingVM();
            Beest beest = new Beest();
            beest.Name = "Pinguïn";
            boekingVM.SelectedBeests.Add(beest, null);
            boekingVM.Date = new DateTime(2020, 1, 11);

            //act
            var result = customValidations.BookingPinguinInWeeknd(boekingVM.SelectedBeests, boekingVM.Date);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TypeBetweenOctAndFeb_Correct()
        {
            //arrange
            CustomValidations customValidations = new CustomValidations();
            BoekingVM boekingVM = new BoekingVM();
            Beest beest = new Beest();
            beest.Type = "Woestijn";
            beest.Name = "";
            boekingVM.SelectedBeests.Add(beest, "");
            boekingVM.Date = new DateTime(2021, 1, 11);

            //act
            var result = customValidations.TypeBetweenOctAndFeb(boekingVM.SelectedBeests, boekingVM.Date);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TypeBetweenJunAndAug_Correct()
        {
            //arrange
            CustomValidations customValidations = new CustomValidations();
            BoekingVM boekingVM = new BoekingVM();
            Beest beest = new Beest();
            beest.Type = "Sneeuw";
            beest.Name = "";
            boekingVM.SelectedBeests.Add(beest, "");
            boekingVM.Date = new DateTime(2020, 7, 15);

            //act
            var result = customValidations.TypeBetweenJuneAndAug(boekingVM.SelectedBeests, boekingVM.Date);
            //assert
            Assert.IsTrue(result);
        }
    }
}
