using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Wizard.Test
{
    [TestClass]
    public class Wizard_Test
    {
        /// <summary>
        /// Fora-mis-Forameur
        //  [spinneweb, oorlel, slangegif]
        //  “Deze toverspreuk opent alle deuren die op mechanische wijze gesloten zijn.”
        //  Resultaat: ‘doe open die poort’
        /// </summary>

        [TestMethod]
        public void foramisforameur_goed()
        {
            //1. arrange
            var woorden = new String[] { "Fora", "mis", "Forameur" };
            var ingredienten = new String[] { "spinneweb", "oorlel", "slangegif" };
            var tovenaar = new Tovenaar(null);

            //2. act
            var resultaat = tovenaar.Toverspreuk(ingredienten.ToList(), woorden.ToList());

            //3. assert
            Assert.AreEqual("doe open die poort", resultaat);

        }

        /// <summary>
        /// Flim-Flam-Fluister
        //  [Kikkerbil, oorlel, rattenstaart, krokodillenoog]
        //  “Toverij voor het creëren van een magische lichtbron.”.
        //  Bewegingen: links, rechts
        //  Resultaat: ‘Er was licht, en hij zag dat het goed was!
        /// </summary>

        [TestMethod]
        public void flimflamfluister_goed()
        {
            //1. arrange
            var woorden = new String[] { "Flim", "Flam", "Fluister" };
            var ingredienten = new String[] { "Kikkerbil", "oorlel", "rattenstaart", "krokodillenoog" };
            var toverstaf = new Mock<IToverstaf>();
            var tovenaar = new Tovenaar(toverstaf.Object);

            //2. act
            var resultaat = tovenaar.Toverspreuk(ingredienten.ToList(), woorden.ToList());

            //3. assert
            Assert.AreEqual("Er was licht, en hij zag dat het goed was!", resultaat);
            toverstaf.Verify(t => t.Links(), Times.Once);
            toverstaf.Verify(t => t.Rechts(), Times.Once);
        }

        /// <summary>
        /// Ban-da-ladik
        //  [Kikkerbil, oorlel, rattenstaart, slangegif]
        //  “De tovenaar betovert iemand zodat deze denkt dat hij zijn beste vriend voor zich heeft.”
        //  Bewegingen: omhoog, omlaag
        //  Resultaat: ‘best friends for life’
        /// </summary>

        [TestMethod]
        public void bandaladik_goed()
        {
            //1. arrange
            var woorden = new String[] { "Ban", "da", "ladik" };
            var ingredienten = new String[] { "Kikkerbil", "oorlel", "rattenstaart", "slangegif" };
            var toverstaf = new Mock<IToverstaf>();
            var tovenaar = new Tovenaar(toverstaf.Object);

            //2. act
            var resultaat = tovenaar.Toverspreuk(ingredienten.ToList(), woorden.ToList());

            //3. assert
            Assert.AreEqual("best friends for life", resultaat);
            toverstaf.Verify(t => t.Omhoog(), Times.Once);
            toverstaf.Verify(t => t.Omlaag(), Times.Once);
        }

        /// <summary>
        /// Arma-kro-dilt
        //  [Kikkerbil, spinneweb, oorlel, rattenstaart, slangegif, mensenhaar, krokodillenoog]
        //  “Hiermee verschaft men zich een onzichtbare uitrusting.”
        //  Extra: Gebruik een zilveren kookpot, andere kookpotten kunnen ontploffen!
        //  Resultaat: ‘upgrades’
        /// </summary>
        /// NIET TE TESTEN OMDAT ER EEN KOOKPOT NODIG IS DIE ZILVR 
        /// MOET ZIJN EN DAAR KAN NIET OP GECONTROLLEERD WORDEN 
        /// OMDAT ER IN DE CONSTRUCTOR EEN ZWARTE KOOKPOT WORDT AANGEMAAKT.

        [TestMethod]
        public void armakrodilt_goed()
        {
            //1. arrange
            var woorden = new String[] { "Arma", "kro", "dilt" };
            var ingredienten = new String[] { "Kikkerbil", "spinneweb", "oorlel", "rattenstaart", "slangegif", "mensenhaar", "krokodillenoog" };
            var tovenaar = new Tovenaar(null);

            //2. act
            var resultaat = tovenaar.Toverspreuk(ingredienten.ToList(), woorden.ToList());

            //3. assert
            Assert.AreEqual("best friends for life", resultaat);
        }



        /// <summary>
        /// Bal-sam-sala-bond
        //  [Kikkerbil, spinneweb, mensenhaar, krokodillenoog]
        //  “Genezingstoverij die de verloren levensenergie terugbrengt.”
        //  Bewegingen: Links, omhoog, rechts, omlaag (volgorde is belangrijk!)
        //  Resultaat: ‘Je bent genezen met 3 energiepunten’
        //  ** Aantal energie is gelijk aan de energie in je toverstaf **
        /// </summary>

        [TestMethod]
        public void balsamsalabond_goed()
        {
            //1. arrange
            var woorden = new String[] { "Bal", "sam", "sala", "bond" };
            var ingredienten = new String[] { "Kikkerbil", "spinneweb", "mensenhaar", "krokodillenoog" };
            var toverstaf = new Mock<IToverstaf>();
            var tovenaar = new Tovenaar(toverstaf.Object);
            toverstaf.Setup(t => t.HoeveelheidEnergie).Returns(3);
            //2. act
            var resultaat = tovenaar.Toverspreuk(ingredienten.ToList(), woorden.ToList());

            //3. assert
            Assert.AreEqual("Je bent genezen met 3 energiepunten", resultaat);

        }

    }
}
