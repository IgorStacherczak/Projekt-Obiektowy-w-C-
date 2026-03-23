namespace ConsoleApp1;

public class Wypozyczenie
{
    private Uzytkownik uzytkownik;
    private Sprzet sprzet;
    private DateTime dataWypozyczenia;
    private DateTime dataZwrotu;
    private DateTime? dataFaktycznegoZwrotu;
    private double kara;

    public Wypozyczenie(Uzytkownik nazwaUzytkownika, Sprzet nazwaSprzetu, DateTime dataWypozyczeniaSprzetu, DateTime dataZwrotuSprzetu)
    {
        uzytkownik = nazwaUzytkownika; 
        sprzet = nazwaSprzetu;
        dataWypozyczenia = dataWypozyczeniaSprzetu;
        dataZwrotu = dataZwrotuSprzetu;
    }
    
    public Uzytkownik Uzytkownik
    {
        get
        {
            return uzytkownik;
        }
    }
    
    public DateTime? DataFaktycznegoZwrotu
    {
        get
        {
            return dataFaktycznegoZwrotu;
        }
    }

    public Sprzet Sprzet
    {
        get
        {
            return sprzet;
        }
    }

    public DateTime DataZwrotu
    {
        get
        {
            return dataZwrotu;
        }
    }

    public double Kara
    {
        get
        {
            return kara;
        }
    }

    public double KwotaKary
    {
        set
        {
            kara = value;
        }
    }

    public DateTime FaktycznyZwrot
    {
        set
        {
            dataFaktycznegoZwrotu = value;
        }
    }
}