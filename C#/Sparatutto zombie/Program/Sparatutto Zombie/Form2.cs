//Alessio Modonesi 3F

using System;
using System.Windows.Forms;

namespace Sparatutto_Zombie
{
    public partial class Home : Form
    {
        
        public Home() //questa è la funzione principale
        {
            InitializeComponent();
        }

        private void StartLabel_Click(object sender, EventArgs e) //questa è la funzione principale
        {
            if (nomeUtenteBox.Text == "") //se il nomeUtente è vuoto
            {
                MessageBox.Show("Inserisci un nome utente"); //mostro un messaggio di errore
            }
            
            else 
            {
                //apro Form1
                Game game = new Game();
                game.Show();
                this.Hide();
            }        
        }

        private void nomeUtenteBox_TextChanged(object sender, EventArgs e) //questa funzione gestisce il nome utente
        {
            Program.nomeUtente = nomeUtenteBox.Text; //assegno alla variabile "nomeUtente" il nome digitato dall'utente
        }

        private void ExitLabel_Click(object sender, EventArgs e) //questa funzione gestisce il tasto "Exit"
        {
            Application.Exit(); //esco dal form
        }
    }
}
