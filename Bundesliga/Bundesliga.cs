namespace Bundesliga {
    public class Team {
        public int Position { get; set; }
        public string Name { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int Scored { get; set; }
        public int Conceded { get; set; }
        public int Points { get; set; }
    }

    public class HomeTeam : Team {
        public void setGoals(string fixtureDetails) {
            Scored = (fixtureDetails[0] == '-') ? 0 : (int)char.GetNumericValue(fixtureDetails[0]);
            Conceded = (fixtureDetails[2] == '-') ? 0 : (int)char.GetNumericValue(fixtureDetails[2]);
        }

        public void setOtherStats(string fixtureDetails, char? result) {
            Name = fixtureDetails.Substring(4, fixtureDetails.IndexOf(" - ") - 4);
            Played = (result == null) ? 0 : 1;

            switch (result) {
                case 'H':
                    Won = 1;
                    Lost = 0;
                    Drawn = 0;
                    Points = 3;
                    break;
                case 'A':
                    Won = 0;
                    Lost = 1;
                    Drawn = 0;
                    Points = 0;
                    break;
                case 'D':
                    Won = 0;
                    Lost = 0;
                    Drawn = 1;
                    Points = 1;
                    break;
                default:
                    Won = 0;
                    Lost = 0;
                    Drawn = 0;
                    Points = 0;
                    break;
            }
        }
    }

    public class AwayTeam : Team {
        public void setGoals(string fixtureDetails) {
            Scored = (fixtureDetails[2] == '-') ? 0 : (int)char.GetNumericValue(fixtureDetails[2]);
            Conceded = (fixtureDetails[0] == '-') ? 0 : (int)char.GetNumericValue(fixtureDetails[0]);
        }

        public void setOtherStats(string fixtureDetails, char? result) {
            Name = fixtureDetails.Substring(fixtureDetails.IndexOf(" - ") + 3, fixtureDetails.Length - (fixtureDetails.IndexOf(" - ") + 3));
            Played = (result == null) ? 0 : 1;

            switch (result) {
                case 'H':
                    Won = 0;
                    Lost = 1;
                    Drawn = 0;
                    Points = 0;
                    break;
                case 'A':
                    Won = 1;
                    Lost = 0;
                    Drawn = 0;
                    Points = 3;
                    break;
                case 'D':
                    Won = 0;
                    Lost = 0;
                    Drawn = 1;
                    Points = 1;
                    break;
                default:
                    Won = 0;
                    Lost = 0;
                    Drawn = 0;
                    Points = 0;
                    break;
            }
        }
    }
}
