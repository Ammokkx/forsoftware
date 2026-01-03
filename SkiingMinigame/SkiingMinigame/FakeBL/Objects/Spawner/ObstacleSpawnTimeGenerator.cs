using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.FakeBL.Objects.Spawner
{
    public class ObstacleSpawnTimeGenerator
    {
        // stole the idea of spawners from bradley but i think i can make it have an original twist
        private Random _random;

        public ObstacleSpawnTimeGenerator(double minimumSpawnTime, double maxmimumSpawnTime)
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
                _minimumSpawnTime = value;
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
               _maximumSpawnTime = value;
            }
        }
        // i think literally all this needs to do is gimme a spawn time i can work off of, sooooo...
        public double GenerateSpawnTime()
        {
            return Convert.ToInt32(_random.Next(Convert.ToInt32(_minimumSpawnTime), Convert.ToInt32(_maximumSpawnTime+1)));

        }

    }
}
