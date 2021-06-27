# APBD
#### Zbiorcze repozytorium dla zadań z przedmiotu Aplikacje Baz Danych realizowanego w ramach toku studiów. Polegał on głównie na pisaniu zapytań do bazy danych z wykorzystaniem zarówno rozwiązań niskopoziomowych jak SqlConnectio/SqlCommand jak i za pomocą Entity Framework. Pod koniec semestru były również realizowanie podstawy frameworka blazor w celu prezentacji danych. Na przestrzeni przedmiotu uzyskałem 96 na 100 możliwych do uzyskania punktów z przełożyło się na zwolnienie z egzaminu tak więc uważam repozytorium zawierające te zadania za porządnie wykonane

## Technologie użyte podczas realizacji tego przedmiotu:
* C#
* .NET Framework
* Blazor
* ASP.NET Core MVC

## Spis Treści
* [Zadanie pierwsze - Crawler](#crawler)
* [Zadanie drugie - Parsowanie CSV](#parsowanie-csv)
* [Zadanie trzecie - CRUD w oparciu o plik CSV](#CRUD-w-oparciu-o-plik-CSV)
* [Zadanie czwarte - CRUD w oparciu o bazę danych i SqlConnection/SqlCommand](#CRUD-w-oparciu-o-bazę-danych-i-SqlConnection/SqlCommand)
* [Zadanie piąte - Wykorzystanie procedur po stronie bazy danych](#Wykorzystanie-procedur-po-stronie-bazy-danych)
* [Zadanie szóste - Zapytania LINQ](#Zapytania-LINQ)
* [Zadanie siódme - Entity Framework z podejściem Database First](#Entity-Framework-z-podejściem-Database-First)
* [Zadanie ósme - Entity Framework z podejściem Code First](#Entity-Framework-z-podejściem-Code-First)
* [Zadanie dziewiąte - JWT Token i Middleware\'y](#JWT-Token-i-Middleware\'y)
* [Zadanie jedenaste - Wstęp do pracy z ASP.NET Core MVC](#Wstęp-do-pracy-z-ASP.NET-Core-MVC)
* [Zadanie dwunaste - CRUD z wykorzystaniem Frameworka Blazor](#CRUD-z-wykorzystaniem-Frameworka-Blazor)
* [Zadanie trzynaste - Praca z Blazorem po stronie klienta](#Praca-z-Blazorem-po-stronie-klienta)
* [Zadanie dodatkowe - Refractoring kodu](#Refractoring-kodu)

## Crawler
Zadanie polegające na pobraniu adresu strony internetowej poprzez parametry programu, znalezieniu za pomocą wyrażenia regularnego unikalnych maili w źródle strony oraz wyświetleniu ich

## Parsowanie CSV
Zadanie polegające na zczytaniu z konsoli trzech parametrów jakimi są kolejno ścieżka do pliku z danymi w formacie CSV, ścieżka docelowa na umieszczenie sparsowanych danych i logu błędu oraz informacja o formacie( Obsługiwany JSON oraz XML). Program zczytuje dane i odfiltrowywuje powtarzające się i wybrakowane rekordy. Informacje o potencjalnych błędach oraz wadliwych/powtarzających się rekordach są umieszczane w pliku Log.txt.

## CRUD w oparciu o plik CSV
Utworzenie podstawowych interakcji z API (GET,POST,PUT,DELETE) z wykorzystaniem używanego w poprzednim zadaniu pliku CSV jako miejsca zapisu danych.

## CRUD w oparciu o bazę danych i SqlConnection/SqlCommand
Pierwsze zadanie polegające na pobieraniu danych z realnej bazy danych. Wykorzystane są tutaj niskopoziomowe rozwiązane korzystające z klas SqlConnection/SqlCommand, gdzie komendy wykonane po stronie bazy danych definiuje samemu. Wprowadzanee danych do komend SQl jest zabezpieczone przed SQL Injection za pomocą "Parameters". Gddybym zamiast tego to komendy SQL podstawiał dane za pomocą konkatenacji stringów to byłyby one podatne właśnie na strzykiwanie SQL.

## Wykorzystanie procedur po stronie bazy danych
Zadanie bardzo podobne do poprzedniego jednak tym razem polega na dostarczeniu danych do obecnej po stronie bazy danych procedury, która realizuję większość logiki.

## Zapytania LINQ
Zestaw polegający na utworzeniu kilkunastu zapytań LINQ, które miały realizować zamieszoczne w komentarzach funkcjonalności. Dodatkowo do zadania dodałem testy jednostkowe ażeby je przećwiczyć przy okazji

## Entity Framework z podejściem Database First
W tym zadaniu należało po stronie bazy danych utworzyć tabele, bazując na otrzymanym diagramie encji a następnie za pomocą komendy "Scaffold-DbContext" utworzyć po stronie aplikacji klasy odpowiadające danym z bazy danych. W ramach zadania należało utworzyć także dwie końcówki realizujące zapytania do bazy danych tak by przetestować poprawnośc zdefiniowanych constraintów

## Entity Framework z podejściem Code First
Zadanie analogiczne do poprzedniego tylko z podejściem Code First. Należało tutaj utworzyć po stronie aplikacji klasy modeli wraz z odpowiednią dla nich konfiguracją i przykładowymi danymi na podstawie dostarczonego diagramu encji. Następnie za pomocją migracji( komendy: "Add-Migration", "Update-Database" należało wygenerować tabele po stronie bazy danych. Zadanie zawierało też napisanie dwóch przykładowych końcówek w celu przetestowania popraności pobierania danych z utworzonych tabel

## JWT Token i Middleware\'y
Zadanie polegające na zaimplementowaniu logiki pozwalającej na dostęp do niektówyrhc funkcji jedynie dla użytkownika, który uzyska JWT Token, który później byłby odświeżany za pomocą refresh tokenu. W ramach zadania należało też utworzyć middleware, który zapisywał by logi błędów. Sam projekt użyty w zadaniu bazuje na kodzie utworzonym w ramach ósmego zadania

## Wstęp do pracy z ASP.NET Core MVC
Wykonanie prostej strony korzystającej z danych dostępnych w lokalnej bazie danych i oferującej podstawowe operacje na nich(Create, Update, Read, Delete)

## CRUD z wykorzystaniem Frameworka Blazor
Zestaw będący wstępem do pracy z frameworkiem Blazor. Należało tutaj dla prostej kolekcji studentów zdefiniowanej jako lista( Osobiście zmieniłem źródło danych na lokalną bazę danych) utworzyć interfejs za pomocą frameworka Blazor, który pokazywał by wszystkie obecne w bazie danych rekordy oraz pozwalał zarówno na ich usuwanie jak i dodawanie nowych za pomocą dodatkowe formularza

## Praca z Blazorem po stronie klienta
Zestaw polegający na rozbiciu logiki na trzy projekty( Klient, Serwer i Shared) w celu zrealizowaniu podobnej funkcjonalności jak w zadaniu poprzednim. W dniu ustawieniu Repozytorium na publiczny widok (27.06.2021) zadanie to pozostaje niedokończone, ponieważ pod koniec semestru nie miałem czasu się nim zająć co przełozyło się na utratę jednych punktów na przestrzeni semestru. Zostanie ono dokończone podczas wakacji 2021.

## Refractoring-kodu
Dodatkowe zadanie pochodzące z początku semestru, które polegało na poprawieniu jakości otrzymanego kodu wraz z zasadami SOLID
