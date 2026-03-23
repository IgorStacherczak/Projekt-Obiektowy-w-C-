namespace ConsoleApp1;
using System.Collections.Generic;

public class SerwisWypozyczalni
{
    private List<Sprzet> listasprzetu = new List<Sprzet>();
    private List<Uzytkownik> listaUzytkownikow = new List<Uzytkownik>();
    private List<Wypozyczenie> listaWypozyczen = new List<Wypozyczenie>();

    public void WypozyczSprzet(Uzytkownik uzytkownik,Sprzet sprzet)
    {
        if (uzytkownik != null)
        {
            
            int liczbaAktywnychWypozyczen = 0;
            bool czyMoze = false;

            for (int i = 0; i < listaWypozyczen.Count; i++)
            {
                if (listaWypozyczen[i].Uzytkownik == uzytkownik  && listaWypozyczen[i].DataFaktycznegoZwrotu == null)
                {
                    liczbaAktywnychWypozyczen++;
                }
            }

            if (liczbaAktywnychWypozyczen < 2 && uzytkownik.TypUzytkownika == TypUzytkownika.Student)
            {
                czyMoze = true;
            }else if (liczbaAktywnychWypozyczen < 5 && uzytkownik.TypUzytkownika == TypUzytkownika.Pracownik)
            {
                czyMoze = true;
            }
            
            if (sprzet != null && sprzet.StatusSprzetu == Status.Dostepny && czyMoze == true)
            {
                Wypozyczenie wypozyczenie = new Wypozyczenie(uzytkownik, sprzet, DateTime.Today, DateTime.Today.AddDays(7));
                listaWypozyczen.Add(wypozyczenie);
                sprzet.ZmienStatus(Status.Wypozyczony);
            }
        }
    }
}