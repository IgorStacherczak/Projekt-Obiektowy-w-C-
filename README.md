# Projekt-Obiektowy-w-C-

## Opis projektu
Aplikacja konsolowa do zarządzania wypożyczalnią sprzętu.  
Pozwala dodawać użytkowników i sprzęt, wypożyczać i zwracać sprzęt, sprawdzać dostępność oraz generować raport.

---

## Model
W projekcie znajdują się główne klasy:

- `Sprzet` – klasa abstrakcyjna dla wszystkich typów sprzętu
- `Laptop`, `Kamera`, `Projektor` – konkretne typy sprzętu
- `Uzytkownik` – użytkownik systemu (Student / Pracownik)
- `Wypozyczenie` – przechowuje informacje o wypożyczeniu
- `SerwisWypozyczalni` – logika działania systemu

---

## Decyzje projektowe
- Logika biznesowa znajduje się w `SerwisWypozyczalni`
- `Program.cs` odpowiada tylko za obsługę menu i wejścia użytkownika
- `Sprzet` jest klasą abstrakcyjną, bo nie tworzymy ogólnego sprzętu
- Typ użytkownika i status sprzętu są zapisane jako enumy

---

## Organizacja kodu
- Każda klasa ma jedno zadanie (np. `Uzytkownik`, `Sprzet`, `Wypozyczenie`)
- Logika jest oddzielona od interfejsu (Program vs Serwis)
- Dziedziczenie zmniejsza powtarzanie kodu (Sprzet → Laptop/Kamera/Projektor)

---

## Funkcjonalności
- Dodawanie użytkownika
- Dodawanie sprzętu różnych typów (Laptop, Kamera, Projektor)
- Wyświetlanie całego sprzętu z aktualnym statusem
- Wyświetlanie tylko dostępnego sprzętu
- Wypożyczanie sprzętu użytkownikowi
- Zwrot sprzętu
- Oznaczanie sprzętu jako uszkodzony
- Wyświetlanie aktywnych wypożyczeń użytkownika
- Wyświetlanie przeterminowanych wypożyczeń
- Generowanie raportu systemu

---

## Reguły
- Student max 2 wypożyczenia
- Pracownik max 5 wypożyczeń
- Nie można wypożyczyć niedostępnego sprzętu
- System blokuje wypożyczenie po przekroczeniu limitu
- Możliwe naliczenie kary za opóźnienie