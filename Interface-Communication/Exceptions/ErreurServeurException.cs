namespace Interface_communication.Exceptions;

/// <summary>
/// Survient lorsque le serveur lève une erreur
/// </summary>
/// <param name="message">Message pour donner plus d'informations sur le contexte de l'erreur</param>
public class ErreurServeurException(string message) : CommunicationException($"Erreur serveur {message}");