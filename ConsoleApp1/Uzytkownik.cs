using System.IO.Compression;

namespace ConsoleApp1;

public class Uzytkownik
{
    private int id;
    private string imie;
    private string nazwisko;
    private TypUzytkownika typUzytkownika;

    public Uzytkownik(String ImieUzytkownika,String NazwiskoUzytkownika,TypUzytkownika TypUzytkownika)
    {
        imie = ImieUzytkownika;
        nazwisko = NazwiskoUzytkownika;
        typUzytkownika = TypUzytkownika;
    }

    public string Imie
    {
        get
        {
            return imie;
        }
    }

    public string Nazwisko
    {
        get
        {
            return nazwisko;
        }
    }

    public TypUzytkownika TypUzytkownika
    {
        get
        {
            return typUzytkownika;
        }
    }
}