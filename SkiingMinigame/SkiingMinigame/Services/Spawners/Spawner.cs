using Microsoft.Xna.Framework;
using MonoGame_Pikachu.Services;
using SkiingMinigameBL.Objects.Spawner;
using SkiingMinigameBL.Objects.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.Services.Spawners
{
    public class Spawner
    {

        public ObstacleSpawnTimeGenerator obstacleSpawner;
        public double timeUntilSpawn;
        private double elapsedTime;
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


        public void Spawn(double gametime)
        {
            if (elapsedTime > timeUntilSpawn)
            {
                _obstacle.Add(new ObstacleSprite(ContentService.Instance.GetTexture(ContentService.Rock), new Vector2(Random.Shared.Next(Context._graphics.PreferredBackBufferWidth), Context._graphics.PreferredBackBufferHeight)));

                timeUntilSpawn = obstacleSpawner.GenerateSpawnTime();
                elapsedTime = 0;
                return;
            }

            elapsedTime += gametime;
        }
    }
}
