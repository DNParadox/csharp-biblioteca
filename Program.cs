using System.Runtime.ConstrainedExecution;

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

List<Documenti> Documenti = new List<Documenti>();




public class Utente
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Telefono { get; set; }

}

public class Documenti
{
    public string Codice { get; set; }
    public string Titolo { get; set; }
    public string Anno { get; set; }
    public string Settore { get; set; }
    public bool Stato { get; set; }
    public string Scaffale { get; set; }
    public string Autore { get; set; }

    public Documenti(string codice)
    {
        Codice = codice;
    }

    public override string ToString()
    {
        return "DOC" + Codice;
    }

}


public class DVD : Documenti
{
    public string Durata { get; set; }
    public DVD(string Titolo) : base(Titolo)
    {
        string[] titolo = { "Matrix", "Arma letale","Logan"};
    }
    public DVD(string codice) : base(codice)
    {
    }
    public override string ToString()
    {
        return "DVD" + Codice;
    }

}

public class Libri : Documenti
{
    public string NumeroPagine { get; set; }
    public Libri(string codice) : base(codice)
    {
    }
    public override string ToString()
    {
        return "Libri" + Codice;
    }
}

