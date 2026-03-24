namespace ConsoleApp1;

abstract public class Sprzet
{
    private int id;
    private static int licznik;
    private String nazwa = "";
    private Status status;

    public Sprzet(String nazwaSprzetu)
    {
        licznik++;
        id = licznik;
        nazwa = nazwaSprzetu;
    }
    
    public String NazwaSprzetu
    {
        get
        {
            return nazwa;
        }
    }

    public Status StatusSprzetu
    {
        get
        {
            return status;
        }
    }

    public void ZmienStatus(Status nowyStatus)
    {
        status = nowyStatus;
    }

    public int ID
    {
        get
        {
            return id;
        }
    }
}