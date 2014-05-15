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
        DrawShapes drawShapes;

        List<Enemy> enemyList;
        List<Bullet> bulletList;
        List<Obstacle> obstacleList;
        List<Target> targetList;
        Rocket rocket;

        public GamePanel()
        {
            this.BackColor = Color.Black;
            this.Dock = DockStyle.Fill;

            //Setter opp alle objekt listene
            enemyList = new List<Enemy>();
            bulletList = new List<Bullet>();
            obstacleList = new List<Obstacle>();
            targetList = new List<Target>();
            rocket = new Rocket();

            //Lager et test objekt og legger det til i obstacle lista
            Obstacle obstackle1 = new Obstacle(200, 200, 200, 200, Color.BlueViolet);
            obstacleList.Add(obstackle1);

            // Lager et nytt DrawShapes objekt som skal ta seg av oppdatering og opptegning av objektene
            drawShapes = new DrawShapes(enemyList, bulletList, obstacleList, targetList, rocket);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            drawShapes.Draw(e);
        }

        
    }
}
