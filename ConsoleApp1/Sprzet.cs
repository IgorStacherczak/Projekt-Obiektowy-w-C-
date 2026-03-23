namespace ConsoleApp1;

public class Sprzet
{
    private int id;
    private String nazwa = "";
    private Status status;

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
}