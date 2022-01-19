//Alessio Modonesi 4F
using System;

namespace Fantacalcio
{
    class Calciatore //classe del calciatore
    {
        //attributi del calciatore
        string nome; //nome e cognome del calciatore
        string ruolo; //ruolo del calciatore
        string squadra; //squadra del calciatore

        //metodo di default: costruttore
        public Calciatore(){}

        public string SetNome() //questo metodo setta il nome del calciatore
        {
            nome = Console.ReadLine(); //input della variabile nome
            return nome; //ritorno la variabile nome (anche fuori dalla classe calciatore)
        }  

        public string SetRuolo() //questo metodo setta il ruolo del calciatore
        { 
            ruolo = Console.ReadLine(); //input della variabile ruolo
            return ruolo; //ritorno la variabile ruolo (anche fuori dalla classe calciatore)
        }  

        public string SetSquadra() //questo metodo setta la squadra del calciatore
        {
            squadra = Console.ReadLine(); //input della variabile squadra
            return squadra; //ritorno la variabile squadra (anche fuori dalla classe calciatore)
        }
    }
}