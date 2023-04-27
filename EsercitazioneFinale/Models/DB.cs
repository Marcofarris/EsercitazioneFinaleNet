namespace EsercitazioneFinale.Models
{
    public static class DB
    {
        public static List<User> users = new List<User>()
        {
            new User("Marco", "123"),
            new User("Nicolo", "111"),
            new User("Giorgio", "000")
        };

        public static string Login(string nome, string pwd)
        {
            var utente = users.FirstOrDefault(l => l.UserName == nome);

            if (utente != null && utente.Password == pwd)
            {
                return "1234";
            }
            else return "0";
        }
    }
}
