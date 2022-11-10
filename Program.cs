
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
Biblioteca Biblioteca = new Biblioteca();
Biblioteca.GeneraDocumenti();
Biblioteca.GeneraUtenti();


bool loop = true;
while (loop)
{
    Console.WriteLine("Scegli un opzione");
    Console.WriteLine("1) Effettua un prestito");
    Console.WriteLine("2) Mostra i documenti");
    Console.WriteLine("3) Cerca Prestiti");
    Console.WriteLine("4) Esci");
    int risposta = Convert.ToInt32(Console.ReadLine());

    switch (risposta)
    {
        //case 1:
        //    Biblioteca.checkDocument();
        //    break;
        case 2:
            Biblioteca.GetTuttiDocumenti();
            break;
        case 4:
            loop = false;
            break;
        default:
            Console.WriteLine("Non è stata selezionata un opzione valida");
            break;
    }
}


public class Biblioteca
{
   


    public List<Documenti> DocumentiList = new List<Documenti>();
    public List<Utenti> UtentiList = new List<Utenti>();


    public void RegistraUtenti()
    {
        Console.WriteLine("--- Benvenuto nel portale della Biblioteca ---");
        Console.WriteLine("--- Registrati ---");
        Console.Write("--- Cognome: ");
        Console.ReadLine();
    }

    public void GeneraDocumenti()
    {
        Libri HarryPotter = new Libri("Konami Code", "Harry Potter La Pietra Filosofale", 1998, "fantasy,", false, "1C", "Rowlings", 304);
        DocumentiList.Add(HarryPotter);
        Libri PiccoloPrincipe = new Libri("Konami Code", "Il Piccolo Principe", 1943, "Racconto", true, "1C", "Antoine de Saint-Exupery", 96);
        DocumentiList.Add(PiccoloPrincipe);

        DVD Logan = new DVD("Konami Code", "Logan", 2017, "Azione", false, "4F", "James Mangold", 137);
        DocumentiList.Add(Logan);
        DVD Matrix = new DVD("Konami Code", "The Matrix", 1999, "Azione", true, "4F", "Andy e Larry Wachowski", 136);
        DocumentiList.Add(Matrix);
    }

    public void GeneraUtenti()
    {
        Utenti utente1 = new Utenti("Marra", "Francesco", "m96francesco@gmail.com", "KonamiCode", 393545111);
        UtentiList.Add(utente1);

        Utenti utente2 = new Utenti("Lista", "Emanuela", "m96francesco@gmail.com", "KonamiCode", 393545111);
        UtentiList.Add(utente2);

    }

    public void GetTuttiDocumenti()
    {
        foreach (Documenti doc in DocumentiList)
        {
            Console.WriteLine("Titolo: " + doc.Titolo + " - Codice : " + doc.Codice);

        }
        Console.WriteLine();
    }

}

public class Utenti
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Telefono { get; set; }

    public Utenti(string cognome, string nome, string email, string password, int telefono)
    {
        Cognome = cognome;
        Nome = nome;
        Email = email;
        Password = password;
        Telefono = telefono;
    }

}

public class Documenti
{
    public string Codice { get; set; }
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }
    public bool Stato { get; set; }
    public string Scaffale { get; set; }
    public string Autore { get; set; }

    public Documenti(string codice, string titolo, int anno, string settore, bool stato, string scaffale, string autore)
    {
        Codice = codice;
        Titolo = titolo;
        Anno = anno;
        Settore = settore;
        Stato = stato;
        Scaffale = scaffale;
        Autore = autore;
    }
}


public class DVD : Documenti
{
    public DVD(string codice, string titolo, int anno, string settore, bool stato, string scaffale, string autore, float durata) : base(codice, titolo, anno, settore, stato, scaffale, autore)
    {
        Durata = durata;
    }

    public float Durata { get; set; }
}

public class Libri : Documenti
{
    public Libri(string codice, string titolo, int anno, string settore, bool stato, string scaffale, string autore, int numeropagine) : base(codice, titolo, anno, settore, stato, scaffale, autore)
    {
        NumeroPagine = numeropagine;
    }

    public int NumeroPagine { get; set; }

}

