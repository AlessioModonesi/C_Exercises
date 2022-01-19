//Alessio Modonesi 4F
//Tramite la programmazione ad oggetti scrivere un programma in C# che dopo aver letto in input il raggio di circonferenza,
//calcoli e visualizzi la misura del diametro (2*r), della cinconferenza (2*r*pi) e la sua area (r²*pi). Utilizzare la funzione Math.PI.
using System;

namespace es_4_cerchio
{
    class Cerchio
    {
        //attributi
        double r; //dichiaro la variabile
        
        //metodo di default: costruttore
        public Cerchio()
        {
            r = 0; //inizializzo la variabile
        }
        
        //metodi
        public bool leggiRaggio() //questo metodo mi consente di settare il valore del raggio, controllando che il valore inserito sia valido
        {
            try
            {
                r = Convert.ToDouble(Console.ReadLine()); //input di r

                if(r <= 0) //se r non è valido
                return false; //ritorno il valore

                else
                return true; //ritorno il valore
            }

            catch
            {
                return false; //ritorno il valore
            }
        }

        public double calcolaDiametro() //questo metodo calcola il diametro del cerchio, utilizzando il raggio
        {
            double diametro = 2 * r; //inizializzo la variabile diametro e ne calcolo il valore
            return diametro; //ritorno il valore
        }

        public double calcolaCrf() //questo metodo calcola la crf del cerchio, utilizzando il raggio
        {
            double crf = 2 * r * Math.PI; //inizializzo la variabile crf e ne calcolo il valore
            return crf; //ritorno il valore
        }

        public double calcolaArea() //questo metodo calcola il diametro del cerchio, utilizzando il raggio
        {
            double area = r * r * Math.PI; //inizializzo la variabile area e ne calcolo il valore
            return area; //ritorno il valore
        }

        static void Main(string[] args)
        {
            Cerchio c = new Cerchio(); //creo un'istanza della classe Cerchio
            Console.Write("Inserisci il valore del raggio: ");
            while(c.leggiRaggio()== false) //questo è il ciclo del try-catch, che mi permette di riiserire il valore qualora fosse sbagliato
            {
                Console.WriteLine("ERROR: valore non valido"); //messaggio di errore
                Console.Write("Inserisci il valore del raggio: ");
            }

            double diametro = c.calcolaDiametro(); //passo alla variabile il valore del diamentro
            double crf = c.calcolaCrf(); //passo alla variabile il valore della crf
            double area = c.calcolaArea(); //passo alla variabile il valore dell'area

            Console.WriteLine("r = {0} cm \n2*r = {1} cm \ncrf = {2} cm \nA = {3} cm²", c.r, diametro, crf, area); //mostro a video i risultati
        }
    }
}
