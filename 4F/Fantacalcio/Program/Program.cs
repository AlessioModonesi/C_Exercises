//Alessio Modonesi 4F
using System;
using System.IO;
using System.Threading;

namespace Fantacalcio
{
    class Program //classe principale contenente il Main()
    {
        //dichiaro delle variabili a livello globale all'interno della classe program
        private static int sceltaInt = 0,turno = 0,tmp = 0,tmp1 = 0; //scelta del menù + variabile tmp
        private static int puntiG1 = 0, puntiG2 = 0, fantaMedia; //punti di G1 + punti di G2 + media dei vari calciatori
        private static string G1, G2, sceltaStr, mainPath = Environment.CurrentDirectory; //nomi dei due giocatori + scelta di eliminazione + stato dall'asta + mainPath
        private static string[] nomiAllenatori = new string[2]; //array contente i nomi dei due allenatori (vedi GetAllenatore())
        private static string[] squadraG1 = new string[0]; //array contenente la squadra del G1
        private static string[] squadraG2 = new string[0]; //array contenente la squadra del G2
        private static int[] arrayPuntiG1 = new int[0]; //array per il conteggio dei punti di G1
        private static int[] arrayPuntiG2 = new int[0]; //array per il conteggio dei punti di G2

        static void Main(string[] args)
        {
            while (tmp == 0) //ciclo while del menù principale
            {
                Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                Console.Clear(); //pulisco la console
                Menu1(); //richiamo la funzione che mostrerà il menù principale e ne gestirà la navigazione

                switch (sceltaInt)
                { //creo uno switch-case per i vari sotto-menù
                    case 1: //nuova partita
                        if (!Directory.Exists(mainPath + "\\Squadre")) //se non esiste la cartella "Squadre"
                        {
                            while (tmp == 0) //questo ciclo consente all'utente di riinserire i nomi dei due giocatori fino a quando G1 != G2
                            {
                                DirectoryInfo creaCartella = Directory.CreateDirectory(mainPath + "\\Squadre"); //creo la cartella "Squadre"
                                Console.Write("Inserisci il nome del 1o fantallenatore: ");
                                SetAllenatore(); //richiamo la funzione SetAllenatore che prenderà in input il nome del giocatore e ne creerà il file.txt con il suo nome
                                Console.Write("Inserisci il nome del 2o fantallenatore: ");
                                SetAllenatore(); //richiamo la funzione SetAllenatore che prenderà in input il nome del giocatore e ne creerà il file.txt con il suo nome

                                if (G1 == G2) //se i nomi dei due giocatori sono uguali
                                {
                                    Console.WriteLine("Ops, i nomi dei due giocatori non posso essere uguali");
                                    Directory.Delete(mainPath + "\\Squadre", true); //calcello la cartella "Squadre" e faccio ripartire il ciclo while
                                }
                                else //se i nomi dei due giocatori sono diversi
                                {
                                    Console.WriteLine("Ok, creazione cartella 'Squadre' completata");
                                    break; //fermo il ciclo
                                }
                            }
                        }
                        else Console.WriteLine("Ops, ho trovato già la cartella 'Squadre'"); //se la cartella "Squadre" esiste già, non faccio nulla
                        break; //torno al menù principale
                    
                    case 2: //partita esistente
                        if (Directory.Exists(mainPath + "\\Squadre")) //se esiste la cartella "Squadre"
                        {
                            Console.WriteLine("Ok, cartella 'Squadre' trovata");
                            tmp++; //esco dal ciclo while e porto l'utente a livello del secondo menù
                        }
                        else Console.WriteLine("Ops, non ho trovato la cartella 'Squadre'"); //se non esiste la cartella "Squadre", non faccio nulla
                        break; //torno al menù principale

                    case 3: //elimina partita
                        nomiAllenatori = GetAllenatore(nomiAllenatori);
                        if (Directory.Exists(mainPath + "\\Squadre")) //se esiste la cartella "Squadre"
                        {
                            while (tmp == 0) //questo ciclo consente all'utente di riinserire la scelta y/n in caso di errore
                            {
                                Console.Write("Vuoi veramente eliminare la cartella 'Squadre' corrente? y/n: ");
                                
                                while (SetSceltaStr() == false) //finchè la funzione SetSceltsStr restituisce false, continuo a reiserire il dato
                                {
                                    Console.WriteLine("Ops, comando non valido \n");
                                    Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                                    Console.Clear(); //pulisco la console
                                    Console.Write("Vuoi veramente eliminare la partita corrente? y/n: ");
                                }

                                if (sceltaStr == "y") //se la scelta corrisponde a "y"
                                {
                                    Directory.Delete(mainPath + "\\Squadre", true); //cancello la cartella "Squadre"
                                    File.Delete(mainPath + $"\\{nomiAllenatori[0]}_Punti.txt");
                                    File.Delete(mainPath + $"\\{nomiAllenatori[1]}_Punti.txt");
                                    Console.WriteLine("Ok, eliminazione della cartella 'Squadre' completata");
                                    break; //esco dal ciclo while
                                }
                                else //se la scelta corrisponde a "n"
                                {
                                    Console.WriteLine("Ok, cartella 'Squadre' NON eliminata");
                                    break; //esco dal ciclo while
                                }   
                            }
                        }
                        else Console.WriteLine("Ops, non ho trovato la cartella 'Squadre'"); //se non esiste la cartella "Squadre", non faccio nulla
                        break; //torno al menù principale

                    case 4: //esci dal programma
                        Console.WriteLine("Ok, esco dal programma");
                        Environment.Exit(0); //esco dal programma
                        break; //"torno al menù principale"

                    default: break; //il "case" "default" si attiva qual'ora il dato inserito non rientrasse in nessun "case" 
                                    //questo non accadrà per merito della funzione SetSceltaInt, ma devo comunque aggiungere il "case" per il corretto funzionamento dello switch
                }
            }

            tmp = 0; //riporto la variabili tmp al valore originale per consetire l'entrata nel ciclo while sottostante

            while (tmp == 0) //ciclo while del menù secondario
            {
                Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                Console.Clear(); //pulisco la console
                nomiAllenatori = GetAllenatore(nomiAllenatori); //tramite la funzione GetAllenatore, passo i nomi dei due allenatori dell'array
                squadraG1 = File.ReadAllLines(mainPath + $"\\Squadre\\{nomiAllenatori[0]}.txt");
                squadraG2 = File.ReadAllLines(mainPath + $"\\Squadre\\{nomiAllenatori[1]}.txt");
                using (StreamWriter a = File.CreateText($"{mainPath}\\{nomiAllenatori[0]}_Punti.txt")) { } //creo un file.txt per i punti di G1
                using (StreamWriter a = File.CreateText($"{mainPath}\\{nomiAllenatori[1]}_Punti.txt")) { } //creo un file.txt per i punti di G2
                Menu2(); //richiamo la funzione che mostrerà il menù secondario e ne gestirà la navigazione

                switch(sceltaInt)
                { //creo uno switch-case per i vari sotto-menù
                    case 1: //aggiorna una giornata
                        SetFormazione(); //richiamo la funzione SetFormazione, che mostrerà/schiererà le due formazioni dei giocatori
                        SetValutazione(); //richiamo la funzione SetValutazione, che gestirà l'inserimento della valutazione
                        break; //torno al menù secondario

                    case 2: //mostra la classifica
                        Classifica(); //richiamo la funzione Classifica, che gestirà il calcolo della classifica e la mostrerà a schermo
                        break; //torno al menù secondario

                    case 3: //fa partire l'asta
                        if (squadraG1.Length == 0 && squadraG2.Length == 0) StartAsta(ref nomiAllenatori); //se la squadra == 0, parte l'asta
                        else if (squadraG1.Length != 11 && squadraG2.Length != 11) //se la squadra == 0, pulisco i file.txt
                        {
                            Console.WriteLine("Ops, la/e squadra/e risultano incomplete");

                            Directory.Delete(mainPath + "\\Squadre", true); //cancello la cartella "Squadre"
                            File.Delete(mainPath + $"\\Squadre\\{nomiAllenatori[0]}Punti.txt");
                            File.Delete(mainPath + $"\\Squadre\\{nomiAllenatori[1]}Punti.txt");

                            DirectoryInfo creaCartella = Directory.CreateDirectory(mainPath + "\\Squadre"); //creo la cartella "Squadre"
                            using (StreamWriter a = File.CreateText($"{mainPath}\\Squadre\\{nomiAllenatori[0]}.txt")) { } //creo un file.txt all'interno della cartella "Squadre", che porta il nome del G1
                            using (StreamWriter a = File.CreateText($"{mainPath}\\Squadre\\{nomiAllenatori[1]}.txt")) { } //creo un file.txt all'interno della cartella "Squadre", che porta il nome del G2
                            using (StreamWriter a = File.CreateText($"{mainPath}\\{nomiAllenatori[0]}_Punti.txt")) { } //creo un file.txt per i punti di G1
                            using (StreamWriter a = File.CreateText($"{mainPath}\\{nomiAllenatori[1]}_Punti.txt")) { } //creo un file.txt per i punti di G2
                        }
                        else Console.WriteLine("Ops, l'asta è già stata svolta"); //se la squadra ha 11 giocatori
                        break; //torno al menù secondario

                    case 4: //ferma il campionato e proclama un vincitore
                        SetVincitore(); //richiamo la funzione SetVincitore, che, guardando la classifica, proclamerà il vincitore del campionato, facendolo terminare
                        break; //torno al menù secondario

                    default: break; //il "case" "default" si attiva qual'ora il dato inserito non rientrasse in nessun "case" 
                                    //questo non accadrà per merito della funzione SetSceltaInt, ma devo comunque aggiungere il "case" per il corretto funzionamento dello switch
                }  
            }
        }
        
