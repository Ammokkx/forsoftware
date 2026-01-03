using Microsoft.Xna.Framework;
using SkiingMinigame.FakeBL.Objects.Spawner;
using SkiingMinigame.FakeBL.Objects.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.Services.Spawners
{
    public abstract class Spawner
    {
        // originally i wanted one spawner for everything but then the snowman decided to be funny, so this is abstract now
        public ObstacleSpawnTimeGenerator obstacleSpawner;
        public double timeUntilSpawn;
        internal double elapsedTime;
        protected Game1 Context;
        public Spawner(List<ObstacleSprite> obstacle, Game1 context, double minSpawnSpeed, double maxSpawnSpeed)
        {
            obstacleSpawner = new ObstacleSpawnTimeGenerator(minSpawnSpeed, maxSpawnSpeed);
            _obstacle = obstacle;
            timeUntilSpawn = obstacleSpawner.GenerateSpawnTime();
            Context = context;
            elapsedTime = 0;
        }

        public List<ObstacleSprite> _obstacle;


        public abstract void Spawn(double gametime);
        
            
    }
}
