# Workout Tracker API 🏋️‍♂️

Proste i wydajne REST API do śledzenia progresji na siłowni i zarządzania objętością treningową. Projekt stworzony z myślą o czystej architekturze i dobrych praktykach programistycznych.

## 🚀 Technologie
* **C# / .NET** (Web API)
* **Entity Framework Core** (ORM)
* **SQLite** (Baza danych)
* **LINQ** (Logika biznesowa i agregacja danych)
* **Swagger/OpenAPI** (Dokumentacja i testowanie API)

## 💡 Główne funkcjonalności
* **Pełny system CRUD** dla sesji treningowych (tworzenie, odczyt, aktualizacja, usuwanie).
* Rejestrowanie sesji wraz z przypisanymi seriami i ćwiczeniami (relacje One-to-Many).
* **Logika biznesowa LINQ:** Automatyczne wyliczanie objętości treningowej (Total Volume).
* **Architektura DTO:** Bezpieczna komunikacja i brak problemów z cyklicznymi referencjami dzięki mapowaniu obiektów.
* **Obsługa błędów:** Walidacja wejścia (JSON) oraz obsługa wyjątków bazy danych (Status 400, 404, 500).
* **Swagger UI:** Interaktywna dokumentacja API do testowania endpointów bezpośrednio z przeglądarki.
* **Czysta architektura:** Wyraźny podział na warstwy (Controllers, Services, Repositories) dla lepszej organizacji kodu i łatwiejszej konserwacji.

## ⚙️ Jak uruchomić projekt lokalnie?

1. Sklonuj repozytorium na swój komputer.
2. Otwórz terminal w głównym folderze projektu.
3. Projekt korzysta z bazy SQLite (plik generuje się lokalnie), więc nie wymaga zewnętrznego serwera SQL. 
4. Wpisz komendę, aby uruchomić aplikację:
   ```bash
   dotnet run
5. Przejdź pod adres widoczny w konsoli, dodając /swagger na końcu (np. http://localhost:5041/swagger), aby testować endpointy w przeglądarce.