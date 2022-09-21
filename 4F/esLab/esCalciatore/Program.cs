//Alessio Modonesi 4F
/*Tramite la programmazione ad oggetti scrivere un programma in C# che, dopo aver costruito la classe Calciatore, visualizzi in output: 
il nome del calciatore, il ruolo, la squadra ed i gol segnati (i dati vengono assegnati all'interno del codice).*/
using System; //istruzione per l'utilizzo della libreria system

namespace Calciatore //parola chiave per dichiarare un ambito
{
    class Calciatore //pagina 20
    {
        //attributi
        string nome;
        string squadra;
        string ruolo;
        int golSegnati;

        //metodo di default: costruttore
        public Calciatore(string nome, string squadra, string ruolo)
        {
            //la parola "this" serve per inizializzare gli attributi
            this.nome = nome; 
            this.squadra = squadra;
            this.ruolo = ruolo;
            golSegnati = 0;
        }

        //metodi
        public void aggiornaGolSegnati(int gol)
        {
            golSegnati += gol;
        }

        public void visualizzaGol()
        {
            Console.WriteLine("{0} - {2} - gol segnati: {1}",nome,golSegnati,ruolo);
        }

        static void Main(string[] args)
        {
            Calciatore c = new Calciatore("Filippo Inzaghi","Milan","Attaccante");
            c.visualizzaGol();
            c.aggiornaGolSegnati(2);
            c.visualizzaGol();
        }
    }
}