        private static void Menu1() //questa funzione mostra il menù principale
        {
            Console.WriteLine("Benvenut* nel menù principale");
            Console.WriteLine("Elenco menù");
            Console.WriteLine("- 1 per creare una nuova partita");
            Console.WriteLine("- 2 per entrare in una partita esistente");
            Console.WriteLine("- 3 per eliminare la partita esistente");
            Console.WriteLine("- 4 per uscire \n");
            Console.Write("Digita un tasto: ");

            while(SetSceltaInt() == false) //finchè la funzione SetSceltsInt restituisce false, continuo a reiserire il dato
            {
                Console.WriteLine("Ops, comando non valido \n");
                Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                Console.Clear(); //pulisco la console
                Console.WriteLine("Benvenut* nel menù principale");
                Console.WriteLine("Elenco menù");
                Console.WriteLine("- 1 per creare una nuova partita");
                Console.WriteLine("- 2 per entrare in una partita esistente");
                Console.WriteLine("- 3 per eliminare la partita esistente");
                Console.WriteLine("- 4 per uscire \n");
                Console.Write("Digita un tasto: ");
            }
        }
        
        private static void Menu2() //questa funzione mostra il menù secondario
        {
            Console.WriteLine("Benvenut* nel menù secondario");
            Console.WriteLine("Elenco menù");
            Console.WriteLine("- 1 per entrare in una giornata");
            Console.WriteLine("- 2 per mostrare la classifica");
            Console.WriteLine("- 3 per accedere all'asta");
            Console.WriteLine("- 4 per vedere il vincitore \n");
            Console.Write("Digita un tasto: ");

            while(SetSceltaInt() == false) //finchè la funzione SetSceltsInt restituisce false, continuo a reiserire il dato
            {
                Console.WriteLine("Ops, comando non valido \n");
                Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                Console.Clear(); //pulisco la console
                Console.WriteLine("Benvenut* nel menù secondario");
                Console.WriteLine("Elenco menù");
                Console.WriteLine("- 1 per entrare in una giornata");
                Console.WriteLine("- 2 per mostrare la classifica");
                Console.WriteLine("- 3 per accedere all'asta");
                Console.WriteLine("- 4 per vedere il vincitore \n");
                Console.Write("Digita un tasto: ");
            }
        }
        
