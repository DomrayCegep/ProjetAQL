using RMQHelperDLL;

namespace RMQHelperDll.MessagesDef
{
    public abstract class MessageBase
    {
        protected RMQEnveloppe? _msgEnveloppe;
        // On peut garder une propriété avec un getter/setter par défaut
        public string MessageName { get; set; }

        // Constructeur optionnel pour forcer le nom dès l'instanciation
        protected MessageBase(string messageName)
        {
            MessageName = messageName;
        }

        // Méthode abstraite : Doit retourner une instance spécifique
        public abstract MessageBase GetMessageInstance(RMQEnveloppe msgEnveloppe);

        // Méthode abstraite : Doit retourner une instance spécifique
        public abstract Task ProcessMessageActions();

        // Méthode virtuelle : On donne une implémentation par défaut, 
        // mais elle peut être réécrite (override) si besoin.
        public virtual string GetMessageText()
        {
            return $"Message: {MessageName}";
        }
    }
}
