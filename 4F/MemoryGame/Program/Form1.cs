//Alessio Modonesi 4F
using System;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox carta1; //creo una PictureBox
        int restanti = 8; //numero di coppie restanti
        int tempoRimasto = 120; 
        int turno; //turno di gioco
        bool turnoG1; //turno del G1
        int punteggioG1 = 0; //punteggio del G1
        int punteggioG2 = 0; //punteggio del G2
        int tmp = 0; //variabile tmp

        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
        }

        void NewGame() //questo metodo consente di creare una nuova partita, ripristinando i valori delle variabili
        {
            tempoRimasto = 120; 
            punteggioG1 = 0; 
            punteggioG2 = 0;
            restanti = 8;
            tmp = 0;
            LabelRestanti.Text = "Rimanenti: " + restanti; //aggiorno il label sulla schermata
            LabelPuntiG1.Text = "Punti G1: " + punteggioG1; //aggiorno il label sulla schermata
            LabelPuntiG2.Text = "Punti G2: " + punteggioG2; //aggiorno il label sulla schermata
            PrimoTurno(); 
            ChangeTurno(); 
            SetRandom(); 
            TuttoVisibile(); 
            ResetImmagini(); 
            TuttoAttivo(); 
            TimeStop(); 
        }

        public int PrimoTurno() //questo metodo decide randomicamente chi inizierà a partita
        {
            Random rnd = new Random(); //creo un istanza della funzione random
            turno = rnd.Next(0, 2); //assegno alla variabile turno un valore random (0, 1)
            return turno; //restituisco il valore

        }

        public void ChangeTurno() //questa funzione gestirà il cambio di turno
        {
            if (turno == 0) //turno G1
            {
                turnoG1 = true; 
                LabelTurno.Text = "Turno: G1";
                turno++; //incremento la variabile per passare il turno
            }

            else if (turno == 1) //turno G2
            {
                turnoG1 = false;
                LabelTurno.Text = "Turno: G2";
                turno--; //decremento la variabile per passare il turno
            }
        }

        void MostraImmagine(PictureBox box) //questo metodo contiene tutte le immagini
        {
            switch(Convert.ToInt32(box.Tag))
            {
                case 1:
                    box.Image = Properties.Resources._1;
                    break;
                case 2:
                    box.Image = Properties.Resources._2;
                    break;
                case 3:
                    box.Image = Properties.Resources._3;
                    break;
                case 4:
                    box.Image = Properties.Resources._4;
                    break;
                case 5:
                    box.Image = Properties.Resources._5;
                    break;
                case 6:
                    box.Image = Properties.Resources._6;
                    break;
                case 7:
                    box.Image = Properties.Resources._7;
                    break;
                case 8:
                    box.Image = Properties.Resources._8;
                    break;
                default:
                    box.Image = Properties.Resources._0; //immagine di default
                    break;
            }
        }

        void SetRandom() //questa immagine gestisce il sort random delle carte
        {
            int[] array = new int[16]; //creo un array con le 16 carte
            int i, carte = 0;
            Random cont = new Random(); //creo un istanza della funzione random

            while (carte < 16) //finchè non sono state passate tutte e 16 le carte
            {
                i = cont.Next(1, 17); //assegno a i un valore randomico che va da 1 a (17-1)
                if (Array.IndexOf(array, i) == -1) //cerco se quella posizione è libera
                {
                    array[carte] = i; //assegno inserisco la carta in quella posizione
                    carte++; //incremento la variabile
                }
            }

            for (carte = 0; carte < 16; carte++) //finchè non ho posizionato tutte e 16 le carte
            {
                if (array[carte] > 8) array[carte] -= 8; //se il valore in posizione [carte] è > 8 (numero di coppie), sottraggo 8 all'array
            }

            carte = 0;

            foreach (Control x in this.Controls) //faccio un controllo
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Tag = array[carte].ToString();
                    carte++;
                }
            }
        }

        void ConfrontaCarte(PictureBox primaCarta, PictureBox secondaCarta) //questo metodo serve per confrontare le carte scoperte
        {
            if (primaCarta.Tag.ToString() == secondaCarta.Tag.ToString()) //se le due carte sono uguali
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500); //sospendo il thread
                primaCarta.Visible = false; //rendo invisibile la prima carta
                secondaCarta.Visible = false; //rendo invisibile la seconda carta

                if (--restanti == 0) //se non ci sono più carte
                {
                    if (turnoG1 == true) //se è il turno del G1
                    {
                        punteggioG1++; //incremento il punteggio
                        LabelPuntiG1.Text = "Punti G1: " + punteggioG1; //aggiorno il label sulla schermata
                    }

                    else //se è il turno del G2
                    {
                        punteggioG2++; //incremento il punteggio
                        LabelPuntiG2.Text = "Punti G2: " + punteggioG2; //aggiorno il label sulla schermata
                    }

                    Vincitore(); //richiamo il metodo vincitore che assegnarà la vittoria a uno dei 2 giocatori
                }

                else //se ci sono ancora carte
                {
                    LabelRestanti.Text = "Restanti: " + restanti; //aggiorno le carte restanti

                    if (turnoG1 == true) // se è il turno del G1
                    {
                        punteggioG1++; //incremento il punteggio
                        LabelPuntiG1.Text = "Punti G1: " + punteggioG1; //aggiorno il label sulla schermata
                    }
                    else //se è il turno del G2
                    {
                        punteggioG2++; //incremento il punteggio
                        LabelPuntiG2.Text = "Punti G2: " + punteggioG2; //aggiorno il label sulla schermata
                    }
                }

            }

            else //se le due carte sono diverse
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500); //sospendo il thread
                primaCarta.Image = Properties.Resources._0; //reimposto l'immagine di default sulla prima carta
                secondaCarta.Image = Properties.Resources._0; //reimposto l'immagine di default sulla seconda carta
                ChangeTurno(); //cambio turno
            }
        }

        public void Vincitore() //questo metodo assegna la vittoria, confrontando i punteggi dei due giocatori
        {
            timer.Enabled = false; //fermo il timer
            LabelRestanti.Text = "Congratulazioni"; //aggiorno il contatore delle carte restanti

            if (punteggioG1 > punteggioG2) //se G1 ha più punti di G2
            {
                MessageBox.Show("G1 ha vinto!!! \nPunteggio: " + punteggioG1 + " - " + punteggioG2 , "COMPLIMENTI"); //mostro un messaggio
                NewGame(); //creo una nuova partita
            }

            else if (punteggioG1 < punteggioG2) //se G1 ha meno punti di G2
            {
                MessageBox.Show("G2 ha vinto!!! \nPunteggio: " + punteggioG1 + " - " + punteggioG2, "COMPLIMENTI"); //mostro un messaggio
                NewGame(); //creo una nuova partita
            }

            else //se G1 e G2 hanno gli stessi punti
            {
                MessageBox.Show("Pareggio \nPunteggio: " + punteggioG1 + " - " + punteggioG2, "COMPLIMENTI"); //mostro un messaggio
                NewGame(); //creo una nuova partita
            }
        }

        void ResetImmagini() //questo metodo consenti di resettare le immagini, mostrando quella di default
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox) (x as PictureBox).Image = Properties.Resources._0;
            }
        }
        
        void TuttoVisibile() //questo metodo rende tutte le PictureBox visibili
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox) (x as PictureBox).Visible = true;
            }
        }

        void TuttoAttivo() //questo metodo attiva il click sulle PictureBox
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox) (x as PictureBox).Enabled = true;
            }
        }

        void TuttoDisattivo() //questo metodo disattiva il click sulle PictureBox
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox) (x as PictureBox).Enabled = false;
            }
        }

        private void Box_Click(object sender, EventArgs e) //questo metodo rappresenta l'evento di click sulle PictureBox
        {
            PictureBox carta2 = (sender as PictureBox);
            MostraImmagine((sender as PictureBox));
            if (tmp == 0)
            {
                carta1 = carta2; //assegnazione
                tmp = 1; //incremento la variabili
            }

            else if (carta1 != carta2) //se le 2 carte sono diverse
            {
                ConfrontaCarte(carta1, carta2); //richiamo la funzione di confronto tra le carte
                tmp = 0; //decremento la variabili
            }
           
        }

        private void GameTimer_Tick(object sender, EventArgs e) //questo metodo rappresenta il tick del timer di gioco
        {
            
            if (--tempoRimasto == 0) //se il tempo è scaduto
            {
                timer.Enabled = !timer.Enabled; //fermo il tempo
                LabelTime.Text = "Tempo scaduto"; //aggirono il label sulla schermata
                MessageBox.Show("Pareggio", "TEMPO SCADUTO"); //mostro un messaggio
                TuttoDisattivo(); //richiamo il metodo
                NewGame(); //creo una nuova partita
            }
            else LabelTime.Text = "Tempo rimasto: "+ tempoRimasto; //se il tempo è > 0, aggiorno il label a schermo
        }

        public void TimeStop() //questo metodo consente di fermare il timer
        {
            timer.Enabled = false; //fermo il timer
            LabelTime.Text = "Tempo rimasto: " + tempoRimasto; //aggiorno il label sulla schermata
            TuttoDisattivo(); //richiamo il metodo
        }

        private void playButton_Click(object sender, EventArgs e) //questo metodo rappresenta l'evento di click del tasto "Play"
        {
            timer.Enabled = true; //attivo il tempo
            LabelTime.Text = "Tempo rimasto: " + tempoRimasto; //aggiorno il label sulla schermata
            TuttoAttivo(); //richiamo il metodo
        }

        private void pauseButton_Click(object sender, EventArgs e) //questo metodo rappresenta l'evento di click del tasto "Pausa"
        {
            TimeStop(); //richiamo la funzione
        }

        private void newGameButton_Click(object sender, EventArgs e) //questo metodo rappresenta l'evento di click del tasto "Nuova partita"
        {
            NewGame(); //creo una nuova partita
        }

        private void regole_Click(object sender, EventArgs e) //questo metodo rappresenta l'evento di click del tasto "Regole"
        {
            MessageBox.Show("Guarda l'indicatore del turno per vedere a chi tocca." +
                "\nOgni giocatore girerà due carte se a scelta, se le carte sono uguali guadagnerà un punto e potrà giocare un altro turno." +
                "\nVince chi indovina più coppie", "REGOLE"); //mostro un messaggio
        }    
    }
}
