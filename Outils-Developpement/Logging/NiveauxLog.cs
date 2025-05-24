namespace Outils_Developpement.Logging;

public enum NiveauxLog
{
    /// <summary>
    /// Informations générales concernant le toolkit
    /// </summary>
    InfoToolkit,
    /// <summary>
    /// Informations générales
    /// </summary>
    Info,
    /// <summary>
    /// Actions plus importantes que de simples informations
    /// </summary>
    Action,
    /// <summary>
    /// Erreurs
    /// </summary>
    Erreur,
    /// <summary>
    /// Aucun niveau de log, ne doit pas être utilisé pour signaler un message mais uniquement comme niveau du logger
    /// </summary>
    None
}