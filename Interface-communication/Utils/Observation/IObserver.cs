using Interface_communication.Messages;

namespace Interface_communication.Utils.Observation;

/// <summary>
/// Un observeur simple
/// </summary>
public interface IObserver
{
    /// <summary>
    /// Reçoit et traite de la façon voulue le message envoyé par un observable
    /// </summary>
    /// <param name="message">Message envoyé par un observable</param>
    /// <param name="emetteur">Emetteur du message</param>
    public void ReceptionMessage(string message, Observable emetteur);

    /// <summary>
    /// Reçoit et traite un ordre envoyé par un observable
    /// </summary>
    /// <param name="message">Ordre envoyé par un observable</param>
    /// <param name="emetteur">Emetteur de l'ordre</param>
    public void ReceptionOrdre(Message message, Observable emetteur);
}