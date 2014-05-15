﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    public class DrawShapes
    {
        List <Enemy> enemyList;
        List <Bullet> bulletList;
        List <Obstacle> obstacleList;
        List<Target> targetList;
        Rocket rocket;

        public DrawShapes(List<Enemy> _enemylist, List<Bullet> _bulletList, List<Obstacle> _obstacleList, List<Target> _targetList, Rocket _rocket)
        {
            enemyList = _enemylist;
            bulletList = _bulletList;
            obstacleList = _obstacleList;
            targetList = _targetList;
            rocket = _rocket;
        }

        public void update()
        {
            foreach (Bullet bullet in bulletList) {
                bullet.Move();
            }

            rocket.Move();
        }

        public void CollisonCheck()
        {
            foreach (Bullet bullet in bulletList)
            {
                bullet.Collision();
            }

            rocket.Collision();
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (Obstacle obstacle in obstacleList)
            {
                obstacle.Draw(e);
            }
        }
    }
}
