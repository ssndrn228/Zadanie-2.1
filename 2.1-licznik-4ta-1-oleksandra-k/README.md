# Licznik Kliknięć — Aplikacja Desktopowa

Prosta, estetyczna i intuicyjna aplikacja desktopowa licznika kliknięć stworzona w technologii **C# / WPF (Windows Presentation Foundation)**.

## Funkcje aplikacji
- **Widoczna liczba kliknięć:** Duży, czytelny licznik w centralnym punkcie okna wraz ze statusem tekstowym.
- **Przycisk „Kliknij”:** Każde naciśnięcie zwiększa licznik o 1.
- **Przycisk „Zeruj”:** Przywraca stan licznika do 0.
- **Obsługa skrótów klawiszowych:**
  - `Spacja` — zwiększenie licznika o 1
  - `R` lub `Esc` — wyzerowanie licznika do 0
- **Nowoczesny interfejs:** Estetyczna stylizacja w stylu nowoczesnego systemu Windows (zaokrąglone rogi, spójna paleta kolorów, efekty najechania myszą).

## Jak uruchomić aplikację?
Aplikację można uruchomić na dwa proste sposoby:
1. Kliknąć dwukrotnie plik **`LicznikKlikniec.exe`**.
2. Lub uruchomić plik **`uruchom.bat`**.

## Jak skompilować kod źródłowy?
Aplikacja kompiluje się przy użyciu wbudowanego w system Windows kompilatora C# (`csc.exe`). Aby ponownie skompilować projekt po zmianach w `Program.cs`, wystarczy uruchomić:
```cmd
build.bat
```

## Struktura plików w projekcie
- **`Program.cs`** — kod źródłowy aplikacji (C# / WPF)
- **`LicznikKlikniec.exe`** — gotowa aplikacja desktopowa
- **`build.bat`** — skrypt kompilacji
- **`uruchom.bat`** — skrypt szybkiego uruchomienia
- **`obserwacje/`** — folder z kartą obserwacji
