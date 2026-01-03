using Microsoft.Xna.Framework;
using SkiingMinigame.FakeBL.Objects.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.Services.Spawners
{

    public class TreeSpawner : Spawner
    {
        public TreeSpawner(List<ObstacleSprite> obstacle, Game1 context, double minSpawnSpeed, double maxSpawnSpeed) : base(obstacle, context, minSpawnSpeed, maxSpawnSpeed)
        {
        }

        public override void Spawn(double gametime)
        {
            if (elapsedTime > timeUntilSpawn)
            {
                _obstacle.Add(new ObstacleSprite(ContentService.Instance.GetTexture(ContentService.TreeBottom), new Vector2(Random.Shared.Next(Context._graphics.PreferredBackBufferWidth), Context._graphics.PreferredBackBufferHeight)));

                timeUntilSpawn = obstacleSpawner.GenerateSpawnTime();
                elapsedTime = 0;
                return;
            }

            elapsedTime += gametime;
        }
    }
}
