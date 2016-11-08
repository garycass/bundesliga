using NUnit.Framework;

namespace Bundesliga {

    [TestFixture]
    public class BundesligaTests {
        [Test]
        public void FridayEveningTest() {
            var results = new[] {
                "6:0 FC Bayern Muenchen - Werder Bremen",
                "-:- Eintracht Frankfurt - Schalke 04",
                "-:- FC Augsburg - VfL Wolfsburg",
                "-:- Hamburger SV - FC Ingolstadt",
                "-:- 1. FC Koeln - SV Darmstadt",
                "-:- Borussia Dortmund - FSV Mainz 05",
                "-:- Borussia Moenchengladbach - Bayer Leverkusen",
                "-:- Hertha BSC Berlin - SC Freiburg",
                "-:- TSG 1899 Hoffenheim - RasenBall Leipzig"
            };

            var expectedTable =
            " 1. FC Bayern Muenchen            1  1  0  0  6:0  3\n" +
            " 2. 1. FC Koeln                   0  0  0  0  0:0  0\n" +
            " 2. Bayer Leverkusen              0  0  0  0  0:0  0\n" +
            " 2. Borussia Dortmund             0  0  0  0  0:0  0\n" +
            " 2. Borussia Moenchengladbach     0  0  0  0  0:0  0\n" +
            " 2. Eintracht Frankfurt           0  0  0  0  0:0  0\n" +
            " 2. FC Augsburg                   0  0  0  0  0:0  0\n" +
            " 2. FC Ingolstadt                 0  0  0  0  0:0  0\n" +
            " 2. FSV Mainz 05                  0  0  0  0  0:0  0\n" +
            " 2. Hamburger SV                  0  0  0  0  0:0  0\n" +
            " 2. Hertha BSC Berlin             0  0  0  0  0:0  0\n" +
            " 2. RasenBall Leipzig             0  0  0  0  0:0  0\n" +
            " 2. SC Freiburg                   0  0  0  0  0:0  0\n" +
            " 2. Schalke 04                    0  0  0  0  0:0  0\n" +
            " 2. SV Darmstadt                  0  0  0  0  0:0  0\n" +
            " 2. TSG 1899 Hoffenheim           0  0  0  0  0:0  0\n" +
            " 2. VfL Wolfsburg                 0  0  0  0  0:0  0\n" +
            "18. Werder Bremen                 1  0  0  1  0:6  0";

            var actualTable = Bundesliga.Table(results);
            Assert.AreEqual(expectedTable, actualTable, "Expected:\n" + expectedTable + "\n\nActual:\n" + actualTable);
        }

        [Test]
        public void SaturdayEveningTest() {
            var results = new[]
            {
                "6:0 FC Bayern Muenchen - Werder Bremen",
                "1:0 Eintracht Frankfurt - Schalke 04",
                "0:2 FC Augsburg - VfL Wolfsburg",
                "1:1 Hamburger SV - FC Ingolstadt",
                "2:0 1. FC Koeln - SV Darmstadt",
                "2:1 Borussia Dortmund - FSV Mainz 05",
                "2:1 Borussia Moenchengladbach - Bayer Leverkusen",
                "-:- Hertha BSC Berlin - SC Freiburg",
                "-:- TSG 1899 Hoffenheim - RasenBall Leipzig"
            };

            var expectedTable =
            " 1. FC Bayern Muenchen            1  1  0  0  6:0  3\n" +
            " 2. 1. FC Koeln                   1  1  0  0  2:0  3\n" +
            " 2. VfL Wolfsburg                 1  1  0  0  2:0  3\n" +
            " 4. Borussia Dortmund             1  1  0  0  2:1  3\n" +
            " 4. Borussia Moenchengladbach     1  1  0  0  2:1  3\n" +
            " 6. Eintracht Frankfurt           1  1  0  0  1:0  3\n" +
            " 7. FC Ingolstadt                 1  0  1  0  1:1  1\n" +
            " 7. Hamburger SV                  1  0  1  0  1:1  1\n" +
            " 9. Hertha BSC Berlin             0  0  0  0  0:0  0\n" +
            " 9. RasenBall Leipzig             0  0  0  0  0:0  0\n" +
            " 9. SC Freiburg                   0  0  0  0  0:0  0\n" +
            " 9. TSG 1899 Hoffenheim           0  0  0  0  0:0  0\n" +
            "13. Bayer Leverkusen              1  0  0  1  1:2  0\n" +
            "13. FSV Mainz 05                  1  0  0  1  1:2  0\n" +
            "15. Schalke 04                    1  0  0  1  0:1  0\n" +
            "16. FC Augsburg                   1  0  0  1  0:2  0\n" +
            "16. SV Darmstadt                  1  0  0  1  0:2  0\n" +
            "18. Werder Bremen                 1  0  0  1  0:6  0";

            var actualTable = Bundesliga.Table(results);
            Assert.AreEqual(expectedTable, actualTable, "Expected:\n" + expectedTable + "\n\nActual:\n" + actualTable);
        }

        [Test]
        public void SundayEveningTest() {
            var results = new[]
            {
                "6:0 FC Bayern Muenchen - Werder Bremen",
                "1:0 Eintracht Frankfurt - Schalke 04",
                "0:2 FC Augsburg - VfL Wolfsburg",
                "1:1 Hamburger SV - FC Ingolstadt",
                "2:0 1. FC Koeln - SV Darmstadt",
                "2:1 Borussia Dortmund - FSV Mainz 05",
                "2:1 Borussia Moenchengladbach - Bayer Leverkusen",
                "2:1 Hertha BSC Berlin - SC Freiburg",
                "2:2 TSG 1899 Hoffenheim - RasenBall Leipzig"
            };

            var expectedTable =
            " 1. FC Bayern Muenchen            1  1  0  0  6:0  3\n" +
            " 2. 1. FC Koeln                   1  1  0  0  2:0  3\n" +
            " 2. VfL Wolfsburg                 1  1  0  0  2:0  3\n" +
            " 4. Borussia Dortmund             1  1  0  0  2:1  3\n" +
            " 4. Borussia Moenchengladbach     1  1  0  0  2:1  3\n" +
            " 4. Hertha BSC Berlin             1  1  0  0  2:1  3\n" +
            " 7. Eintracht Frankfurt           1  1  0  0  1:0  3\n" +
            " 8. RasenBall Leipzig             1  0  1  0  2:2  1\n" +
            " 8. TSG 1899 Hoffenheim           1  0  1  0  2:2  1\n" +
            "10. FC Ingolstadt                 1  0  1  0  1:1  1\n" +
            "10. Hamburger SV                  1  0  1  0  1:1  1\n" +
            "12. Bayer Leverkusen              1  0  0  1  1:2  0\n" +
            "12. FSV Mainz 05                  1  0  0  1  1:2  0\n" +
            "12. SC Freiburg                   1  0  0  1  1:2  0\n" +
            "15. Schalke 04                    1  0  0  1  0:1  0\n" +
            "16. FC Augsburg                   1  0  0  1  0:2  0\n" +
            "16. SV Darmstadt                  1  0  0  1  0:2  0\n" +
            "18. Werder Bremen                 1  0  0  1  0:6  0";

            var actualTable = Bundesliga.Table(results);
            Assert.AreEqual(expectedTable, actualTable, "Expected:\n" + expectedTable + "\n\nActual:\n" + actualTable);
        }
    }
}
