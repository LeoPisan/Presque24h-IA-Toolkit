using Interface_Communication.Connexion;
using Interface_communication.Exceptions;
using Interface_Communication.Messages;
using Outils_Developpement.Logging;

namespace Interface_communication;

/// <summary>
/// Le groom vous met à l'aise et gère toutes vos entrées et sorties avec le serveur
/// </summary>
public class Groom
{
    /// <summary>
    /// Envoie un message au serveur et retourne sa réponse
    /// </summary>
    /// <param name="message"><see cref="Message"/> envoyé au serveur</param>
    /// <returns><see cref="ReponseServeur"/> du serveur</returns>
    /// <exception cref="ErreurServeurException">Peut être levée quand le serveur envoie un message d'erreur en réponse</exception>
    public ReponseServeur EnvoyerMessage(Message message)
    {
        StaticConnexion.EnvoyerMessage(message.MessageServeur);
        var reponse = new ReponseServeur(message, StaticConnexion.RecevoirMessage());
        
        // Si le message est une erreur on considère qu'il ne faut pas continuer
        if (reponse.EstErreur) 
        {
            throw new ErreurServeurException($"détectée par le groom lors de l'envoi du message \"{reponse.MessageJoueur.MessageServeur}\"");
        }
        return reponse;
    }
    
    /// <summary>
    /// Envoie une liste de messages et retourne leurs réponses
    /// </summary>
    /// <param name="messagesList">Messages à envoyer</param>
    /// <returns>Réponses associées aux messages</returns>
    public List<ReponseServeur> EnvoyerListeMessages(List<Message> messagesList)
    {
        // On envoie chaque message et on reçoit le résultat
        return messagesList.Select(EnvoyerMessage).ToList();
    }

}