using Interface_communication.Utils;
using Interface_communication.Utils.Logging;

namespace Interface_communication;

/// <summary>
/// Orchestre les actions de l'IA
/// </summary>
internal class Orchestrateur()
{
    private readonly IntelligenceArtificielle ia;
    private int tourActuel;
    private List<ReponseServeur> dernieresReponsesServeur;
    private bool partieEnCours;

    public Orchestrateur(IntelligenceArtificielle ia) : this()
    {
        this.ia = ia;
        tourActuel = 0;
        dernieresReponsesServeur = [];
        partieEnCours = false;
    }

    /// <summary>
    /// Lance la partie
    /// </summary>
    public void Jouer()
    {
        Logger.Log(NiveauxLog.Info, "Lancement de la partie");
        // Démarrage de la partie suivant le protocole fournit par l'IA
        dernieresReponsesServeur = EnvoyerListeMessages(ia.GetProtocoleDemarragePartie());
        partieEnCours = true;

        MessageServeur dernierMessageServeur;
        while (partieEnCours)
        {
            tourActuel++;
            do // On attend le signal du serveur pour démarrer le tour
            {
                Logger.Log(NiveauxLog.Info, $"Attente du tour {tourActuel}...");
                dernierMessageServeur = AttendreMessageTransitionTour();
            } while (partieEnCours 
                     && dernierMessageServeur.VerbeMessage != Config.MessageDebutTour 
                     && dernierMessageServeur.VerbeMessage != Config.MessageFinPartie); 
            
            if (partieEnCours)
                Tour();
        }
    }

    /// <summary>
    /// Méthode à appeler pour mettre fin à la partie
    /// </summary>
    public void FinPartie()
    {
        Logger.Log(NiveauxLog.Info, "Fin de la partie");
        partieEnCours = false;
        Connexion.Instance.Stop();
    }
    
    /// <summary>
    /// Exécute un tour de jeu
    /// </summary>
    private void Tour()
    {
        Logger.Log(NiveauxLog.Info, $"--- DÉBUT DU TOUR {tourActuel} ---");
        for (int phase = 0; phase < Config.NombrePhaseTour; phase++)
        {
            if (!partieEnCours)
            {
                break; // Très inélégant mais plutôt optimal
            }
            PhaseTour(phase);
        }
        Logger.Log(NiveauxLog.Info, $"--- FIN DU TOUR {tourActuel} ---");
    }

    private void PhaseTour(int phase)
    {
        Logger.Log(NiveauxLog.Info, $">>> Début de la phase {phase}");
        
        List<Message> ordresListe = ia.PhaseTour(tourActuel, phase, dernieresReponsesServeur);
        List<ReponseServeur> reponseServeur = EnvoyerListeMessages(ordresListe);
        this.dernieresReponsesServeur = reponseServeur;
        
        Logger.Log(NiveauxLog.Info, $"<<< Fin de la phase {phase}");
    }

    private ReponseServeur EnvoyerMessage(Message message)
    {
        Connexion.Instance.EnvoyerMessage(message.MessageServeur);
        ReponseServeur reponse;
        if (message.ReponseContientVerbe)
        {
            reponse = new ReponseServeur(message, Connexion.Instance.RecevoirMessage());
        }
        else
        {
            reponse = new ReponseServeur(message, Connexion.Instance.RecevoirMessage(), false);
        }
        if (reponse.EstErreur)
        {
            Logger.Log(NiveauxLog.Erreur, $"Erreur serveur : {reponse}");
            throw new Exception($"Erreur serveur détectée lors de l'envoi du message : {reponse}");
        }
        return reponse;
    }

    private List<ReponseServeur> EnvoyerListeMessages(List<Message> messagesList)
    {
        // On envoie chaque message et on reçoit le résultat
        return messagesList.Select(EnvoyerMessage).ToList();
    }

    private MessageServeur AttendreMessageTransitionTour()
    {
        var message = new MessageServeur(Connexion.Instance.RecevoirMessage());
        if (message.VerbeMessage.Equals(Config.MessageFinPartie))
        {
            FinPartie();
        }
        return message;
    }
}