namespace EsercitazioneFinale.Models
{
    public class UserLogin: User
    {
        public bool ShowError { get; set; }

        public UserLogin(bool showError)
        {
            ShowError = showError;
        }
    }
}
