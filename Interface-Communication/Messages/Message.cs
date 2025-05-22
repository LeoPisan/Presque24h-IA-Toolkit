
using Interface_communication;

namespace Interface_Communication.Messages;

/// <summary>
/// Représente un ordre donné par l'IA
/// </summary>
public class Message
{
    private readonly string verbeMessage;
    private readonly List<string> arguments;

    /// <summary>
    /// Instancie un message pouvant être envoyé au serveur
    /// </summary>
    /// <param name="verbeMessage">Ordre principal à envoyer au serveur (usage de constantes recommandé)</param>
    /// <param name="arguments">Arguments du message, optionnels</param>
    /// <param name="reponseContientVerbe">Indique si la réponse attendue (s'il y en a une) doit contenir un verbe ou non, vrai par défaut</param>
    public Message(string verbeMessage = "", string[]? arguments = null)
    {
        this.verbeMessage = verbeMessage;
        if (arguments != null)
            this.arguments = [..arguments]; // On initialise l'attribut à partir des éléments du tableau fournit 
        else this.arguments = [];
    }

    private string PrintableArguments => string.Join(ConfigCommunication.DelimiteurArguments, arguments);

    public string VerbeMessage => verbeMessage;
    public List<string> Arguments => arguments;
    
    /// <summary>
    /// Message formaté et prêt à être envoyé au serveur
    /// </summary>
    public string MessageServeur => arguments.Count > 0 ? $"{verbeMessage}{ConfigCommunication.DelimiteurArguments}{PrintableArguments}" : verbeMessage;

    /// <summary>
    /// Ajoute un nouvel argument au message
    /// </summary>
    /// <param name="argument">L'argument à ajouter à la liste</param>
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