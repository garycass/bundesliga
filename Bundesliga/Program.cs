using System;

namespace Bundesliga {

    public class Bundesliga {

        // Uncomment this and set project as Console App for debugging

        //public static void Main() {

        //    var results = new[] {
        //        "6:0 FC Bayern Muenchen - Werder Bremen",
        //        "-:- Eintracht Frankfurt - Schalke 04",
        //        "-:- FC Augsburg - VfL Wolfsburg",
        //        "-:- Hamburger SV - FC Ingolstadt",
        //        "-:- 1. FC Koeln - SV Darmstadt",
        //        "-:- Borussia Dortmund - FSV Mainz 05",
        //        "-:- Borussia Moenchengladbach - Bayer Leverkusen",
        //        "-:- Hertha BSC Berlin - SC Freiburg",
        //        "-:- TSG 1899 Hoffenheim - RasenBall Leipzig"
        //    };

            

        //    var actualTable = Bundesliga.Table(results);
        //}

        public static string Table(string[] results) {
            Team[] table = new Team[results.Length * 2];
            string fixture = "";
            int tableIndex = 0;

            for (int i = 0; i < results.Length; i++) {
                fixture = results[i];
                tableIndex = i * 2;

                HomeTeam homeTeam = new HomeTeam();
                AwayTeam awayTeam = new AwayTeam();

                homeTeam.setGoals(fixture);
                awayTeam.setGoals(fixture);

                char? result = null;

                if (homeTeam.Scored > awayTeam.Scored)
                    result = 'H';
                else if (homeTeam.Scored < awayTeam.Scored)
                    result = 'A';
                else if (homeTeam.Scored == awayTeam.Scored && fixture[0] != '-')
                    result = 'D';

                homeTeam.setOtherStats(fixture, result);
                awayTeam.setOtherStats(fixture, result);

                table[tableIndex] = homeTeam;
                table[tableIndex + 1] = awayTeam;
            }

            table = sortTable(table);
            setPositions(table);
            string formattedTable = formatTable(table);

            // Uncomment for debugging

            //Console.WriteLine(formattedTable);
            //Console.ReadKey();

            return formattedTable;
        }

        static string formatTable(Team[] table) {

            string result = "";

            for (int i = 0; i < table.Length; i++) {
                result += String.Format("{0,2}", table[i].Position) + ". ";
                result += String.Format("{0,-30}", table[i].Name);
                result += String.Format("{0,-3}", table[i].Played);
                result += String.Format("{0,-3}", table[i].Won);
                result += String.Format("{0,-3}", table[i].Drawn);
                result += String.Format("{0,-3}", table[i].Lost);
                result += String.Format("{0,-5}", table[i].Scored + ":" + table[i].Conceded);
                result += table[i].Points;
                if (i < table.Length - 1) result += "\n";
            }

            return result;
        }

        static Team[] sortTable(Team[] table) {

            Team temp;

            for (int write = 0; write < table.Length; write++) {
                for (int sort = 0; sort < table.Length - 1; sort++) {
                    if (swapRequired(table[sort], table[sort + 1])) {
                        temp = table[sort + 1];
                        table[sort + 1] = table[sort];
                        table[sort] = temp;
                    }
                }
            }

            return table;
        }

        private static bool swapRequired(Team team1, Team team2) {
            bool swap = false;
            bool pointsEqual = team1.Points == team2.Points;
            bool diffEqual = (team1.Scored - team1.Conceded) == (team2.Scored - team2.Conceded);
            bool goalsEqual = team1.Scored == team2.Scored;

            if (team1.Points < team2.Points
            || (pointsEqual && ((team1.Scored - team1.Conceded) < (team2.Scored - team2.Conceded)))
            || (pointsEqual && diffEqual && (team1.Scored < team2.Scored))
            || (pointsEqual && diffEqual && goalsEqual && (string.Compare(team2.Name, team1.Name) < 0))) {

                swap = true;
            }

            return swap;
        }

        private static void setPositions(Team[] table) {

            Team team1;
            Team team2;
            bool pointsEqual;
            bool diffEqual;
            bool goalsEqual;

            table[0].Position = 1;

            for (int i = 0; i < table.Length - 1; i++) {
                bool changePos = false;
                team1 = table[i];
                team2 = table[i + 1];
                pointsEqual = team1.Points == team2.Points;
                diffEqual = (team1.Scored - team1.Conceded) == (team2.Scored - team2.Conceded);
                goalsEqual = team1.Scored == team2.Scored;

                if (!(pointsEqual && diffEqual && goalsEqual)) {
                    changePos = true;
                }

                if (!changePos)
                    table[i + 1].Position = table[i].Position;
                else
                    table[i + 1].Position = i + 2;
            }
        }

        static void printArray(Team[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                Console.Write(arr[i].Position + " ");
                Console.Write(arr[i].Name + " ");
                Console.Write(arr[i].Scored + " ");
                Console.Write(arr[i].Conceded + " ");
                Console.Write(arr[i].Won + " ");
                Console.Write(arr[i].Lost + " ");
                Console.Write(arr[i].Drawn + " ");
                Console.WriteLine(arr[i].Points);
            }
        }
    }
}
