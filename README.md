# 🏋️‍♂️ Workout Tracker (Full-Stack .NET & React)

Kompletna aplikacja do śledzenia progresji na siłowni i zarządzania objętością treningową. Prezentujący znajomość nowoczesnych technologii webowych, architektury klient-serwer oraz dobrych praktyk programistycznych.

## 🚀 Technologie

**Wykorzystane technologie:**
* **Backend:** C#, ASP.NET Core 10, Entity Framework Core, SQLite
* **Architektura & Wzorce:** REST API, Dependency Injection, Service Layer (SOLID), DTO, AutoMapper
* **Jakość:** xUnit (Testy automatyczne), Data Annotations (Walidacja modeli)
* **CI/CD:** GitHub Actions (Automatyczne testowanie po każdym pushu)
* **Frontend:** React (Vite), Hooks (useState, useEffect), nowoczesny CSS (Dark Mode)

## 🎯 Główne funkcjonalności
* **Pełny system CRUD** dla sesji treningowych i ćwiczeń.
* **Relacyjna baza danych:** Rejestrowanie sesji wraz z przypisanymi seriami i ćwiczeniami (relacje One-to-Many).
* **Logika biznesowa LINQ:** Automatyczne wyliczanie objętości treningowej (Total Volume) w dedykowanej warstwie serwisów.
* **Architektura DTO:** Bezpieczna komunikacja i brak problemów z cyklicznymi referencjami dzięki mapowaniu obiektów (AutoMapper).
* **Obsługa błędów:** Walidacja wejścia (JSON) i obsługa wyjątków.
* **Dashboard Front-end:** Nowoczesny, responsywny interfejs w React prezentujący statystyki pobierane na żywo z API.
* **Swagger UI:** Interaktywna dokumentacja API do testowania endpointów.

## 🛠️ Jak uruchomić projekt lokalnie?

Aby w pełni przetestować aplikację, należy uruchomić jednocześnie Backend (API) oraz Frontend (React) w dwóch osobnych oknach terminala.

### Krok 1: Uruchomienie API (Backend)
1. Sklonuj repozytorium na swój komputer.
2. Otwórz terminal w głównym folderze API (tam gdzie plik `.csproj`).
3. Wpisz komendę:
	```bash
	dotnet run
	```
4. API uruchomi się lokalnie (baza SQLite wygeneruje się automatycznie). Swagger będzie dostępny pod adresem widocznym w konsoli (np. https://localhost:7134/swagger).

### Krok 2: Uruchomienie interfejsu (Frontend)
1. Otwórz drugie okno terminala.
2. Wejdź do folderu frontendu:
	```bash
	cd frontend
	```
3. Zainstaluj pakiety i uruchom aplikację:
	```bash
	npm install
	npm run dev
	```
4. Aplikacja otworzy się w przeglądarce pod adresem podanym w terminalu (zazwyczaj http://localhost:5173).