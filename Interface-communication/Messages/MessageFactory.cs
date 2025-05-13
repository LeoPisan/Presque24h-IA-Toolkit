namespace Interface_communication.Messages;

/// <summary>
/// Aide à l'instanciation des messages pour le serveur.
/// </summary>
public static class MessageFactory
{
    /// <summary>
    /// Instancie un message pour le serveur à partir d'un message générique
    /// </summary>
    /// <param name="messageGenerique">Message générique à utiliser</param>
    /// <param name="arguments">Liste d'arguments à utiliser</param>
    /// <returns>Le message prêt à être envoyé</returns>
    public static Message CreateMessage(MessageGenerique messageGenerique, string[] arguments)
    {
        var message = new Message(messageGenerique);
        message.AddArguments(arguments);
        return message;
    }

    /// <summary>
    /// Instancie un message pour le serveur
    /// </summary>
    /// <param name="messageGenerique">Message générique à utiliser pour instancier le message</param>
    /// <returns>Le message prêt à être envoyé</returns>
    public static Message CreateMessage(MessageGenerique messageGenerique)
    {
        return new Message(messageGenerique);
    }
    
    /// <summary>
    /// Instancie un message pour le serveur
    /// </summary>
    /// <param name="verbeMessage">Verbe à utiliser pour le message</param>
    /// <param name="arguments">Arguments à utiliser pour le message</param>
    /// <returns>Le message prêt à être envoyé</returns>
    public static Message CreateMessage(string verbeMessage, string[] arguments)
    {
        return CreateMessage(new MessageGenerique(verbeMessage), arguments);
    }
    
    /// <summary>
    /// Instancie un message pour le serveur
    /// </summary>
    /// <param name="verbeMessage">Verbe à utiliser pour le message</param>
    /// <returns>Le message prêt à être envoyé</returns>
    public static Message CreateMessage(string verbeMessage)
    {
        return new Message(new MessageGenerique(verbeMessage));
    }
}