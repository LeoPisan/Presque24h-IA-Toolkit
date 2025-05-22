namespace Interface_communication;

/// <summary>
/// Classe abstraite représentant une intelligence artificielle pour un jeu.
/// </summary>
public abstract class IntelligenceArtificielle
{
    private Orchestrateur orchestrateur;

    /// <summary>
    /// Constructeur par défaut, doit être obligatoirement appelé par les sous-classes.
    /// </summary>
    protected IntelligenceArtificielle()
    {
        orchestrateur = new Orchestrateur(this);
    }

    /// <summary>
    /// Gère une phase d'un tour
    /// </summary>
    /// <param name="tour">Numéro du tour courant (commence à 1)</param>
    /// <param name="phase">Numéro de la phase courante (commence à 0)</param>
    /// <param name="reponsesServeur">Liste des réponses du serveur depuis la phase précédente</param>
    /// <returns>Prochains ordres à exécuter</returns>
    public abstract List<Message> PhaseTour(int tour, int phase, List<ReponseServeur> reponsesServeur);

    /// <summary>
    /// Protocole de démarrage de la partie (avant que l'enchaînement des tours ne commence)
    /// </summary>
    /// <returns>Liste des instructions à envoyer au serveur lors du démarrage de la partie</returns>
    public virtual List<Message> GetProtocoleDemarragePartie()
    {
        return [new Message("INSCRIRE")];
    }

    /// <summary>
    /// Lance la partie
    /// </summary>
    public void Jouer()
    {
        this.orchestrateur.Jouer();
    }

    /// <summary>
    /// Méthode à appeler pour terminer la partie
    /// </summary>
    protected void FinPartie()
    {
        this.orchestrateur.FinPartie();
    }
}