        public static bool SetSceltaInt() //questa funzione gestisce l'input delle scelte di tipo int, mediante l'utilizzo di un try-catch
        {
            try //questa parte gestisce l'input del dato e ritorna i casi di dato corretto
            {
                sceltaInt = int.Parse(Console.ReadLine()); //input della variabile sceltaInt, mediante un int.Parse

                switch (sceltaInt)
                { //creo uno switch-case per i vari sotto-menù
                    case 1: return true; //se sceltaInt = 1, il dato è corretto e ritorno true
                    case 2: return true; //se sceltaInt = 2, il dato è corretto e ritorno true
                    case 3: return true; //se sceltaInt = 3, il dato è corretto e ritorno true
                    case 4: return true; //se sceltaInt = 4, il dato è corretto e ritorno true
                    default: return false; //se sceltaInt != 1/2/3/4, il dato non è corretto e ritorno false
                }
            }
            catch //questa parte ritorna i casi di dato non corretto
            {
                return false; //il dato non è corretto, quindi ritorno false
            }
        }

        public static bool SetSceltaStr() //questa funzione gestisce l'input delle scelte di tipo string, mediante l'utilizzo di un try-catch
        {
            try //questa parte gestisce l'input del dato e ritorna i casi di dato corretto
            {
                sceltaStr = Console.ReadLine(); //input della variabile sceltaStr, mediante un Convert.ToString

                switch (sceltaStr)
                { //creo uno switch-case per i vari sotto-menù
                    case "y": return true; //se sceltaStr = y, il dato è corretto e ritorno true
                    case "n": return true; //se sceltaStr = n, il dato è corretto e ritorno true
                    default: return false; //se sceltaStr != y/n, il dato non è corretto e ritorno false
                }
            }
            catch //questa parte ritorna i casi di dato non corretto
            {
                return false; //il dato non è corretto, quindi ritorno false
            }
        }

