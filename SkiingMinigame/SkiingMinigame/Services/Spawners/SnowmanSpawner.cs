using Microsoft.Xna.Framework;
using System;
using SkiingMinigame.FakeBL.Objects.Sprites;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.Services.Spawners
{
    public class SnowmanSpawner : Spawner
    {
        public SnowmanSpawner(List<ObstacleSprite> obstacle, Game1 context, double minSpawnSpeed, double maxSpawnSpeed) : base(obstacle, context, minSpawnSpeed, maxSpawnSpeed)
        {
        }

        public override void Spawn(double gametime)
        {
            if (elapsedTime > timeUntilSpawn)
            {
                _obstacle.Add(new SnowManSprite(ContentService.Instance.GetTexture(ContentService.Snowman), new Vector2(Context._graphics.PreferredBackBufferWidth, Random.Shared.Next(Context._graphics.PreferredBackBufferHeight))));

                timeUntilSpawn = obstacleSpawner.GenerateSpawnTime();
                elapsedTime = 0;
                return;
            }

            elapsedTime += gametime;
        }
    }
    }
