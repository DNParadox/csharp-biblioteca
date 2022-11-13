
//Richiesta:
//Si vuole progettare un sistema per la gestione di una biblioteca. Gli utenti si possono registrare al sistema, fornendo:
//cognome,
//nome,
//email,
//password,
//recapito telefonico,
//Gli utenti registrati possono effettuare dei prestiti sui documenti che sono di vario tipo (libri, DVD). I documenti sono caratterizzati da:
//un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
//titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).
//Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
//L’utente deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, effettuare dei prestiti registrando il periodo 
//(Dal/Al) del prestito e il documento.
//Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un utente.


using System.Numerics;

public class Biblioteca
{
    public List<Documenti> DocumentiList = new List<Documenti>();
    public List<Utenti> UtentiList = new List<Utenti>();
    public List<Prestito> PrestitoList = new List<Prestito>();


    public void RegistraUtenti()
    {
        Console.WriteLine("--- Benvenuto nel portale della Biblioteca ---");
        Console.WriteLine("--- Registrati ---");
        Console.Write("--- Cognome: ");
        string cognome =  Console.ReadLine();
        Console.Write(" --- Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Email : ");
        string email = Console.ReadLine();
        Console.Write("Password : ");
        string password = Console.ReadLine();
        Console.Write("RecapitoTelefonico : ");
        string NumeroTelefono = Console.ReadLine(); 

        Utenti utenti = new Utenti(cognome, nome, email, password, NumeroTelefono);
        UtentiList.Add(utenti);

        Console.WriteLine("Utente Registrato correttamente");
    }

    public void GeneraDocumenti()
    {
        Libri HarryPotter = new Libri("1328053705", "Harry Potter La Pietra Filosofale", 1998, "fantasy,", true, "1C", "Rowlings", 304);
        DocumentiList.Add(HarryPotter);
        Libri PiccoloPrincipe = new Libri("1234567890", "Il Piccolo Principe", 1943, "Racconto", true, "1C", "Antoine de Saint-Exupery", 96);
        DocumentiList.Add(PiccoloPrincipe);

        DVD Logan = new DVD("12345678", "Logan", 2017, "Azione", true, "4F", "James Mangold", 137);
        DocumentiList.Add(Logan);
        DVD Matrix = new DVD("87654321", "The Matrix", 1999, "Azione", true, "4F", "Andy e Larry Wachowski", 136);
        DocumentiList.Add(Matrix);
    }

    public void GeneraUtenti()
    {
        Utenti utente1 = new Utenti("Marra", "Francesco", "m96francesco@gmail.com", "KonamiCode", "393545111");
        UtentiList.Add(utente1);

        Utenti utente2 = new Utenti("Iodice", "Peppe", "m96francesco@gmail.com", "KonamiCode", "393545111");
        UtentiList.Add(utente2);

    }
    public void PrendiTuttiDocumenti()
    {
        foreach (Documenti documento in DocumentiList)
        {
            Console.WriteLine("Titolo : " + documento.Titolo + " - Codice : " + documento.Codice);
        }
        Console.WriteLine();
    }


    public void ControlloDocumenti()
    {
        Console.WriteLine("Inserisci il Titolo oppure il Codice ISBN/Codice Seriale DVD ");
        // Ricerca titolo e codice insieme. Una stringa.
        string titleCodeSearch = Console.ReadLine();

        foreach (Documenti documento in DocumentiList)
        {
            if (documento.Titolo == titleCodeSearch || documento.Codice == titleCodeSearch)
            {
                if (documento.Stato)
                {
                    Console.WriteLine("Titolo: " + documento.Titolo + " - Codice : " + documento.Codice);
                    Console.WriteLine("Sei già un nostro utente? [y/n]");
                    string chose = Console.ReadLine();

                    switch (chose)
                    {
                        case "y":
                            OttieniUtente(documento);
                            break;
                        case "n":
                            RegistraUtenti();
                            Console.Write("Data Inizio Prestito : ");
                            string inizioP = Console.ReadLine();
                            Console.Write("Data Fine Prestito : ");
                            string fineP = Console.ReadLine();
                            Prestito prestito = new Prestito(inizioP, fineP, documento, UtentiList[UtentiList.Count() - 1]);
                            PrestitoList.Add(prestito);
                            documento.Stato = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Il titolo da te richiesto non è al momento disponibile oppure non risulta nel nostro DB");

                }
            }
         
        }
    }
    public void OttieniUtente(Documenti documento)
    {

        Console.Write("Cognome : ");
        string cognome = Console.ReadLine();
        Console.Write("Nome : ");
        string nome = Console.ReadLine();

        foreach (Utenti utente in UtentiList)
        {
            if (nome == utente.Nome && cognome == utente.Cognome)
            {
                Console.Write("Data Inizio : ");
                string inizioP = Console.ReadLine();
                Console.Write("Data Fine : ");
                string fineP = Console.ReadLine();
                Prestito prestito = new Prestito(inizioP, fineP, documento, utente);
                PrestitoList.Add(prestito);
                documento.Stato = false;
            }
        }
    }

    public void OttieniPrestito()
    {
        Console.Write("Cognome : ");
        string cognome = Console.ReadLine();
        Console.Write("Nome : ");
        string nome = Console.ReadLine();

        foreach (Prestito prestito in PrestitoList)
        {
            if (nome == prestito.UtenteSelezionato.Nome && cognome == prestito.UtenteSelezionato.Cognome)
            {
                Console.WriteLine(prestito.UtenteSelezionato.Cognome + " " + prestito.UtenteSelezionato.Nome + " ha preso in prestito " + prestito.DocumentoDaPrestare.Titolo);
            }
        }
    }
}
