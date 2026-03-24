using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        int i = -1;
        String Imie;
        String Nazwisko;
        String wybor;
        TypUzytkownika typUzytkownika;
        SerwisWypozyczalni serwis = new SerwisWypozyczalni();
        
        Uzytkownik u1 = new Uzytkownik("Jan", "Kowalski", TypUzytkownika.Student);
        Uzytkownik u2 = new Uzytkownik("Anna", "Nowak", TypUzytkownika.Pracownik);
        Uzytkownik u3 = new Uzytkownik("Piotr", "Zielinski", TypUzytkownika.Student);

        serwis.DodajUzytkownika(u1);
        serwis.DodajUzytkownika(u2);
        serwis.DodajUzytkownika(u3);
        
        Laptop l1 = new Laptop("Laptop", "i5", 8);
        Laptop l2 = new Laptop("Laptop", "i7", 16);
        Kamera k1 = new Kamera("Kamera", "4K", 60);
        Projektor p1 = new Projektor("Projektor", 4000, "FullHD");

        serwis.DodajSprzet(l1);
        serwis.DodajSprzet(l2);
        serwis.DodajSprzet(k1);
        serwis.DodajSprzet(p1);

        serwis.WypozyczSprzet(u1, l1);
        serwis.WypozyczSprzet(u2, k1);

        Wypozyczenie stare = new Wypozyczenie(u3, p1, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-3));
        serwis.DodajWypozyczenie(stare);
        serwis.ListaSprzetu[3].ZmienStatus(Status.Wypozyczony);
        
        while (i != 0)
        {
            Console.WriteLine("1. Dodaj użytkownika\n" +
                              "2. Dodaj sprzęt\n" +
                              "3. Wypożycz sprzęt\n" +
                              "4. Zwróć sprzęt\n" +
                              "5. Raport\n" +
                              "6. Wyświetl dostępny sprzęt\n" +
                              "7. Wyświetl cały sprzęt\n" +
                              "8. Aktywne wypożyczenia użytkownika\n" +
                              "9. Przeterminowane wypożyczenia\n" +
                              "10. Oznacz sprzęt jako uszkodzony\n" +
                              "0. Wyjście\n");
            Console.Write("Podaj numer akcji: ");
            i = Convert.ToInt32(Console.ReadLine());

            switch (i)
            {
                case 1:
                    Console.WriteLine("Podaj Imię: ");
                    Imie = Console.ReadLine();
                    Console.WriteLine("Podaj Nazwisko: ");
                    Nazwisko = Console.ReadLine();
                    Console.WriteLine("Podaj Typ Uzytkownika: \n1.Student\n2.Pracownik");
                    wybor = Console.ReadLine();
                    
                    if (Convert.ToInt32(wybor) == 1)
                    {
                        typUzytkownika = TypUzytkownika.Student;
                        Uzytkownik uzytkownik = new Uzytkownik(Imie, Nazwisko, typUzytkownika);
                        serwis.DodajUzytkownika(uzytkownik);
                    }else if (Convert.ToInt32(wybor) == 2)
                    {
                        typUzytkownika = TypUzytkownika.Pracownik;
                        Uzytkownik uzytkownik = new Uzytkownik(Imie, Nazwisko,typUzytkownika);
                        serwis.DodajUzytkownika(uzytkownik);
                    }
                    break;
                
                case 2:
                    Console.WriteLine("Podaj Typ Sprzętu: \n1.Laptop\n2.Kamera\n3.Projektor");
                    wybor = Console.ReadLine();
                    if (Convert.ToInt32(wybor) == 1)
                    {
                        Console.WriteLine("Podaj Procesor: ");
                        String procesor = Console.ReadLine();
                        Console.WriteLine("Podaj Ram: ");
                        int ram = Convert.ToInt32(Console.ReadLine());
                        Laptop laptop = new Laptop("Laptop",procesor,ram);
                        serwis.DodajSprzet(laptop);
                    }else if (Convert.ToInt32(wybor) == 2)
                    {
                        Console.WriteLine("Podaj jakosc: ");
                        String jakosc = Console.ReadLine();
                        Console.WriteLine("Podaj Liczbe Klatek: ");
                        int liczbaKlatek = Convert.ToInt32(Console.ReadLine());
                        Kamera kamera = new Kamera("Kamera",jakosc,liczbaKlatek);
                        serwis.DodajSprzet(kamera);
                    }else if (Convert.ToInt32(wybor) == 3)
                    {
                        Console.WriteLine("Podaj Rozdzielczosc: ");
                        String rozdzielczosc = Console.ReadLine();
                        Console.WriteLine("Podaj jasnosc liczbę: ");
                        int jasnosc = Convert.ToInt32(Console.ReadLine());
                        Projektor projektor = new Projektor("Projektor",jasnosc,rozdzielczosc);
                        serwis.DodajSprzet(projektor);
                    }
                    break;
                case 3:
                    if (serwis.ListaUzytkownikow.Count == 0 || serwis.ListaSprzetu.Count == 0)
                    {
                        Console.WriteLine("Brak użytkowników lub sprzętu!");
                        break;
                    }

                    Console.WriteLine("Wybierz użytkownika:");
                    for (int j = 0; j < serwis.ListaUzytkownikow.Count; j++)
                    {
                        Console.WriteLine(j + ". " + serwis.ListaUzytkownikow[j].Imie + " " + serwis.ListaUzytkownikow[j].Nazwisko);
                    }

                    int uIndex = Convert.ToInt32(Console.ReadLine());

                    List<Sprzet> dostepneSprzety = new List<Sprzet>();

                    Console.WriteLine("Wybierz sprzęt:");
                    for (int j = 0; j < serwis.ListaSprzetu.Count; j++)
                    {
                        if (serwis.ListaSprzetu[j].StatusSprzetu == Status.Dostepny)
                        {
                            dostepneSprzety.Add(serwis.ListaSprzetu[j]);
                        }
                    }

                    if (dostepneSprzety.Count == 0)
                    {
                        Console.WriteLine("Brak dostępnego sprzętu");
                        break;
                    }

                    for (int j = 0; j < dostepneSprzety.Count; j++)
                    {
                        Console.WriteLine(j + ". " + dostepneSprzety[j].NazwaSprzetu + " ID: " +
                                          dostepneSprzety[j].ID + " Status: " +
                                          dostepneSprzety[j].StatusSprzetu);
                    }

                    int sIndex = Convert.ToInt32(Console.ReadLine());

                    serwis.WypozyczSprzet(serwis.ListaUzytkownikow[uIndex], dostepneSprzety[sIndex]);
                    Console.WriteLine("Sprzęt został wypożyczony.");
                    break;
                case 4:
                    if (serwis.ListaUzytkownikow.Count == 0)
                    {
                        Console.WriteLine("Brak użytkowników!");
                        break;
                    }

                    Console.WriteLine("Wybierz użytkownika:");
                    for (int j = 0; j < serwis.ListaUzytkownikow.Count; j++)
                    {
                        Console.WriteLine(j + ". " + serwis.ListaUzytkownikow[j].Imie + " " + serwis.ListaUzytkownikow[j].Nazwisko);
                    }

                    int uIndex2 = Convert.ToInt32(Console.ReadLine());
                    Uzytkownik wybranyUzytkownik = serwis.ListaUzytkownikow[uIndex2];

                    List<Sprzet> wypozyczoneSprzetyUzytkownika = new List<Sprzet>();

                    for (int j = 0; j < serwis.ListaSprzetu.Count; j++)
                    {
                        for (int k = 0; k < serwis.ListaWypozyczen.Count; k++)
                        {
                            if (serwis.ListaWypozyczen[k].Uzytkownik == wybranyUzytkownik &&
                                serwis.ListaWypozyczen[k].Sprzet == serwis.ListaSprzetu[j] &&
                                serwis.ListaWypozyczen[k].DataFaktycznegoZwrotu == null)
                            {
                                wypozyczoneSprzetyUzytkownika.Add(serwis.ListaSprzetu[j]);
                            }
                        }
                    }

                    if (wypozyczoneSprzetyUzytkownika.Count == 0)
                    {
                        Console.WriteLine("Ten użytkownik nie ma aktywnych wypożyczeń.");
                        break;
                    }

                    Console.WriteLine("Wybierz sprzęt do zwrotu:");
                    for (int j = 0; j < wypozyczoneSprzetyUzytkownika.Count; j++)
                    {
                        Console.WriteLine(j + ". " + wypozyczoneSprzetyUzytkownika[j].NazwaSprzetu +
                                          " ID: " + wypozyczoneSprzetyUzytkownika[j].ID);
                    }

                    int sIndex2 = Convert.ToInt32(Console.ReadLine());

                    serwis.ZwrotSprzetu(wybranyUzytkownik, wypozyczoneSprzetyUzytkownika[sIndex2]);

                    Console.WriteLine("Zwrot wykonany.");
                    break;
                case 5:
                    serwis.WyswietlRaport();
                    break;
                case 6:
                    serwis.WyswietlDostepnySprzet();
                    break;
                case 7:
                    serwis.WyswietlWszystkieSprzety();
                    break;
                case 8:
                    if (serwis.ListaUzytkownikow.Count == 0)
                    {
                        Console.WriteLine("Brak użytkowników!");
                        break;
                    }

                    Console.WriteLine("Wybierz użytkownika:");
                    for (int j = 0; j < serwis.ListaUzytkownikow.Count; j++)
                    {
                        Console.WriteLine(j + ". " + serwis.ListaUzytkownikow[j].Imie + " " + serwis.ListaUzytkownikow[j].Nazwisko);
                    }

                    int uIndex3 = Convert.ToInt32(Console.ReadLine());
                    serwis.WyswietlAktywneWypozyczeniaUzytkownika(serwis.ListaUzytkownikow[uIndex3]);
                    break;
                case 9:
                    serwis.WysietlPrzeterminowane();
                    break;
                case 10:
                    if (serwis.ListaSprzetu.Count == 0)
                    {
                        Console.WriteLine("Brak sprzętu!");
                        break;
                    }

                    Console.WriteLine("Wybierz sprzęt do oznaczenia jako uszkodzony:");
                    for (int j = 0; j < serwis.ListaSprzetu.Count; j++)
                    {
                        Console.WriteLine(j + ". " + serwis.ListaSprzetu[j].NazwaSprzetu +
                                          " ID: " + serwis.ListaSprzetu[j].ID +
                                          " Status: " + serwis.ListaSprzetu[j].StatusSprzetu);
                    }

                    int sIndex3 = Convert.ToInt32(Console.ReadLine());
                    serwis.OznaczJakoUszkodzony(serwis.ListaSprzetu[sIndex3]);
                    Console.WriteLine("Sprzęt został oznaczony jako uszkodzony.");
                    break;
            }
        }
    }
}