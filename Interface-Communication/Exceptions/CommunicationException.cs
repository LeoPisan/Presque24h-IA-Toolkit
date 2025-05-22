using Outils_Developpement.Logging;

namespace Interface_communication.Exceptions;

public abstract class CommunicationException : Exception
{
    protected CommunicationException(string message) : base(GetMessage(message))
    {
        Logger.Log(NiveauxLog.Erreur, GetMessage(message));
    }

    private static string GetMessage(string message)
    {
        return $"Erreur de communication : {message}";
    }
}