using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigameBL.Interfaces
{
    public interface IPlayerInputMovementService
    {
        bool Player1ShouldGoDown();
        bool Player1ShouldGoLeft();
        bool Player1ShouldGoRight();
        bool Player1ShouldGoUp();
        bool Player2ShouldGoDown();
        bool Player2ShouldGoLeft();
        bool Player2ShouldGoRight();
        bool Player2ShouldGoUp();
    }
}
