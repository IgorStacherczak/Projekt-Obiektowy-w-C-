using System.IO.Compression;

namespace ConsoleApp1;

public class Uzytkownik
{
    private int id;
    private string imie;
    private string nazwisko;
    private TypUzytkownika typUzytkownika;

    public TypUzytkownika TypUzytkownika
    {
        get
        {
            return typUzytkownika;
        }
    }
}