namespace ConsoleApp1;

public class Laptop : Sprzet
{
    private String procesor;
    private int ram;

    public Laptop(String nazwa,String procesor,int ram) : base(nazwa){
        this.procesor =  procesor;
        this.ram = ram;
    }
}