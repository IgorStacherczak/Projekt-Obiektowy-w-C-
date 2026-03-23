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
        
        while (i != 0)
        {
            Console.WriteLine("1. Dodaj użytkownika\n" +
                              "2. Dodaj sprzęt\n" +
                              "3. Wypożycz sprzęt\n" +
                              "4. Zwróć sprzęt\n" +
                              "5. Raport\n" +
                              "6. Wyświetl dostępny sprzęt\n" +
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

                    Console.WriteLine("Wybierz sprzęt:");
                    for (int j = 0; j < serwis.ListaSprzetu.Count; j++)
                    {
                        Console.WriteLine(j + ". " + serwis.ListaSprzetu[j].NazwaSprzetu + " ID: " + serwis.ListaSprzetu[j].ID + " Status: " + serwis.ListaSprzetu[j].StatusSprzetu);
                    }

                    int sIndex = Convert.ToInt32(Console.ReadLine());

                    serwis.WypozyczSprzet(serwis.ListaUzytkownikow[uIndex], serwis.ListaSprzetu[sIndex]);

                    Console.WriteLine("Próba wypożyczenia wykonana.");
                    break;

                case 4:
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

                    int uIndex2 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Wybierz sprzęt:");
                    for (int j = 0; j < serwis.ListaSprzetu.Count; j++)
                    {
                        Console.WriteLine(j + ". " + serwis.ListaSprzetu[j].NazwaSprzetu + " ID: " + serwis.ListaSprzetu[j].ID);
                    }

                    int sIndex2 = Convert.ToInt32(Console.ReadLine());

                    serwis.ZwrotSprzetu(serwis.ListaUzytkownikow[uIndex2], serwis.ListaSprzetu[sIndex2]);

                    Console.WriteLine("Próba zwrotu wykonana.");
                    break;
                case 5:
                    serwis.WyswietlRaport();
                    break;
                case 6:
                    serwis.WyswietlDostepnySprzet();
                    break;
            }
        }
    }
}