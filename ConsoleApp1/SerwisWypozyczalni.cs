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

    public List<Sprzet> ListaSprzetu
    {
        get
        {
            return listasprzetu;
        }
    }
    
    public List<Uzytkownik> ListaUzytkownikow
    {
        get
        {
            return listaUzytkownikow;
        }
    }

    public void ZwrotSprzetu(Uzytkownik uzytkownik, Sprzet sprzet)
    {

        double kara = 0;
        double liczbaDni = 0;
        
        for (int i = 0; i < listaWypozyczen.Count; i++)
        {
            if (listaWypozyczen[i].Uzytkownik == uzytkownik && listaWypozyczen[i].Sprzet == sprzet && listaWypozyczen[i].DataFaktycznegoZwrotu == null) 
            {
                listaWypozyczen[i].FaktycznyZwrot = DateTime.Today;

                if (DateTime.Today > listaWypozyczen[i].DataZwrotu)
                {
                    liczbaDni = (DateTime.Today - listaWypozyczen[i].DataZwrotu).TotalDays;
                    kara = liczbaDni * 5;

                    listaWypozyczen[i].KwotaKary = kara;
                }
                
                sprzet.ZmienStatus(Status.Dostepny);
                break;
            }
        }
    }

    public void OznaczJakoUszkodzony(Sprzet sprzet)
    {
        if (sprzet != null)
        {
            sprzet.ZmienStatus(Status.Uszkodzony);
        }
    }

    public void WyswietlRaport()
    {
        Console.WriteLine("Sprzęty");

        for (int i = 0; i < listasprzetu.Count; i++)
        {
            Console.WriteLine("Nazwa Sprzętu: " + listasprzetu[i].NazwaSprzetu + " ID: " + listasprzetu[i].ID + " Status: " + listasprzetu[i].StatusSprzetu);
        }
        
        Console.WriteLine("Aktywne Wypożyczenia");

        for (int i = 0; i < listaWypozyczen.Count; i++)
        {
            if (listaWypozyczen[i].DataFaktycznegoZwrotu == null)
            {
                Console.WriteLine("Nazwa Osoby: " + listaWypozyczen[i].Uzytkownik.Imie + listaWypozyczen[i].Uzytkownik.Nazwisko +
                                  " Sprzęt: " + listaWypozyczen[i].Sprzet.NazwaSprzetu + " Sprzęt ID: " + listaWypozyczen[i].Sprzet.ID +
                                  " Data Wypożyczenia: " +  listaWypozyczen[i].DataWypozyczenia.ToShortDateString() + 
                                  " Data Zwrotu: " + listaWypozyczen[i].DataZwrotu.ToShortDateString());
            }
        }
        
        Console.WriteLine("Przeterminowane");

        for (int i = 0; i < listaWypozyczen.Count; i++)
        {
            if (DateTime.Today> listaWypozyczen[i].DataZwrotu && listaWypozyczen[i].DataFaktycznegoZwrotu == null)
            {
                Console.WriteLine("Nazwa Osoby: " + listaWypozyczen[i].Uzytkownik.Imie + listaWypozyczen[i].Uzytkownik.Nazwisko + 
                                  " Sprzęt: " + listaWypozyczen[i].Sprzet.NazwaSprzetu + " Sprzęt ID: " + listaWypozyczen[i].Sprzet.ID +
                                  " Data Wypożyczenia: " + listaWypozyczen[i].DataWypozyczenia.ToShortDateString() +
                                  " Data Zwrotu: " + listaWypozyczen[i].DataZwrotu.ToShortDateString() + 
                                  " Data Faktycznego Zwrotu: " + listaWypozyczen[i].DataFaktycznegoZwrotu);
                
            }
        }
    }

    public void DodajUzytkownika(Uzytkownik uzytkownik)
    {
        if (uzytkownik != null)
        {
            listaUzytkownikow.Add(uzytkownik);
        }
    }

    public void DodajSprzet(Sprzet sprzet)
    {
        if (sprzet != null)
        {
            listasprzetu.Add(sprzet);
        }
    }

    public void WyswietlDostepnySprzet()
    {
        for (int i = 0; i < listasprzetu.Count; i++)
        {
            if (listasprzetu[i].StatusSprzetu == Status.Dostepny)
            {
                Console.WriteLine("Nazwa: " + listasprzetu[i].NazwaSprzetu + " ID: " + listasprzetu[i].ID + " Status: " + listasprzetu[i].StatusSprzetu);
            }else
            {
                Console.WriteLine("Brak dostępnego sprzętu");
            }
        }

        if (listasprzetu.Count == 0)
        {
            Console.WriteLine("Brak dostępnego sprzętu");
        }
    }
}