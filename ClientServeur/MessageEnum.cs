/// <summary>
/// enumerable des messages entre client et serveur
/// </summary>

namespace ClientsServeur
{
    public enum MessageReseau
    {
        init,
        iCopy,
        wait,
        error,
        deconnexion,
        gameReady,
        stop,
        reStart,
        win,
    }
}