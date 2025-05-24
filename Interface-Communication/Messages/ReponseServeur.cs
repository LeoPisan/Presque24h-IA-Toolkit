using Interface_communication;

namespace Interface_Communication.Messages;

/// <summary>
/// Réponse à un message envoyé par le serveur
/// </summary>
public class ReponseServeur
{
    private Message messageJoueur;
    private string reponseServeur;

    /// <summary>
    /// Fournit un tableau de string contenant le message découpé par arguments
    /// </summary>
    public string[] ReponseArgumentsDecoupes => reponseServeur.Split(ConfigCommunication.DelimiteurArguments);

    /// <summary>
    /// Fournit un tableau de tableau de string représentant le message découpé par sous-arguments
    /// </summary>
    public string[][] ReponseSousArgumentsDecoupes =>
        ReponseArgumentsDecoupes
            .Select(arg => arg.Split(ConfigCommunication.DelimiteurSousArguments))
            .ToArray();

    public bool EstErreur => reponseServeur.StartsWith(ConfigCommunication.MessageErreurServeur);
    
    /// <summary>
    /// Instancie une réponse serveur à un message du joueur
    /// </summary>
    /// <param name="messageJoueur">Message à l'origine de la réponse</param>
    /// <param name="reponseBrute">Chaîne brute de la réponse</param>
    public ReponseServeur(Message messageJoueur, string reponseBrute)
    {
        this.messageJoueur = messageJoueur;
        this.reponseServeur = reponseBrute;
    }

    /// <summary>
    /// Message original
    /// </summary>
    public Message MessageJoueur => messageJoueur;
}