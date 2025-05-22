namespace Interface_communication.Utils;

/// <summary>
/// Permet de stocker et d'accéder tous les éléments de configuration liés au toolkit
/// </summary>
public static class Config
{
    #region Attributs

    private static string argumentDelimiter = "|";
    private static string hostnameServeur = "127.0.0.1";
    private static int portServeur = 1234;
    private static int nombrePhaseTour = 1;
    private static string messageErreurServeur = "ERREUR";
    private static string messageFinPartie = "FIN";
    private static string messageDebutTour = "DEBUT_TOUR";
    
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


    #region Mécaniques du jeu
    
    /// <summary>
    /// Nombre de phases dans un tour de jeu
    /// </summary>
    public static int NombrePhaseTour
    {
        get => nombrePhaseTour;
        set => nombrePhaseTour = value;
    }
    
    #endregion

    #region Messages serveur
    
    /// <summary>
    /// Caractère ou chaîne de caractère séparant les arguments dans les messages envoyés au serveur, par défaut il s'agit d'un espace
    /// </summary>
    public static string ArgumentsDelimiter
    {
        get => argumentDelimiter;
        set => argumentDelimiter = value;
    }

    /// <summary>
    /// Message envoyé par le serveur lorsqu'une erreur survient
    /// </summary>
    public static string MessageErreurServeur
    {
        get => messageErreurServeur;
        set => messageErreurServeur = value;
    }

    /// <summary>
    /// Message envoyé par le serveur à la fin de la partie
    /// </summary>
    public static string MessageFinPartie
    {
        get => messageFinPartie;
        set => messageFinPartie = value;
    }

    /// <summary>
    /// Message envoyé par le serveur au début d'un tour
    /// </summary>
    public static string MessageDebutTour
    {
        get => messageDebutTour;
        set => messageDebutTour = value;
    }

    #endregion

}