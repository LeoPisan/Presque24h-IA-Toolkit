using System.Net.Sockets;
using Interface_communication;
using Outils_Developpement.Logging;

namespace Interface_Communication.Connexion;

/// <summary>
/// Permet d'établir la connexion avec le serveur et d'échanger des messages avec lui 
/// </summary>
public class Connexion : IDisposable
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
    /// <param name="host">L'URI sur laquelle se connecter, par défaut celle indiquée pour <see cref="ConfigCommunication.HostnameServeur"/> dans la configuration</param>
    /// <param name="port">Le port sur lequel se connecter, par défaut celui indiqué pour <see cref="ConfigCommunication.PortServeur"/> dans la configuration</param>
    public Connexion(string? host = null, int? port = null)
    {
        ConnexionServeur(host, port);
        CreationFlux();
    }

    private void ConnexionServeur(string? host, int? port)
    {
        client = new TcpClient(
            host ?? ConfigCommunication.HostnameServeur,
            port ?? ConfigCommunication.PortServeur
        );
        Logger.Log(NiveauxLog.InfoToolkit, $"Connexion effectuée en TCP à l'URI {host}:{port}");
    }

    /// <summary>
    /// Initialise les flux de communication avec le serveur en créant des objets
    /// StreamReader et StreamWriter associés au client connecté.
    /// </summary>
    private void CreationFlux()
    {
        fluxEntrant = new StreamReader(client.GetStream());
        fluxSortant = new StreamWriter(client.GetStream());
        fluxSortant.AutoFlush = true;
    }

    /// <summary>
    /// Réceptionne le dernier message envoyé par le serveur en encapsulant <see cref="StreamReader.ReadLine"/>
    /// </summary>
    /// <returns>Le message</returns>
    public string RecevoirMessage()
    {
        var message = fluxEntrant.ReadLine();
        message ??= "";
        Logger.Log(NiveauxLog.Action, $"<-- Message reçu : {message}");
        return message;
    }

    /// <summary>
    /// Envoie un message au serveur en encapsulant <see cref="StreamWriter.WriteLine(string?)"/>
    /// </summary>
    /// <param name="message">Chaîne de caractères à envoyer</param>
    public void EnvoyerMessage(string message)
    {
        fluxSortant.WriteLine(message);
        Logger.Log(NiveauxLog.Action, $"--> Message envoyé : {message}");
    }

    /// <summary>
    /// Coupe la connexion au serveur
    /// </summary>
    public void Stop()
    {
        client?.Close();
        Logger.Log(NiveauxLog.InfoToolkit, "Connexion avec le serveur coupée");
    }

    #endregion

    /// <summary>
    /// Releases the resources used by the Connexion class.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged and optionally managed resources.
    /// </summary>
    /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Dispose managed resources
            fluxEntrant?.Dispose();
            fluxSortant?.Dispose();
            Stop();
        }
        // No unmanaged resources to release
    }

    ~Connexion()
    {
        Dispose(false);
    }
}