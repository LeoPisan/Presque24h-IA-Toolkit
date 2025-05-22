namespace Interface_Communication.Connexion;

/// <summary>
/// Permet d'échanger des messages avec le serveur sans se préoccuper de l'instance de la connexion
/// </summary>
public static class StaticConnexion
{
    private static Connexion? instance;
    
    /// <summary>
    /// Obtient l'instance unique (singleton) de la classe <see cref="Connexion"/>.
    /// Fournit un point d'entrée unique pour établir la connexion avec le serveur et
    /// échanger des messages via les flux de communication initialisés.
    /// </summary>
    private static Connexion Instance
    {
        get
        {
            instance ??= new Connexion();
            return instance;
        }
    }

    #region Méthodes


    /// <summary>
    /// Réceptionne le dernier message envoyé par le serveur en encapsulant <see cref="Connexion.RecevoirMessage()"/>
    /// </summary>
    /// <returns>Le message</returns>
    public static string RecevoirMessage()
    {
        return Instance.RecevoirMessage();
    }

    /// <summary>
    /// Envoie un message au serveur en encapsulant <see cref="Connexion.EnvoyerMessage(string)"/>
    /// </summary>
    /// <param name="message">Chaîne de caractères à envoyer au serveur</param>
    public static void EnvoyerMessage(string message)
    {
        Instance.EnvoyerMessage(message);
    }

    /// <summary>
    /// Coupe la connexion au serveur en encapsulant <see cref="Connexion.Stop()"/>
    /// </summary>
    public static void Stop()
    {
        Instance.Stop();
    }

    #endregion
}