using Interface_communication.Utils;

namespace Interface_communication;

/// <summary>
/// Message envoyé par le serveur
/// </summary>
public class MessageServeur : Message
{
    /// <summary>
    /// Indique si le message est une erreur serveur
    /// </summary>
    public bool EstErreur => VerbeMessage.StartsWith(Config.MessageErreurServeur);

    /// <summary>
    /// Indique le "verbe" du message
    /// </summary>
    public new string VerbeMessage => base.VerbeMessage;

    /// <summary>
    /// Arguments du message du serveur
    /// </summary>
    public new string[] Arguments => base.Arguments.ToArray();

    /// <summary>
    /// Instancie un message du serveur
    /// </summary>
    /// <param name="messageBrut">Chaîne de caractère brute envoyée par le serveur</param>
    internal MessageServeur(string messageBrut) : base(GetVerbe(messageBrut), GetArguments(messageBrut)) { }

    /// <summary>
    /// Instancie un message du serveur sans verbe
    /// </summary>
    /// <param name="messageBrut">Message brut envoyé par le serveur</param>
    /// <param name="contientVerbe">Indique si le message contient un verbe</param>
    internal MessageServeur(string messageBrut, bool contientVerbe) : base("Pas de verbe", GetArguments(messageBrut, contientVerbe)) { }

    private static string GetVerbe(string messageBrut)
    {
        return messageBrut.Split(Config.ArgumentsDelimiter)[0];
    }

    private static string[] GetArguments(string messageBrut, bool contientVerbe = true)
    {
        var messageParse = messageBrut.Split(Config.ArgumentsDelimiter);
        int nbSkip = contientVerbe ? 1 : 0;
        return messageParse.Skip(nbSkip).ToArray();
    }

    // On cache les méthodes d'ajout d'arguments : on ne veut pas qu'un message serveur puisse être modifié à posteriori
    private new void AddArgument(string argument)
    {
        base.AddArgument(argument);
    }
    
    private new void AddArguments(string[] newArguments)
    {
        base.AddArguments(newArguments);   
    }
}