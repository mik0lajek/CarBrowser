# 🚗 CarBrowser & CarGate – aplikacja do przeglądania danych CEPiK

Projekt aplikacji desktopowej oraz backendu REST API umożliwiający przeglądanie danych pojazdów z systemu CEPiK.

## 🧩 Architektura

Projekt składa się z dwóch głównych komponentów:

* **CarBrowser** – aplikacja desktopowa (WPF, .NET 8, MVVM)
* **CarGate** – serwer REST API (ASP.NET Core Web API)

Komunikacja:
CarBrowser → REST API (CarGate) → API CEPiK

Aplikacja kliencka nie komunikuje się bezpośrednio z CEPiK.

---

## ⚙️ Technologie

* C#
* .NET 8
* ASP.NET Core Web API
* WPF (MVVM)
* REST API
* Logger
* Mapowanie modeli (Mapper)

---

## 🚀 Funkcjonalności

### Backend (CarGate)

* sprawdzanie dostępności serwera (`GET /api/system/ping`)
* sprawdzanie statusu CEPiK
* pobieranie słowników (np. województwa)
* filtrowanie pojazdów (POST /api/filtering/vehicleFilters)
* pobieranie informacji o plikach archiwalnych

### Frontend (CarBrowser)

* ekran startowy (sprawdzanie dostępności usług)
* logowanie użytkownika
* filtrowanie pojazdów (różne parametry)
* wyświetlanie szczegółów pojazdu
* przeglądanie i pobieranie plików (~100MB, async)

---

## 🧠 Wzorce i podejście

* MVVM (WPF)
* czysta architektura (logika w serwisach)
* Dependency Injection
* separacja frontend / backend
* komunikacja REST

---

## 📡 Źródło danych

Dane pochodzą z API CEPiK:
https://api.cepik.gov.pl/doc

---

## 👨‍💻 Autorzy

* Mikołaj Sosiński
* Dawid Zwolak

---

## 📌 Status

Projekt wykonany w ramach zajęć akademickich.
