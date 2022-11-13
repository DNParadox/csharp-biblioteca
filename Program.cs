﻿
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
        case 1:
            Biblioteca.ControlloDocumenti();
            break;
        case 2:
            Biblioteca.PrendiTuttiDocumenti();
            break;
        case 3:
            Biblioteca.OttieniPrestito();
            break;
        case 4:
            loop = false;
            break;
        default:
            Console.WriteLine("Non è stata selezionata un opzione valida");
            break;
    }
}
