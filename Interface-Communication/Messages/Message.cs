
using Interface_communication;
using Interface_communication.Exceptions;

namespace Interface_Communication.Messages;

/// <summary>
/// Représente un ordre donné par l'IA
/// </summary>
public class Message
{
    private readonly string commande;
    private readonly List<string> arguments;

    /// <summary>
    /// Instancie un message pouvant être envoyé au serveur
    /// </summary>
    /// <param name="commande">Ordre principal à envoyer au serveur (usage de constantes recommandé)</param>
    /// <param name="arguments">Arguments du message, optionnels</param>
    public Message(string commande = "", string[]? arguments = null)
    {
        this.commande = commande;
        if (arguments != null)
            this.arguments = [..arguments]; // On initialise l'attribut à partir des éléments du tableau fournit 
        else this.arguments = [];
    }

    private string PrintableArguments => string.Join(ConfigCommunication.DelimiteurArguments, arguments);

    public string Commande => commande;
    public List<string> Arguments => arguments;
    
    /// <summary>
    /// Message formaté et prêt à être envoyé au serveur
    /// </summary>
    public string MessageServeur
    {
        get
        {
            if (arguments.Count > 0 && !string.IsNullOrWhiteSpace(commande))
                return $"{commande}{ConfigCommunication.DelimiteurArguments}{PrintableArguments}";
            if (!string.IsNullOrWhiteSpace(commande))
                return commande;
            if (arguments.Count > 0)
                return PrintableArguments;
            
            // On ne peut pas générer le message car il n'y a aucun argument ni commande
            throw new MessageVideException();
        }
    }

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