        public static bool SetFantaMedia() //questa funzione gestisce l'input delle fantamedie, mediante l'utilizzo di un try-catch
        {
            try //questa parte gestisce l'input del dato e ritorna i casi di dato corretto
            {
                fantaMedia = int.Parse(Console.ReadLine()); //input della variabile sceltaInt, mediante un int.Parse

                switch (fantaMedia)
                { //creo uno switch-case per i vari sotto-menù
                    case 3: return true; //se fantaMedia = 3, il dato è corretto e ritorno true
                    case 4: return true; //se fantaMedia = 4, il dato è corretto e ritorno true
                    case 5: return true; //se fantaMedia = 5, il dato è corretto e ritorno true
                    case 6: return true; //se fantaMedia = 6, il dato è corretto e ritorno true
                    case 7: return true; //se fantaMedia = 7, il dato è corretto e ritorno true
                    case 8: return true; //se fantaMedia = 8, il dato è corretto e ritorno true
                    case 9: return true; //se fantaMedia = 9, il dato è corretto e ritorno true
                    case 10: return true; //se fantaMedia = 410, il dato è corretto e ritorno true
                    default: return false; //se fantaMedia != 1/2/3/4/5/6/7/8/9/10, il dato non è corretto e ritorno false
                }
            }
            catch //questa parte ritorna i casi di dato non corretto
            {
                return false; //il dato non è corretto, quindi ritorno false
            }
        }
        
