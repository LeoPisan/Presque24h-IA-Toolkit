namespace Interface_communication.Messages;

/// <summary>
/// Une instance de message générique
/// </summary>
public class MessageGenerique
{
    private readonly string verbeMessage;
    
    /// <summary>
    /// Instancie un message générique
    /// </summary>
    /// <param name="verbeMessage">Ordre envoyé au serveur</param>
    public MessageGenerique(string verbeMessage)
    {
        this.verbeMessage = verbeMessage;
    }
    
    /// <summary>
    /// Le "verbe" du message, soit l'ordre envoyé au serveur
    /// </summary>
    public string VerbeMessage => verbeMessage;
}