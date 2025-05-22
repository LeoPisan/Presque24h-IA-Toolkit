namespace Interface_communication;

/// <summary>
/// Permet de stocker et d'accéder tous les éléments de configuration liés au toolkit
/// </summary>
public static class ConfigCommunication
{
    #region Attributs

    private static string argumentDelimiter = "|";
    private static string hostnameServeur = "127.0.0.1";
    private static int portServeur = 1234;
    
    #endregion


    #region Configuration serveur

    /// <summary>
    /// Hostname du serveur, par défaut "127.0.0.1"
    /// </summary>
    public static string HostnameServeur
    {
        get => hostnameServeur;
        set => hostnameServeur = value;
    }

    /// <summary>
    /// Port du serveur sur lequel les échanges se déroulent
    /// </summary>
    public static int PortServeur
    {
        get => portServeur;
        set => portServeur = value;
    }
    
    #endregion
    
    /// <summary>
    /// Caractère ou chaîne de caractère séparant les arguments dans les messages envoyés au serveur, par défaut il s'agit d'un espace
    /// </summary>
    public static string ArgumentsDelimiter
    {
        get => argumentDelimiter;
        set => argumentDelimiter = value;
    }

}