using Interface_communication.Utils;

namespace Interface_communication.Messages;

/// <summary>
/// Représente un ordre donné par l'IA
/// </summary>
public class Message
{
    private readonly List<string> arguments;
    private readonly MessageGenerique messageGenerique;

    /// <summary>
    /// Instancie un message
    /// </summary>
    /// <param name="messageGenerique">Message générique sur lequel prendre modèle</param>
    public Message(MessageGenerique messageGenerique)
    {
        this.messageGenerique = messageGenerique;
        arguments = [];
    }

    private string PrintableArguments => string.Join(Config.ArgumentsDelimiter, arguments);
    private string VerbeMessage => messageGenerique.VerbeMessage;
    
    public string MessageServeur => arguments.Count > 0 ? $"{VerbeMessage}{Config.ArgumentsDelimiter}{PrintableArguments}" : VerbeMessage;

    /// <summary>
    /// Ajoute un nouvel argument au message
    /// </summary>
    /// <param name="argument">The argument to be added to the list.</param>
    public void AddArgument(string argument)
    {
        arguments.Add(argument);
    }
    
    /// <summary>
    /// Ajoute une liste d'arguments au message
    /// </summary>
    /// <param name="newArguments">Liste des arguments à ajouter</param>
    public void AddArguments(string[] newArguments)
    {
        this.arguments.AddRange(newArguments);
    }
}