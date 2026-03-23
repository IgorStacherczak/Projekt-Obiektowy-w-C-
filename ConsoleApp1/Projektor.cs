namespace ConsoleApp1;

public class Projektor : Sprzet
{
    private int jasnosc;
    private String rozdzielczosc;
    
    public Projektor(String nazwa,int jasnosc,String rozdzielczosc) : base(nazwa){
        this.jasnosc =  jasnosc;
        this.rozdzielczosc = rozdzielczosc;
    }
}