        public static string SetAllenatore() //questa funzione setta il nome dei due giocatori e crea un file.txt nella cartella "Squadre"
        {
            if (tmp1 == 0) //essendo tmp1 inizializzato a 0, utilizzo questa condizione come "prima volta" che runno questa funzione
            {
                G1 = Console.ReadLine(); //input della variabile G1
                using (StreamWriter a = File.CreateText($"{mainPath}\\Squadre\\{G1}.txt")) { } //creo un file.txt all'interno della cartella "Squadre", che porta il nome del G1
                tmp1 = 1; //incremento tmp1, passando così nell'else sottostante
                return G1; //ritorno il nome del G1
            }
            else //utilizzo questa condizione come "seconda volta" che runno questa funzione
            {
                G2 = Console.ReadLine(); //input della variabile G2
                using (StreamWriter a = File.CreateText($"{mainPath}\\Squadre\\{G2}.txt")) { } //creo un file.txt all'interno della cartella "Squadre", che porta il nome del G2
                tmp1 = 0; //decremento tmp1, passando così nell'if soprastante (solo in caso di eliminazione e reiserimento totale dei dati)
                return G2; //ritorno il nome del G2
            }
        }
        
        public static string[] GetAllenatore(string[] nomiAllenatori) //questa funzione ottiene i nomi dei 2 giocatori e li salva in un array
        {
            nomiAllenatori = Directory.GetFileSystemEntries(mainPath + "\\Squadre"); //salvo il percorso dei due file.txt nell'array

            for (int i = 0; i < nomiAllenatori.Length; i++) //eseguo questo ciclo per ogni posizione dell'array (ovvero per ogni giocatore")
            {
                string[] str1 = nomiAllenatori[i].Split("Squadre\\"); //tramite la funzione Array[].Splite, rimuovo dal percorso dei 2 file la parte inerente alla cartella dove è salvato il file
                string[] str2 = str1[1].Split(".txt"); //tramite la funzione Array[].Splite, rimuovo dal percorso dei 2 file la parte inerente all'estensione del file
                nomiAllenatori[i] = str2[0]; //salvo la stringa così ottenuta (ovvero i due nomi dei giocatori) nell'array di salvataggio
            }
            return nomiAllenatori; //ritorno l'array
        }
 
