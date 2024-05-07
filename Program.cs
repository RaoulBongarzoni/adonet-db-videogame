
namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("benvenuto seleziona Cosa Vuoi fare");

            Console.WriteLine("inserisci videogioco");
            VideogameManager.GetVideogame(12);
            string stringa = "qui";
            VideogameManager.SearchVideogame(
                stringa);

        }
    }
}
