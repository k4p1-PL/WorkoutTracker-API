# Workout Tracker API 🏋️‍♂️

Proste i wydajne REST API do śledzenia progresji na siłowni i zarządzania objętością treningową. Projekt stworzony z myślą o czystej architekturze i dobrych praktykach programistycznych.

## 🚀 Technologie
* **C# / .NET** (Web API)
* **Entity Framework Core** (ORM)
* **SQLite** (Baza danych)
* **LINQ** (Logika biznesowa i agregacja danych)
* **Swagger/OpenAPI** (Dokumentacja i testowanie API)

## 💡 Główne funkcjonalności
* Rejestrowanie sesji treningowych wraz z przypisanymi do nich seriami i ćwiczeniami (relacje One-to-Many).
* Wyliczanie całkowitej objętości treningowej (Total Volume) dla danej sesji za pomocą LINQ.
* Zastosowanie wzorca **DTO (Data Transfer Object)** w celu separacji modelu bazy danych od interfejsu API i uniknięcia cyklicznych referencji.
* Eager Loading (`.Include()`) przy pobieraniu relacyjnych danych z bazy.

## ⚙️ Jak uruchomić projekt lokalnie?

1. Sklonuj repozytorium na swój komputer.
2. Otwórz terminal w głównym folderze projektu.
3. Projekt korzysta z bazy SQLite (plik generuje się lokalnie), więc nie wymaga zewnętrznego serwera SQL. 
4. Wpisz komendę, aby uruchomić aplikację:
   ```bash
   dotnet run
5. Przejdź pod adres widoczny w konsoli, dodając /swagger na końcu (np. http://localhost:5041/swagger), aby testować endpointy w przeglądarce.