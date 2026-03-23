namespace ConsoleApp1;

public class Kamera : Sprzet
{
    private  String jakosc;
    private int liczbaKlatek;
    
    public Kamera(String nazwa,String jakosc,int liczbaKlatek) : base(nazwa){
        this.jakosc =  jakosc;
        this.liczbaKlatek = liczbaKlatek;
    }
}