        public static void StartAsta(ref string[] nomiAllenatori) //questa funzione gestisce l'asta per l'acquisto dei calciatori
        {
            Calciatore c = new Calciatore(); //creo un istanza della classe nel main
            Console.WriteLine("Ok, inizia l'asta");
            Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
            Console.Clear(); //pulisco la console

            tmp = 1; //inizializzo la variabile tmp a 1, che fungerà da contatore per il numero di giocatori
            Array.Resize(ref squadraG1, 11); //resizo l'array di G1

            for (int i = 0; i < squadraG1.Length; i++) //questo ciclo for si 11 volte
            {
                Console.WriteLine("{0} è il tuo turno", nomiAllenatori[0]); //informo l'utente sul turno corrente

                Console.Write("Inserisci il nome del {0}o calciatore che vuoi acquistare: ", tmp);
                squadraG1[i] += c.SetNome() + ","; //inserisco il nome del calciatore in un array in pos [i] e ci aggiungo una virgola

                Console.Write("Inserisci il ruolo del {0}o calciatore che vuoi acquistare: ", tmp);
                squadraG1[i] += c.SetRuolo() + ","; //inserisco il ruolo del calciatore in un array in pos [i] e ci aggiungo una virgola

                Console.Write("Inserisci la squadra del {0}o calciatore che vuoi acquistare: ", tmp);
                squadraG1[i] += c.SetSquadra(); //inserisco la squadra del calciatore in un array in pos [i]
                
                Console.Write("Calciatore acquistato: {0}, confermare? y/n: ", squadraG1[i]); //mostro il calciatore da acquistare
                
                while (SetSceltaStr() == false) //finchè la funzione SetSceltsStr restituisce false, continuo a reiserire il dato
                {
                    Console.WriteLine("Ops, comando non valido \n");
                    Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                    Console.Clear(); //pulisco la console
                    Console.WriteLine("Calciatore acquistato: {0}, confermare? y/n: ", squadraG1[i]); //mostro il calciatore da acquistare
                }

                if (sceltaStr == "y") //se sceltaStr == "y"
                {
                    Console.Write("Calciatore acquistato: {0}", squadraG1[i]); //mostro il calciatore acquistato
                    File.AppendAllText(mainPath + $"\\Squadre\\{nomiAllenatori[0]}.txt", squadraG1[i]); //scrivo il giocatore in pos [i] nel suo file.txt di G1
                    File.AppendAllText(mainPath + $"\\Squadre\\{nomiAllenatori[0]}.txt", "\n"); //vado a capo
                    tmp++; //incremento il contatore
                }
                else //se sceltaStr == "n"
                {
                    squadraG1[i] = ""; //pulisco la riga dell'array
                    i--; //decremento i in modo che non aumenti di posizione
                }

                Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                Console.Clear(); //pulisco la console
            }

            tmp = 1; //riporto il contatore a 1

            Array.Resize(ref squadraG2, 11); //resizo l'array di G1

            for (int y = 0; y < squadraG2.Length; y++) //questo ciclo for si 11 volte
            {
                Console.WriteLine("{0} è il tuo turno", nomiAllenatori[1]); //informo l'utente sul turno corrente

                Console.Write("Inserisci il nome del {0}o calciatore che vuoi acquistare: ", tmp);
                squadraG2[y] += c.SetNome() + ","; //inserisco il nome del calciatore in un array in pos [i] e ci aggiungo una virgola

                Console.Write("Inserisci il ruolo del {0}o calciatore che vuoi acquistare: ", tmp);
                squadraG2[y] += c.SetRuolo() + ","; //inserisco il ruolo del calciatore in un array in pos [i] e ci aggiungo una virgola

                Console.Write("Inserisci la squadra del {0}o calciatore che vuoi acquistare: ", tmp);
                squadraG2[y] += c.SetSquadra(); //inserisco la squadra del calciatore in un array in pos [i]

                Console.Write("Calciatore acquistato: {0}, confermare? y/n: ", squadraG2[y]); //mostro il calciatore da acquistare
                
                while (SetSceltaStr() == false) //finchè la funzione SetSceltsStr restituisce false, continuo a reiserire il dato
                {
                    Console.WriteLine("Ops, comando non valido \n");
                    Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                    Console.Clear(); //pulisco la console
                    Console.Write("Calciatore acquistato: {0}, confermare? y/n: ", squadraG2[y]); //mostro il calciatore da acquistare
                }

                if (sceltaStr == "y") //se sceltaStr == "y"
                {
                    Console.Write("Calciatore acquistato: {0}", squadraG2[y]); //mostro il calciatore acquistato
                    File.AppendAllText(mainPath + $"\\Squadre\\{nomiAllenatori[1]}.txt", squadraG2[y]); //scrivo il giocatore in pos [i] nel suo file.txt di G2
                    File.AppendAllText(mainPath + $"\\Squadre\\{nomiAllenatori[1]}.txt", "\n"); //vado a capo
                    tmp++; //incremento il contatore
                }
                else //se sceltaStr == "n"
                {
                    squadraG2[y] = ""; //pulisco la riga dell'array
                    y--; //decremento i in modo che non aumenti di posizione
                }

                Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                Console.Clear(); //pulisco la console
            }

            Console.WriteLine("Ok, asta terminata");
        }

        public static void SetFormazione() //questa funzione mostra/schiera le due formazioni dei giocatori
        { 
            Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
            Console.Clear(); //pulisco la console
            squadraG1 = File.ReadAllLines(mainPath + $"\\Squadre\\{nomiAllenatori[0]}.txt"); //salvo la squadra di G1 in un array, leggendo i calciatori da file
            squadraG2 = File.ReadAllLines(mainPath + $"\\Squadre\\{nomiAllenatori[1]}.txt"); //salvo la squadra di G2 in un array, leggendo i calciatori da file

            Console.WriteLine("Formazione di {0} \n", nomiAllenatori[0]);
            for (int i = 0; i < squadraG1.Length; i++) //questo ciclo for si ripete per 11 volte
                Console.WriteLine(squadraG1[i]); //stampo il calciatore in pos [i] di G1
            
            Console.WriteLine("\n"); //vado a capo
            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadKey(); //chiedo di cliccare un tasto per procedere
            Console.Clear(); //pulisco la console

            Console.WriteLine("Formazione di {0} \n", nomiAllenatori[1]);
            for (int i = 0; i < squadraG2.Length; i++) //questo ciclo for si ripete per 11 volte
                Console.WriteLine(squadraG2[i]); //stampo il calciatore in pos [i] di G2
            
            Console.WriteLine("\n"); //vado a capo
            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadKey(); //chiedo di cliccare un tasto per procedere
            Console.Clear(); //pulisco la console
        }

