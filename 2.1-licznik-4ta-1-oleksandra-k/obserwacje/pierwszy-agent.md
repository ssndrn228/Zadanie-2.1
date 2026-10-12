# Mój pierwszy agent — karta obserwacji

- Narzędzie i model: Antigravity, Gemini 3.8 Flash High
- Moje zadanie (2–3 zdania): Stworzenie prostej aplikacji desktopowej licznika kliknięć z przyciskiem zerowania.
- Pierwsza wiadomość (wklejona co do znaku): Stwórz prostą aplikację desktopową licznika kliknięć. Na ekranie ma być widoczna liczba kliknięć oraz przyciski „Kliknij” i „Zeruj”. Aplikacja ma być estetyczna, prosta i łatwa w obsłudze. Uznaję, że działa, jeśli po kliknięciu licznik zwiększa się o 1, a po naciśnięciu „Zeruj” wraca do 0. Sam utwórz potrzebne pliki, uruchom aplikację i sprawdź, czy wszystko działa. Pracuj wyłącznie w otwartym folderze projektu.
- Co agent zrobił najpierw: Poprosił o zgodę na sprawdzenie zawartości folderu projektu.
- O co pytał — i co zostało zatwierdzone bez czytania: O zgodę na wyświetlenie listy plików i folderów.
- Pierwszy błąd i co agent z nim zrobił: Agent napotkał błąd podczas kompilacji szablonu przycisku. Następnie wykonywał dodatkowe testy i kontrole, aż utworzył i uruchomił aplikację.
- Stan po 25 minutach: działa
- Skąd wiem, że aplikacja działa (co zostało sprawdzone): Agent poinformował, że aplikacja została utworzona, skompilowana i uruchomiona. Projekt zawiera kod źródłowy, plik wykonywalny oraz pliki pomocnicze. Następnie sprawdziłam przyciski „Kliknij” oraz „Zeruj”. Po kliknięciu licznik zwiększał się o 1, a po wyzerowaniu wracał do wartości 0.
- Rzeczy, które agent zrobił, a których nie rozumiem: Agent wykonywał polecenia w PowerShell i CMD, sprawdzał pliki WPF, kompilował kod C# oraz wielokrotnie kontrolował, czy proces aplikacji działa.
- Jak mi się wydawało, że poszło (jedno zdanie): Agent ostatecznie stworzył działającą aplikację, ale często prosił o zgodę na wykonywanie poleceń i przeprowadzał wiele dodatkowych kontroli.