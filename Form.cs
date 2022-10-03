using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBWarbandArmySelector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int armySize = random.Next(1, 201);

            int infantrySize = random.Next(1, 40);
            int archerSize = random.Next(1, 40);
            int horseManSize = random.Next(1, 40);

            int armyOutcome = infantrySize + archerSize + horseManSize;

            if(armyOutcome < 100)
            {
                int distance = (100 - armyOutcome) / 3;

                infantrySize += distance;
                archerSize += distance;
                horseManSize += distance;
            }
            else if(armyOutcome > 100)
            {
                int distance = (armyOutcome - 100) / 3;

                infantrySize -= distance;
                archerSize -= distance;
                horseManSize -= distance;
            }

            int enemyArmySize = random.Next(1, 201);
            int enemyinfantrySize = random.Next(1, 40);
            int enemyarcherSize = random.Next(1, 40);
            int enemyhorseManSize = random.Next(1, 40);

            int enemyarmyOutcome = enemyinfantrySize + enemyarcherSize + enemyhorseManSize;

            if (enemyarmyOutcome < 100)
            {
                int distance = (100 - enemyarmyOutcome) / 3;

                enemyinfantrySize += distance;
                enemyarcherSize += distance;
                enemyhorseManSize += distance;
            }
            else if (enemyarmyOutcome > 100)
            {
                int distance = (enemyarmyOutcome - 100) / 3;

                enemyinfantrySize -= distance;
                enemyarcherSize -= distance;
                enemyhorseManSize -= distance;
            }

            List<string> kingdoms = new List<string>
            {
                "Khergit",
                "Nords",
                "Rhodoks",
                "Swadia",
                "Vaegirs",
                "Sultanate"
            };

            List<string> characters = new List<string>
            {
                "Rodrigo",
                "Usiatra",
                "Hegen",
                "Konrad",
                "Sverre",
                "Borislav",
                "Stavras",
                "Gamara",
                "Aethrod",
                "Zaira",
                "Argo"
            };
            List<string> castleTypes = new List<string>
            {
                "Desert Castle",
                "Forest Castle",
            };
            List<string> landTypes = new List<string> 
            { 
                "Forest", 
                "Desert", 
                "Oasis" 
            };

            Dictionary<int, List<string>> warPlaces = new Dictionary<int, List<string>>();
            warPlaces.Add(0, landTypes);
            warPlaces.Add(1, castleTypes);
            warPlaces.Add(2, castleTypes);

            int kingdomTypeNum = random.Next(0, kingdoms.Count);
            int enemyKingdomTypeNum = random.Next(0, kingdoms.Count);
            int characterTypeNum = random.Next(0, characters.Count);
            int castleTypeNum = random.Next(0, castleTypes.Count);
            int landTypesNum = random.Next(0, landTypes.Count);
            int warPlaceNum = random.Next(0, warPlaces.Count);

            string place;
            string warType;

            if(warPlaceNum == 0)
            {
                warType = "Land";
                place = landTypes[landTypesNum];
            }
            else if(warPlaceNum == 1)
            {
                warType = "Castle Defence";
                place = castleTypes[castleTypeNum];
            }
            else
            {
                warType = "Castle Attack";
                place = castleTypes[castleTypeNum];
            }

            yourArmytxt.Text = $"Your Army\n\n" +
                $"Kingdom:{kingdoms[kingdomTypeNum]}\n\n" +
                $"Character:{characters[characterTypeNum]}\n\n" +
                $"Army Size:{armySize}\n\n" +
                $"Horse Man:{horseManSize}\n\n" +
                $"Infantry:{infantrySize}\n\n" +
                $"Archer:{archerSize}";

            enemyArmytxt.Text = $"Enemy Army\n\n" +
                $"Kingdom:{kingdoms[enemyKingdomTypeNum]}\n\n" +
                $"Army Size:{enemyArmySize}\n\n" +
                $"Horse Man:{enemyhorseManSize}\n\n" +
                $"Infantry:{enemyinfantrySize}\n\n" +
                $"Archer:{enemyarcherSize}";

            warTxt.Text = $"War Type:{warType}\n\n" +
                $"Place:{place}";
        }
    }
}