        public static void SetValutazione() //questa funzione gestisce l'inserimento della valutazione
        {
            Console.Clear(); //pulisco la console

            for (int i = 0; i < squadraG1.Length; i++) //questo ciclo for si ripete per 11 volte
            {
                Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                Console.Clear(); //pulisco la console

                Console.Write("Inserisci la fantamedia di {0}: ", squadraG1[i]); //chiedo la fantamedia del calciatore in pos [i] di G1
                while(SetFantaMedia() == false) //finchè la funzione SetSceltsInt restituisce false, continuo a reiserire il dato
                {
                    Console.WriteLine("Ops, comando non valido \n");
                    Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                    Console.Clear(); //pulisco la console
                    Console.Write("Inserisci la fantamedia di {0}: ", squadraG1[i]); //chiedo la fantamedia del calciatore in pos [i] di G1
                }

                Console.Write("Assegnare la fantamedia {0} al calciatore {1}? y/n: ", fantaMedia, squadraG1[i]); //mostro la fantamedia da assegnare
                while (SetSceltaStr() == false) //finchè la funzione SetSceltsStr restituisce false, continuo a reiserire il dato
                {
                    Console.WriteLine("Ops, comando non valido \n");
                    Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                    Console.Clear(); //pulisco la console
                    Console.Write("Assegnare la fantamedia {0} al calciatore {1}? y/n: ", fantaMedia, squadraG1[i]);
                }
                    
                if (sceltaStr == "y") //se la sceltaStr == "y"
                {
                    Console.WriteLine("Fantamedia {0} assegnata al calciatore {1}", fantaMedia, squadraG1[i]); //mostro la fantamedia
                    puntiG1 += fantaMedia; //sommo i punti 
                }
                else 
                {
                    Console.WriteLine("Fantamedia {0} NON assegnata al calciatore {1}", fantaMedia, squadraG1[i]); //mostro la fantamedia  
                    i--;
                }
            }

            Console.Clear();
            Console.WriteLine("Totale punti di {0}: {1}", nomiAllenatori[0], puntiG1);
            File.AppendAllText(mainPath + $"\\{nomiAllenatori[0]}Punti.txt", puntiG1.ToString()); //scrivo il punteggio di G1 sul file.txt
            Console.WriteLine("\n");

            for (int i = 0; i < squadraG2.Length; i++) //questo ciclo for si ripete per 11 volte
            {
                Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                Console.Clear(); //pulisco la console

                Console.Write("Inserisci la fantamedia di {0}: ", squadraG2[i]); //chiedo la fantamedia del calciatore in pos [i] di G2
                while(SetFantaMedia() == false) //finchè la funzione SetSceltsInt restituisce false, continuo a reiserire il dato
                {
                    Console.WriteLine("Ops, comando non valido \n");
                    Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                    Console.Clear(); //pulisco la console
                    Console.Write("Inserisci la fantamedia di {0}: ", squadraG2[i]); //chiedo la fantamedia del calciatore in pos [i] di G2
                }

                Console.Write("Assegnare la fantamedia {0} al calciatore {1}? y/n: ", fantaMedia, squadraG2[i]); //mostro la fantamedia da assegnare
                while (SetSceltaStr() == false) //finchè la funzione SetSceltsStr restituisce false, continuo a reiserire il dato
                {
                    Console.WriteLine("Ops, comando non valido \n");
                    Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
                    Console.Clear(); //pulisco la console
                    Console.Write("Assegnare la fantamedia {0} al calciatore {1}? y/n: ", fantaMedia, squadraG2[i]);
                }
                    
                if (sceltaStr == "y") //se la sceltaStr == "y"
                {
                    Console.WriteLine("Fantamedia {0} assegnata al calciatore {1}", fantaMedia, squadraG2[i]); //mostro la fantamedia
                    puntiG2 += fantaMedia; //sommo i punti 
                }
                else 
                {
                    Console.WriteLine("Fantamedia {0} NON assegnata al calciatore {1}", fantaMedia, squadraG2[i]); //mostro la fantamedia  
                    i--;
                }
            }

            Console.Clear();
            Console.WriteLine("Totale punti di {0}: {1}", nomiAllenatori[0], puntiG2);
            File.AppendAllText(mainPath + $"\\{nomiAllenatori[1]}Punti.txt", puntiG2.ToString()); //scrivo il punteggio di G2 sul file.txt
        }

