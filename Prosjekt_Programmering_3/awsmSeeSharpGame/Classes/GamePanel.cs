using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    public class GamePanel : PictureBox
    {
        List<Enemy> enemyList;
        List<Bullet> bulletList;
        List<Obstacle> obstacleList;
        List<Target> targetList;
        Rocket rocket;

        public GamePanel()
        {
            this.BackColor = Color.Black;
            this.Dock = DockStyle.Fill;

            Obstacle obstackle1 = new Obstacle(200, 200, Color.BlueViolet);
            obstacleList = new List<Obstacle>();
            obstacleList.Add(obstackle1);
        }

        
    }
}
