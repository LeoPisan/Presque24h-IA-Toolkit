using System.Runtime.CompilerServices;

namespace Interface_communication.Utils.Logging;

/// <summary>
/// Un logger simple pour les besoins de l'application
/// </summary>
public static class Logger
{
    #region Attributs
    private static NiveauxLog niveauLog = NiveauxLog.Action;
    private static string? cheminLog;
    private static bool logFichier = false;
    private static bool logConsole = true;
    #endregion
    
    /// <summary>
    /// Définis le niveau de log
    /// </summary>
    public static NiveauxLog NiveauLog
    {
        get => niveauLog;
        set => niveauLog = value;
    }

    /// <summary>
    /// Définis si les logs doivent s'afficher dans la console
    /// </summary>
    public static bool LogConsole
    {
        get => logConsole;
        set => logConsole = value;
    }

    #region Méthodes

    /// <summary>
    /// Active l'écriture des logs dans un fichier
    /// </summary>
    /// <param name="chemin">Chemin du fichier dans lequel écrire</param>
    public static void ActiveLogFichier(string chemin)
    {
        cheminLog = chemin;
        logFichier = true;
    }

    /// <summary>
    /// Désactive l'écriture des logs dans un fichier
    /// </summary>
    public static void DesactiveLogFichier()
    {
        logFichier = false;
    }
    
    public static void Log(NiveauxLog niveauMessage, string message)
    {
        if (niveauMessage >= niveauLog)
        {
            if (logConsole)
                Console.WriteLine($"[{niveauMessage}] {message}");
            if (logFichier)
                File.AppendAllText(cheminLog, $"[{niveauMessage}] {message}\n");
        }
    }
    #endregion
}