        public static void Classifica() //questa funzione gestisce e mostra la classifica
        {
            Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
            Console.Clear(); //pulisco la console
            //GetPunti(); //richiamo la funzione GetPunti, che calcola i punti dei giocatori

            if (puntiG1 > puntiG2) //se G1 ha più punti di G2
            {
                Console.WriteLine("Classifica");
                Console.WriteLine("1a posizione - {0}, con {1} punti", nomiAllenatori[0], puntiG1);
                Console.WriteLine("2a posizione - {0}, con {1} punti", nomiAllenatori[1], puntiG2);
            }
            else if (puntiG1 < puntiG2) //se G2 ha più punti di G1
            {
                Console.WriteLine("1a posizione - {0}, con {1} punti", nomiAllenatori[1], puntiG2);
                Console.WriteLine("2a posizione - {0}, con {1} punti", nomiAllenatori[0], puntiG1);
            }
            else //se G1 e G2 hanno gli stessi punti
            {
                Console.WriteLine("1a posizione - {0}, con {1} punti", nomiAllenatori[0], puntiG1);
                Console.WriteLine("1a posizione - {0}, con {1} punti", nomiAllenatori[1], puntiG2);
            }
        }

        public static void SetVincitore() //questa funzione termina il campionato e ne determina il vincitore
        {
            Thread.Sleep(2500); //rallento il thread, rallentando così anche il "clear" della console, dando la possibilità all'utente di leggere
            Console.Clear(); //pulisco la console
            //GetPunti(); //richiamo la funzione GetPunti, che calcola i punti dei giocatori

            if (puntiG1 > puntiG2) //se G1 ha più punti di G2
            {
                Console.WriteLine("{0} ha vinto, congratulazioni", nomiAllenatori[0]);
            }
            else if (puntiG1 < puntiG2) //se G2 ha più punti di G1
            {
                Console.WriteLine("{0} ha vinto, congratulazioni", nomiAllenatori[1]);
            }
            else //se G1 e G2 hanno gli stessi punti
            {
                Console.WriteLine("Nessuno ha vinto, congratulazioni");
            }

            //Directory.Delete(mainPath + "\\Squadre", true); //cancello la cartella "Squadre" per terminare il campionato
        }

        /*public static void GetPunti() //questa funzione calcola i punti dei giocatori
        {
            //arrayPuntiG1 = File.ReadAllLines(mainPath + $"\\{nomiAllenatori[0]}_Punti.txt"); //creo un array con tutti i punti di G1
            //arrayPuntiG2 = File.ReadAllLines(mainPath + $"\\{nomiAllenatori[1]}_Punti.txt"); //creo un array con tutti i punti di G2 
            
            for (int i = 0; i < arrayPuntiG1.Length; i++)
            {
                puntiG1 += arrayPuntiG1[i];
            }

            for (int i = 0; i < arrayPuntiG2.Length; i++)
            {
                puntiG2 += arrayPuntiG2[i];
            }
        }*/
    }
}

