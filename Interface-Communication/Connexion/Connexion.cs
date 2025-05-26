using System.Net.Sockets;
using Interface_communication;
using Outils_Developpement.Logging;

namespace Interface_Communication.Connexion;

/// <summary>
/// Permet d'établir la connexion avec le serveur et d'échanger des messages avec lui 
/// </summary>
public class Connexion
{
    #region Attributs
    private TcpClient? client;
    private StreamReader fluxEntrant;
    private StreamWriter fluxSortant;
    #endregion

    #region Méthodes

    /// <summary>
    /// Instancie la connexion
    /// </summary>
    public Connexion()
    {
        CreationFlux();
    }
    
    private void ConnexionServeur()
    {
        client = new TcpClient(ConfigCommunication.HostnameServeur, ConfigCommunication.PortServeur);
    }

    /// <summary>
    /// Initialise les flux de communication avec le serveur en créant des objets
    /// StreamReader et StreamWriter associés au client connecté.
    /// </summary>
    private void CreationFlux()
    {
        if (client == null)
            ConnexionServeur();
        fluxEntrant = new StreamReader(client.GetStream());
        fluxSortant = new StreamWriter(client.GetStream());
        fluxSortant.AutoFlush = true;
    }

    /// <summary>
    /// Réceptionne le dernier message envoyé par le serveur
    /// </summary>
    /// <returns>Le message</returns>
    public string RecevoirMessage()
    {
        var message = fluxEntrant.ReadLine();
        message ??= "";
        Logger.Log(NiveauxLog.Action, $"<-- Message reçu : {message}");
        return message;
    }

    public void EnvoyerMessage(string message)
    {
        fluxSortant.WriteLine(message);
        Logger.Log(NiveauxLog.Action, $"--> Message envoyé : {message}");
    }

    public void Stop()
    {
        client?.Close();
    }
    #endregion

}