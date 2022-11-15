using System.Data.SqlClient;

Biblioteca Biblioteca = new Biblioteca();
Biblioteca.GeneraDocumenti();
Biblioteca.GeneraUtenti();

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";


using (SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione));
{
        try
        {
            connessioneSql.Open();
            string insertQuery = "INSERT INTO documenti (codice,titolo, anno, settore, scaffale, durata, numero_pagine, autore_nome, autore_cognome, stato"
            + "VALUES (@codice, @titolo, @anno, @settore, @scaffale, @durata, @numero_pagine, @autore_nome, @autore_cognome, @stato)";
            
            SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);
            
            insertCommand.Parameters.Add(new SqlCommand("@codice", "codex1234"));
            insertCommand.Parameters.Add(new SqlCommand("@titolo", "Harry Potter La Pietra Filosofale"));
            insertCommand.Parameters.Add(new SqlCommand("@anno", 1998));
            insertCommand.Parameters.Add(new SqlCommand("@settore", "fantasy"));
            insertCommand.Parameters.Add(new SqlCommand("@scaffale", "1C"));
            insertCommand.Parameters.Add(new SqlCommand("@numero_pagine",304));
            insertCommand.Parameters.Add(new SqlCommand("@autore_nome","J.K."));
            insertCommand.Parameters.Add(new SqlCommand("@autore_cognome","Rowlings"));
            insertCommand.Parameters.Add(new SqlCommand("@stato", 0));

            int affectedRows = insertCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
           Console.WriteLine(e.Message);
        }
        finally
        {
            ConnessioneSql.Close();
        }
}

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
