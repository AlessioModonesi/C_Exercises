//Alessio Modonesi 3F

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Sparatutto_Zombie
{
    public partial class Game : Form
    {
        bool goLeft, goRight, goUp, goDown, gameOver, Timer;
        string facing = "up";
        int playerHealth = 100; //vita del player
        int speed = 10; //velocità del player
        int ammo = 10; //ammo iniziali
        int score = 0; //punteggio
        int zombieSpeed = 2; //velocità dello zombie

        Random randNum = new Random(); //funzione Random
        public static DateTime thisHour = DateTime.Now; //funzione Date
        public static string fileNamePunteggio = @"registroPartite.txt"; //Sparatutto Zombie\bin\Debug

        List<PictureBox> zombiesList = new List<PictureBox>();

        public Game() //questa è la funzione principale
        {
            InitializeComponent();
            RestartGame(); 
            GameTimer.Stop();
            Timer = false;
        }

        private void MainTimerEvent(object sender, EventArgs e) //questa funzione gestisce il MainTimer
        {
            if (playerHealth > 0) //se la vita del player è > 0
            {
                healthBar.Value = playerHealth; //assegno alla il valore della salute del player
            }

            else //se la vita del player è = 0
            {
                gameOver = true; //cambio lo stato di gameOver
                player.Image = Properties.Resources.dead; //cambio l'immagine del player
                GameTimer.Stop(); //fermo il timer
                Timer = false;
            }

            txtAmmo.Text = "Ammo: " + ammo; //assegno il valore di "ammo" al contatore nel form
            txtScore.Text = "Kills: " + score; //assegno il valore di "score" al contatore nel form

            //da qui faccio in modo che il player si muova
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed; //muovo il player verso sinistra
            }

            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed; //muovo il player verso destra
            }

            if (goUp == true && player.Top > 40) //ho messo > 40 in modo che il personaggio non vada a sovrapporsi con la parte dei contatori in alto
            {
                player.Top -= speed; //muovo il player verso l'alto
            }

            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed; //muovo il player verso il basso
            }

            foreach (Control x in this.Controls) //per ogni controllo x
            {
                if (x is PictureBox && (string)x.Tag == "ammo") //se X è una PictureBox e ha un tag "ammo"
                {
                    if (player.Bounds.IntersectsWith(x.Bounds)) //se il player tocca le ammo
                    {
                        this.Controls.Remove(x); //rimuovo le ammo dallo schermo
                        ((PictureBox)x).Dispose();
                        ammo += 5; //aggiungo 5 ammo al contatore
                    }
                }

                if (x is PictureBox && (string)x.Tag == "bullet") //se X è una PictureBox e ha un tag "bullet"
                {
                    //se il proiettile tocca i bordi dello schermo
                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 940 || ((PictureBox)x).Top < 40 || ((PictureBox)x).Top > 700)
                    {
                        this.Controls.Remove(((PictureBox)x)); //rimuovo il proiettile dallo schermo
                        ((PictureBox)x).Dispose(); 
                    }
                }


                if (x is PictureBox && (string)x.Tag == "zombie") //se X è una PictureBox e ha un tag "zombie"
                {
                    if (player.Bounds.IntersectsWith(x.Bounds)) //se il player tocca uno zombie
                    {
                        playerHealth -= 1; //tolgo 1 di vita 
                    }

                    //da qui faccio in modo che lo zombie insegua il player
                    if (x.Left > player.Left) 
                    {
                        x.Left -= zombieSpeed; //muovo lo zombie a sinistra
                        ((PictureBox)x).Image = Properties.Resources.zleft; //cambio l'immagine dello zombie
                    }

                    if (x.Left < player.Left)
                    {
                        x.Left += zombieSpeed; //muovo lo zombie a destra
                        ((PictureBox)x).Image = Properties.Resources.zright; //cambio l'immagine dello zombie
                    }

                    if (x.Top > player.Top)
                    {
                        x.Top -= zombieSpeed; //muovo lo zombie in alto
                        ((PictureBox)x).Image = Properties.Resources.zup; //cambio l'immagine dello zombie
                    }

                    if (x.Top < player.Top)
                    {
                        x.Top += zombieSpeed; //muovo lo zombie in basso
                        ((PictureBox)x).Image = Properties.Resources.zdown; //cambio l'immagine dello zombie
                    }
                }

                foreach (Control j in this.Controls) //per ogni controllo j
                {
                    //se J e X sono delle PictureBox e hanno rispettivamente il tag "bullet" e "zombie"
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds)) //se un proiettile tocca uno zombie
                        {
                            score++; //aumenta il punteggio

                            this.Controls.Remove(j); //rimuovi il proiettile
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x); //rimuovi lo zombie
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            MakeZombies(); //richiamo la funzione MakeZombies per far spawnare altri zombie
                        }
                    }
                }
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e) //questa funzione gestisce il movimento del player
        {
            if (gameOver == true) return; //se gameOver = true, non fare nulla qui
            
            if (e.KeyCode == Keys.A && Timer == true) //se premo 'A'
            {
                goLeft = true; 
                facing = "left"; 
                player.Image = Properties.Resources.left; //cambio la PictureBox del player
            }

            if (e.KeyCode == Keys.D && Timer == true) //se premo 'D'
            {
                goRight = true; 
                facing = "right"; 
                player.Image = Properties.Resources.right; //cambio la PictureBox del player
            }

            if (e.KeyCode == Keys.W && Timer == true) //se premo 'W'
            {
                facing = "up"; 
                goUp = true; 
                player.Image = Properties.Resources.up; //cambio la PictureBox del player
            }

            if (e.KeyCode == Keys.S && Timer == true) //se premo 'S'
            {
                facing = "down"; 
                goDown = true; 
                player.Image = Properties.Resources.down; //cambio la PictureBox del player
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)  //questa funzione gestisce il movimento del player
        {
            if (gameOver == true) return; //se gameOver = true, non fare nulla qui

            if (e.KeyCode == Keys.A && Timer == true)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.D && Timer == true)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.W && Timer == true)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.S && Timer == true)
            {
                goDown = false;
            }

            //se premo 'Spazio', se ammo > 0, se il gameOver è falso e se il Timer è partito
            if (e.KeyCode == Keys.Space && ammo > 0 && gameOver == false && Timer == true) 
            {
                ammo--; //tolgo 1 ammo dal contatore
                ShootBullet(facing);

                if (ammo < 1) //se le ammo sono < 1
                {
                    DropAmmo(); //richiamo la funzione e droppo delle ammo
                }
            }

            //se premo 'Enter', se gameOver è falso e se il Timer è fermo
            if (e.KeyCode == Keys.Enter && gameOver == false && Timer == false) 
            {
                GameTimer.Start(); //starto il GameTimer
                Timer = true;
            }

            //se premo 'Esc', se gameOver è falso e se il Timer è attivo
            if (e.KeyCode == Keys.Escape && gameOver == false && Timer == true)
            {
                GameTimer.Stop(); //fermo il GameTimer
                Timer = false;
            }
        }

        private void PlayButton_Click(object sender, EventArgs e) //questa funzione gestisce il tasto "Play"
        {
            if (gameOver == false && Timer == false) //se il gameOver è falso ed il Timer è fermo
            {
                GameTimer.Start(); //starto il GameTimer
                Timer = true;
            }
        }

        private void PauseButton_Click(object sender, EventArgs e) //questa funzione gestisce il tasto "Pause"
        {
            if (gameOver == false && Timer == true) //se il gameOver è falso ed il timer è attivo
            {
                GameTimer.Stop(); //stoppo il GameTimer
                Timer = false;
            }
        }

        private void RestartButton_Click(object sender, EventArgs e) //questa funzione gestisce il tasto "Restart"
        {
            if (gameOver == true && Timer == false) //se il gameOver è vero ed il timer è fermo
            {
                int i = 0;

                if (score != 0) //faccio in modo che non venga salvato un punteggio = 0
                {
                    while (i == 0) //creo un while per il salvataggio del punteggio
                    {
                        string output = AppDomain.CurrentDomain.BaseDirectory + fileNamePunteggio;
                        StreamWriter OutputPunteggio = new StreamWriter(output, true);
                        OutputPunteggio.Write(DateTime.Now + "\n");
                        OutputPunteggio.Write(Program.nomeUtente + " ha eliminato " + score + " zombie\n\n");
                        OutputPunteggio.Close();
                        i++;
                    }
                }

                RestartGame(); //richiamo la funzione RestartGame
                GameTimer.Stop(); //stoppo il GameTimer
                Timer = false;
            } 
        }

        private void HomeLabel_Click(object sender, EventArgs e) //questa funzione gestisce il tasto "Home"
        {
            if (gameOver == false && Timer == false) //se il gameOver è falso ed il timer è fermo
            {
                //torno a Form2
                Home home = new Home();
                home.Show();
                this.Close();
            }
        }

        private void HelpButton_Click(object sender, EventArgs e) //questa funzione gestisce il tasto "Help"
        {
            if (Timer == false) //se il Timer è fermo
            {
                MessageBox.Show("Utilizza WASD per muoverti \nUtilizza SPACE per sparare \nUtilizza ENTER per avviare \nUtilizza ESCAPE per fermare"); //mostro un messaggio informativo
            }
        }

        private void ShootBullet(string direction) //questa funzione gestisce i proiettili in gioco
        {
            Bullet shootBullet = new Bullet(); //creo un'istanza della classe Bullet;
            shootBullet.direction = direction; //assegno la direzione al proiettile;
            shootBullet.bulletLeft = player.Left + (player.Width / 2); //posiziono il proiettile a metà del player
            shootBullet.bulletTop = player.Top + (player.Height / 2); //posiziono il proiettile a metà del player
            shootBullet.MakeBullet(this); //lancio la funzione MakeBullet dalla classe Bullet
        }

        private void MakeZombies() //questa funzione gestisce lo spawn degli zombie in gioco
        {
            PictureBox zombie = new PictureBox(); //creo una nuovo PictureBox per gli zombie
            zombie.Image = Properties.Resources.zdown; //imposto l'immagine dello zombie
            zombie.SizeMode = PictureBoxSizeMode.AutoSize; //metto l'AutoSize sulle PictureBox
            zombie.Tag = "zombie"; //aggiungo un tag agli zombie

            zombie.Left = randNum.Next(0,900); //spawn randomico tramite la funzione Random
            zombie.Top = randNum.Next(0,800); //spawn randomico tramite la funzione Random

            zombiesList.Add(zombie); //aggiungo uno zombie alla lista
            this.Controls.Add(zombie); //aggiungo uno zombie in gioco
            player.BringToFront(); 
        }

        private void DropAmmo() //questa funzione gestisce il drop delle ammo in gioco
        {
            PictureBox ammo = new PictureBox(); //creo una nuovo PictureBox per le ammo
            ammo.Image = Properties.Resources.ammo; //imposto l'immagine delle ammo
            ammo.SizeMode = PictureBoxSizeMode.AutoSize; //metto l'AutoSize sulle PictureBox
            ammo.Tag = "ammo"; //aggiungo un tag alle ammo
          
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width); //spawn randomico tramite la funzione Random
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height); //spawn randomico tramite la funzione Random

            this.Controls.Add(ammo); //aggiungo le ammo in gioco
            ammo.BringToFront(); 
            player.BringToFront(); 
        }

        private void RestartGame() //questa funzione gestisce il Restart del gioco
        {
            player.Image = Properties.Resources.up; //cambio la PictureBox del player

            foreach (PictureBox i in zombiesList) //per ogni zombie nella lista
            {
                this.Controls.Remove(i); //rimuovo quella PictureBox
            }

            foreach (Control x in this.Controls) //per ogni controllo x
            {
                if (x is PictureBox && (string)x.Tag == "ammo") //se X è una PictureBox e ha un tag "ammo"
                {
                    this.Controls.Remove(x); //rimuovo le ammo dallo schermo
                    ((PictureBox)x).Dispose();    
                }
            }

            zombiesList.Clear(); //pulisco la lista di PictureBox degli zombie

            for (int i = 0; i < 3; i++) //aggiungo 3 zombie
            {
                MakeZombies(); //con la funzione MakeZombies
            }

            player.Left = 434; //riporto il player in posizione centrale
            player.Top = 300; //riporto il player in posizione centrale

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            playerHealth = 100; //reimposto la vita del player a 100
            score = 0; //reimposto il punteggio a 0
            ammo = 10; //reimposto le ammo a 10
        }
    }
}
