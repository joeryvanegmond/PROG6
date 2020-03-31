using System;
using BOEF.Controllers;
using BOEF.Helpers;
using BOEF.Models;
using BOEF.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BOEF.Test
{
    [TestClass]
    public class KortingTest
    {
        [TestMethod]
        public void CalculatePrice_Correct()
        {

            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();

            var beest1 = new Beest();
            beest1.Type = "Jungle";
            beest1.Name = "";
            var beest2 = new Beest();
            beest2.Type = "Jungle";
            beest2.Name = "";
            var beest3 = new Beest();
            beest3.Type = "Jungle";
            beest3.Name = "";
            boekingVM.SelectedBeests.Add(beest1, null);
            boekingVM.SelectedBeests.Add(beest2, null);
            boekingVM.SelectedBeests.Add(beest3, null);

            var beest = new Beest();
            beest.Name = "eend";
            beest.Type = "Woestijn";
            boekingVM.SelectedBeests.Add(beest, null);

            var boeking = new Boeking();
            boeking.Date = new DateTime(2020, 1, 13);
            boekingVM.Boeking = boeking;

            try
            {
                salecalculator.CalculatePrice(boekingVM);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }



        }

        [TestMethod]
        public void CalculateType_Jungle_Correct()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var beest1 = new Beest();
            beest1.Type = "Jungle";
            var beest2 = new Beest();
            beest2.Type = "Jungle";
            var beest3 = new Beest();
            beest3.Type = "Jungle";
            boekingVM.SelectedBeests.Add(beest1, null);
            boekingVM.SelectedBeests.Add(beest2, null);
            boekingVM.SelectedBeests.Add(beest3, null);

            //act
            var result = salecalculator.CalculateTypes(boekingVM);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateType_Sneeuw_Correct()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var beest1 = new Beest();
            beest1.Type = "Sneeuw";
            var beest2 = new Beest();
            beest2.Type = "Sneeuw";
            var beest3 = new Beest();
            beest3.Type = "Sneeuw";
            boekingVM.SelectedBeests.Add(beest1, null);
            boekingVM.SelectedBeests.Add(beest2, null);
            boekingVM.SelectedBeests.Add(beest3, null);

            //act
            var result = salecalculator.CalculateTypes(boekingVM);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateType_Woestijn_Correct()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var beest1 = new Beest();
            beest1.Type = "Woestijn";
            var beest2 = new Beest();
            beest2.Type = "Woestijn";
            var beest3 = new Beest();
            beest3.Type = "Woestijn";
            boekingVM.SelectedBeests.Add(beest1, null);
            boekingVM.SelectedBeests.Add(beest2, null);
            boekingVM.SelectedBeests.Add(beest3, null);

            //act
            var result = salecalculator.CalculateTypes(boekingVM);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateType_Boerderij_Correct()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var beest1 = new Beest();
            beest1.Type = "Boerderij";
            var beest2 = new Beest();
            beest2.Type = "Boerderij";
            var beest3 = new Beest();
            beest3.Type = "Boerderij";
            boekingVM.SelectedBeests.Add(beest1, null);
            boekingVM.SelectedBeests.Add(beest2, null);
            boekingVM.SelectedBeests.Add(beest3, null);

            //act
            var result = salecalculator.CalculateTypes(boekingVM);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateType_False()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var beest1 = new Beest();
            beest1.Type = "Boerderij";
            var beest2 = new Beest();
            beest2.Type = "Boerderij";
            var beest3 = new Beest();
            beest3.Type = "Jungle";
            boekingVM.SelectedBeests.Add(beest1, null);
            boekingVM.SelectedBeests.Add(beest2, null);
            boekingVM.SelectedBeests.Add(beest3, null);

            //act
            var result = salecalculator.CalculateTypes(boekingVM);
            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NameCheckForSale_Correct()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var beest = new Beest();
            //var beest = new Mock<Beest>();
            beest.Name = "eend";
            boekingVM.SelectedBeests.Add(beest, null);

            //act
            var result = salecalculator.NameCheckForSale(boekingVM);

            //assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void NameCheckForSale_False()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var beest = new Beest();
            beest.Name = "nieteend";
            boekingVM.SelectedBeests.Add(beest, null);

            //act
            var result = salecalculator.NameCheckForSale(boekingVM);

            //assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void DayCheckForSale_Correct()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var boeking = new Boeking();
            boeking.Date = new DateTime(2020, 1, 13);
            boekingVM.Boeking = boeking;

            //act
            var result = salecalculator.DayCheckForSale(boekingVM);

            //assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void LetterCheckForSale_Correct()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var beest = new Beest();
            beest.Name = "alblc";
            boekingVM.SelectedBeests.Add(beest, null);

            //act
            var result = salecalculator.LetterCheckForSale(boekingVM);

            //assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void LetterCheckForSale_False()
        {
            //arrange
            var salecalculator = new SaleCalculator();
            var boekingVM = new BoekingVM();
            var beest = new Beest();
            beest.Name = "xyz";
            boekingVM.SelectedBeests.Add(beest, null);

            //act
            var result = salecalculator.LetterCheckForSale(boekingVM);

            //assert
            Assert.AreEqual(0, result);
        }
    }
}
