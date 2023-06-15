# eAutobus - Aplikacija za autoprevoznicke kompanije

Aplikacija eAutobus je projekat rađen kao seminarski rad za predmet Razvoj softvera 2. Ova aplikacija omogućava pregled reda voznji, cjenovnika, rezervisanje i kupovina karata. Postoje 2 tipa korisnika: Uposlenici kompanije i kupci. Uposlenici kompanije koriste desktop aplikaciju, dok Kupci koriste mobilnu aplikaciju.

## Tehnologije

- Backend: C#, .NET 6.0
- Desktop aplikacija (Uposlenici): C#, Windows Forms
- Mobilna aplikacija (Kupci): Flutter

## Upute za instalaciju

1. Klonirajne GitHub repozitorija.

    ```
    git clone https://github.com/haris-tulic/Seminarski-RSII-eAutobus.git
    ```
    
2. Otvoriti klonirani repozitoriji u konzoli

3. Pokretanje dokerizovanog API-ja i DB-a

    ```
    docker-compose up --build
    ```
    
4. U visual studiu 2022, otvoriti Package Manager Console, kao default project izabrati 'eAutobus' i uraditi update baze

    ```
    update-database
    ```
    
5. Otvoriti eautobusmobile folder

    ```
    cd eautobusmobile
    ```

6. Dohvatanje dependecy-a

    ```
    flutter pub get
    ```
    
7. Pokretanje mobilne aplikacije

    ```
    flutter run
    ```   
    
8. Pokretanje desktop aplikacije

    ```
    1. Otvoriti solution u Visual Studiu 2022
    2. Desni klik na solution
    3. Configure Startup Projects
    4. Multiple startup projects
    5. eAutobus - Start
    6. eAutobus.WinUI - Start
    7. OK
    8. CTRL + F5
    ```    
    

## Kredencijali za prijavu   

### Desktop aplikacija

- Uposlenik

    ```
    Korisnicko ime: desktop            
    Lozinka: test                                    
    ```
### Mobilna aplikacija

- Kupac

    ```
    Korisnicko ime: kupac1
    Lozinka: test  
    ```
    
    ```
    Korisnicko ime: kupac2
    Lozinka: test  
    ```
## KARTICA ZA NARUDŽBU

    ```
    Broj kartice: 4242 4242 4242 4242 
    ```
