using System.Runtime.InteropServices.JavaScript;

namespace ConsoleApp1;
using System.Collections.Generic;

public class SerwisWypozyczalni
{
    private List<Sprzet> listasprzetu = new List<Sprzet>();
    private List<Uzytkownik> listaUzytkownikow = new List<Uzytkownik>();
    private List<Wypozyczenie> listaWypozyczen = new List<Wypozyczenie>();

    public void WypozyczSprzet(Uzytkownik uzytkownik, Sprzet sprzet)
    {
        if (uzytkownik == null)
        {
            Console.WriteLine("Brak użytkownika.");
            return;
        }

        int liczbaAktywnychWypozyczen = 0;

        for (int i = 0; i < listaWypozyczen.Count; i++)
        {
            if (listaWypozyczen[i].Uzytkownik == uzytkownik &&
                listaWypozyczen[i].DataFaktycznegoZwrotu == null)
            {
                liczbaAktywnychWypozyczen++;
            }
        }

        if (uzytkownik.TypUzytkownika == TypUzytkownika.Student && liczbaAktywnychWypozyczen >= 2)
        {
            Console.WriteLine("Student może mieć maksymalnie 2 aktywne wypożyczenia.");
            return;
        }

        if (uzytkownik.TypUzytkownika == TypUzytkownika.Pracownik && liczbaAktywnychWypozyczen >= 5)
        {
            Console.WriteLine("Pracownik może mieć maksymalnie 5 aktywnych wypożyczeń.");
            return;
        }

        if (sprzet == null)
        {
            Console.WriteLine("Brak sprzętu.");
            return;
        }

        if (sprzet.StatusSprzetu != Status.Dostepny)
        {
            Console.WriteLine("Sprzęt jest niedostępny.");
            return;
        }

        Wypozyczenie wypozyczenie = new Wypozyczenie(uzytkownik, sprzet, DateTime.Today, DateTime.Today.AddDays(7));
        listaWypozyczen.Add(wypozyczenie);
        sprzet.ZmienStatus(Status.Wypozyczony);
    }

    public List<Sprzet> ListaSprzetu
    {
        get
        {
            return listasprzetu;
        }
    }
    
    public List<Wypozyczenie> ListaWypozyczen
    {
        get
        {
            return listaWypozyczen;
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
                
                if (kara > 0)
                {
                    Console.WriteLine("Kara za spóźnienie: " + kara + " zł");
                }
                else
                {
                    Console.WriteLine("Brak kary");
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
                Console.WriteLine("Nazwa Osoby: " + listaWypozyczen[i].Uzytkownik.Imie + " " + listaWypozyczen[i].Uzytkownik.Nazwisko +
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
        
        bool znaleziono = false;
        
        for (int i = 0; i < listasprzetu.Count; i++)
        {
            if (listasprzetu[i].StatusSprzetu == Status.Dostepny)
            {
                Console.WriteLine("Nazwa: " + listasprzetu[i].NazwaSprzetu + " ID: " + listasprzetu[i].ID + " Status: " + listasprzetu[i].StatusSprzetu);
                znaleziono = true;
            }
        }

        if (listasprzetu.Count == 0 || znaleziono == false)
        {
            Console.WriteLine("Brak dostępnego sprzętu");
        }
    }

    public void WyswietlWszystkieSprzety()
    {
        for (int i = 0; i < listasprzetu.Count; i++)
        {
            Console.WriteLine("Nazwa: " + listasprzetu[i].NazwaSprzetu + " ID: " + listasprzetu[i].ID + " Status: " + listasprzetu[i].StatusSprzetu);
        }
    }
    
    public void WysietlPrzeterminowane()
    {
        
        bool brak = true;
        
        for (int i = 0; i < listaWypozyczen.Count; i++)
        {
            if (listaWypozyczen[i].DataZwrotu < DateTime.Today && listaWypozyczen[i].DataFaktycznegoZwrotu == null)
            {
                Console.WriteLine("Sprzęt: " + listaWypozyczen[i].Sprzet.NazwaSprzetu + 
                                  " Imię: " + listaWypozyczen[i].Uzytkownik.Imie + 
                                  " Nazwisko: " + listaWypozyczen[i].Uzytkownik.Nazwisko + 
                                  " Data Zwrotu: " + listaWypozyczen[i].DataZwrotu);
                brak = false;
            }
        }

        if (brak)
        {
            Console.WriteLine("Brak Przeterminowanych");
        }
    }
    
    public void WyswietlAktywneWypozyczeniaUzytkownika(Uzytkownik uzytkownik)
    {
        bool brak = true;

        for (int i = 0; i < listaWypozyczen.Count; i++)
        {
            if (listaWypozyczen[i].Uzytkownik == uzytkownik &&
                listaWypozyczen[i].DataFaktycznegoZwrotu == null)
            {
                Console.WriteLine("Sprzęt: " + listaWypozyczen[i].Sprzet.NazwaSprzetu +
                                  " ID: " + listaWypozyczen[i].Sprzet.ID +
                                  " Data wypożyczenia: " + listaWypozyczen[i].DataWypozyczenia.ToShortDateString() +
                                  " Data zwrotu: " + listaWypozyczen[i].DataZwrotu.ToShortDateString());
                brak = false;
            }
        }

        if (brak)
        {
            Console.WriteLine("Brak aktywnych wypożyczeń tego użytkownika");
        }
    }
    
    public void DodajWypozyczenie(Wypozyczenie wypozyczenie)
    {
        if (wypozyczenie != null)
        {
            listaWypozyczen.Add(wypozyczenie);
        }
    }
}