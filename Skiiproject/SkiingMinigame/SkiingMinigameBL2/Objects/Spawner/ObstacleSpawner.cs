using SkiingMinigameBL.Objects.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigameBL.Objects.Spawner
{
    public class ObstacleSpawner
    {
        // stole the idea of spawners from bradley but i think i can make it have an original twist
        private Random _random;

        public ObstacleSpawner(double minimumSpawnTime, double maxmimumSpawnTime)
        {
            MinimumSpawnTime = minimumSpawnTime;
            MaxmimumSpawnTime = maxmimumSpawnTime;
            _random = new Random();
        }


        private double _minimumSpawnTime;
        public double MinimumSpawnTime
        {
            get 
            {
                return _minimumSpawnTime;

            }
            set 
            {
                value = _minimumSpawnTime;
            }
        }
        private double _maximumSpawnTime;

        public double MaxmimumSpawnTime
        {
            get
            {
                return _maximumSpawnTime;

            }
            set
            {
                value = _maximumSpawnTime;
            }
        }
        // i think literally all this needs to do is gimme a spawn time i can work off of, sooooo...
        public double GenerateSpawnTime()
        {
            int toConvert = Convert.ToInt32(_random.Next(Convert.ToInt32(Math.Floor(_minimumSpawnTime)), Convert.ToInt32(Math.Ceiling(_maximumSpawnTime))));

            double toReturn = Convert.ToDouble(toConvert) + _random.NextDouble();
            return toReturn;
        }

    }
}
