using Interface_communication.Messages;

namespace Interface_communication.Utils.Observation;

/// <summary>
/// Un observable simple
/// </summary>
public class Observable
{
    private readonly List<IObserver> observers = [];

    /// <summary>
    /// Abonne un observeur à cet observable
    /// </summary>
    /// <param name="observer">Observeur à abonner</param>
    public void Abonner(IObserver observer)
    {
        observers.Add(observer);
    }

    /// <summary>
    /// Envoie un message à tous les observateurs abonnés
    /// </summary>
    /// <param name="message">Message à envoyer aux observateurs</param>
    protected void SendMessage(string message)
    {
        foreach (var observer in observers)
        {
            observer.ReceptionMessage(message, this);
        }
    }

    /// <summary>
    /// Envoie un ordre à tous les observateurs abonnés
    /// </summary>
    /// <param name="message">Ordre à envoyer aux observateurs</param>
    protected void SendOrdre(Message message)
    {
        foreach (var observer in observers)
        {
            observer.ReceptionOrdre(message, this);
        }
    }
}