//Alessio Modonesi 3F

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sparatutto_Zombie
{
    class Bullet
    {
        public string direction; //direzione del proiettile
        public int bulletLeft;
        public int bulletTop;
        private int speed = 20; //velocità del proiettile

        private PictureBox bullet = new PictureBox(); //creo una nuova PictureBox
        private Timer bulletTimer = new Timer(); //creo un nuovo Timer

        public void MakeBullet(Form form) //questa funzione gestisce la creazione dei proiettili in gioco
        {
            bullet.BackColor = Color.White; //imposto il colore dei proiettili
            bullet.Size = new Size(5,5); //imposto la dimensione dei proiettili
            bullet.Tag = "bullet"; //aggiungo un tag ai proiettili
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet); //aggiungo il proiettile nello schermo

            bulletTimer.Interval = speed; //imposto l'intervallo di tempo alla velocità
            bulletTimer.Tick += new EventHandler(BulletTimerEvent); //assegno un evento al Timer
            bulletTimer.Start(); //starto il Timer
        }

        private void BulletTimerEvent(object sender, EventArgs e) //questa funzione gestisce il Timer dei proiettili
        {
            if (direction == "left") //se la direzione è = sinistra
            {
                bullet.Left -= speed; //muovo il proiettile a sinistra
            }

            if (direction == "right") //se la direzione è = destra
            {
                bullet.Left += speed; //muovo il proiettile a destra
            }

            if (direction == "up") //se la direzione è = su
            {
                bullet.Top -= speed; //muovo il proiettile in su
            }
             
            if (direction == "down") //se la direzione è = giù
            {
                bullet.Top += speed; //muovo il proiettile in giù
            }

            if (bullet.Left < 10 || bullet.Left > 860 || bullet.Top < 10 || bullet.Top > 600 )
            {
                bulletTimer.Stop(); //stoppo il Timer
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
            }
        }
    }
}
