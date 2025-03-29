//Mark Sadnik
#include <iostream>
#include <ctime>
#include <random>
#include <chrono>
#include <iomanip>
#include <thread>
#include <math.h>
#include <string>
#include <fstream>

using namespace std;

// struktura
struct Igralec
{
    int id;
    int sekund;
    int poskusi;
    string ime;
    string geslo;
    string ugibane;
    Igralec *next;
};

//funkcije
void dodajNaKonec(Igralec *&zac, Igralec *&tmp);
void zbrisi(Igralec *&zac, int id);
void zbrisiNajslabsega(Igralec *&zac);
string printChr(char ch, int amount);
void izpisiStatistiko(Igralec *zac);
string remove(string input, char ch);
int zracunajTocke(Igralec *&player);

int main()
{
    //POGOJ: datoteki se nahajata v istem imeniku kot executable - relativno
    string imagesPath = "slike.csv", geslaPath = "gesla.csv";
    const int numOfPlayers = 5, numOfScenarios = 10, numOfWords = 100;

    //preberi slike iz datoteke in jih daj v polje slik - FORMAT CSV: glej dno strani              
    string scenariji[numOfScenarios];
    string temp1;
    ifstream strm1;
    strm1.open(imagesPath, ifstream::in);
    if(strm1.is_open()){
        for(int i = 0; getline(strm1, temp1, ','); i++) scenariji[i] = temp1;
    }
    else cout << "ni uspelo prebrati scenarijev :( \n";
    
    strm1.close();

    //preberi gesla iz datoteke in jih daj v polje - FORMAT csv: "geslo1,geslo2,geslo3,..."
    string gesla[numOfWords];
    string temp2;
    ifstream strm2;
    strm2.open(geslaPath, ifstream::in);
    if(strm2.is_open()){
        for (int i = 0; getline(strm2, temp2, ','); i++) {
            //odstrani presledke iz gesel
            temp2 = remove(temp2, ' ');
            gesla[i] = temp2;
        }
    }
    else cout << "ni uspelo prebrati gesel :( \n";
    
    strm2.close();

    //polje igralcev, enosmerni seznam
    Igralec* zac = new Igralec;
    zac = NULL;

    printChr('-', 139);

    // glavna zanka - player input
    for (int i = 0; i < numOfPlayers; i++)
    {
        // vpisi ime igralca
        string tempIme;
        cout << "Vpisite ime igralca " << (i + 1) << ": ";
        cin >> tempIme;
        cout << "\n\n";

        //vpis dolžine gesla
        int gesloLen;
        cout << "Vpisite zazeljeno dolzino gesla ('0 za nakljucno'): ";
        cin >> gesloLen;
        cout << "\n\n";
        
        string geslo;    
        int gesloIndex;
        bool foundWord = false;

        //poljubna dolzina
        if(gesloLen > 0){
            int foundArr[numOfWords];
            int foundCount = 0;
            for(int i = 0; i < numOfWords; i++){
                if(gesla[i].length() == gesloLen) {
                    foundArr[foundCount] = i;
                    foundCount++;
                }
            }
            if(foundCount > 0){
                foundWord = true;
                srand(time(0));
                gesloIndex = foundArr[(rand() % foundCount)];
            }
        }

        // naključno izberi geslo
        if(!foundWord){
            srand(time(0));
            gesloIndex = (rand() % (numOfWords-1));
        }

        // izberi geslo iz polja
        geslo = gesla[gesloIndex];
        string ugibano = geslo;
                
        for (int i = 0; i < ugibano.length(); i++) ugibano[i] = '_';

        // hrani pozicije ugibanih črk in število poskusov
        int attempts = -1;

        // začetek ure
        clock_t start = clock();

        Igralec* currentPlayer = NULL;
        currentPlayer = new Igralec;
        currentPlayer -> ime = tempIme;
        currentPlayer -> id = (i+1);
        currentPlayer -> geslo = geslo;
        currentPlayer -> ugibane = ugibano;

        // posamične igre - 10 poskusov
        while (attempts < numOfScenarios)
        {
            char guess;

            printChr('=', 139);

            // začetek - brez slike
            if (attempts == -1)
                cout << " " << "\n\n";
            // konec - pokaži sliko in končaj loop
            else if (attempts == (numOfScenarios - 1))
            {
                cout << scenariji[attempts] << "\n\n";
                break;
            }
            // ostali primeri
            else cout << scenariji[attempts] << "\n\n";

            cout << "stanje: " << ugibano << "\n";
            cout << "Preostalih poskusov: " << numOfScenarios - (attempts + 1) << "\n\n";
            cout << "Vpišite črko: ";
            cin >> guess;
            guess = tolower(guess);

            bool correct = false;

            for (int i = 0; i < geslo.length(); i++)
            {
                if (geslo[i] == guess)
                {
                    correct = true;
                    ugibano[i] = geslo[i];
                }
            }

            // nepravilno
            if (!correct)
            {
                attempts++;
            }
            // pravilno
            else
            {
                // ugibano geslo
                if (ugibano == geslo)
                {
                    cout << "\n\n!!ČESTITKEEE!! UGANILI STE: '" << geslo << "' \n";
                    break;
                }
            }
        }

        // končaj uro in zračunaj sekunde
        clock_t end = clock();
        double timeRaw = ((double)(end - start)) / CLOCKS_PER_SEC;
        int secondsPassed = (int)floor(timeRaw);
        attempts++;

        //cout << "KONEC IGRE ZA IGRALCA " << (i + 1) << ": " << igralci[i].ime << "\n";
        cout << "KONEC IGRE ZA IGRALCA " << (i + 1) << ": " << currentPlayer -> ime << "\n";
        cout << "PORABILI STE: " << secondsPassed << " sekund \n";
        cout << "GESLO JE BILO: '" << currentPlayer -> geslo << "'\n";
        cout << "ŠTEVILO POSKUSOV: " << attempts << "\n";
        
        printChr('-', 139);

        currentPlayer -> sekund = secondsPassed;
        currentPlayer -> poskusi = attempts;
        currentPlayer -> ugibane = ugibano;
        currentPlayer -> next = NULL;

        dodajNaKonec(zac, currentPlayer);
        
        //hrani samo najboljso polovico igralcev
        if(i >= (numOfPlayers/2)) zbrisiNajslabsega(zac);
    }

    izpisiStatistiko(zac);

    return 0;
}

//izpis statistike na izhod in v datoteko 'statistika.txt'
void izpisiStatistiko(Igralec *zac){
    /*FORMAT: "| Tekmovalec      | Geslo           | Ugibano          | Število ugibanj | Čas [s]    | Točk     |" */
    ofstream statistikaOutput("statistika.txt");

    const int space1 = 25, space2 = 10;
    cout << "| " << setw(space1) << "Tekmovalec" << " | ";
    cout << setw(space1) << "Geslo" << " | ";
    cout << setw(space1) << "ugibano" << " | ";
    cout << setw(space1) << "Stevilo ugibanj" << " | ";
    cout << setw(space2) << "Cas [s]" <<  " | ";
    cout << setw(space2) << "Tock" <<  " |\n";
    
    statistikaOutput << "| " << setw(space1) << "Tekmovalec" << " | ";
    statistikaOutput << setw(space1) << "Geslo" << " | ";
    statistikaOutput << setw(space1) << "ugibano" << " | ";
    statistikaOutput << setw(space1) << "Stevilo ugibanj" << " | ";
    statistikaOutput << setw(space2) << "Cas [s]" <<  " | ";
    statistikaOutput << setw(space2) << "Tock" <<  " |\n";
    statistikaOutput << printChr('=', 139);

    Igralec *tempK = zac;
    
    while(tempK != NULL){
        cout << "| " << setw(space1) << tempK -> ime << " | ";
        statistikaOutput << "| " << setw(space1) << tempK -> ime << " | ";
        
        cout << setw(space1) << tempK -> geslo << " | ";
        statistikaOutput << setw(space1) << tempK -> geslo << " | ";
        
        cout << setw(space1) << tempK -> ugibane << " | ";
        statistikaOutput << setw(space1) << tempK -> ugibane << " | ";
        
        cout << setw(space1) << tempK -> poskusi << " | ";
        statistikaOutput << setw(space1) << tempK -> poskusi << " | ";

        cout << setw(space2) << tempK -> sekund << " | ";
        statistikaOutput << setw(space2) << tempK -> sekund << " | ";

        cout << setw(space2) << zracunajTocke(tempK) <<  " |\n";
        statistikaOutput << setw(space2) << zracunajTocke(tempK) <<  " |\n";
        
        tempK = tempK -> next;
    }
        
    statistikaOutput << printChr('=', 139);

    statistikaOutput.close();
}

//dodajanje na konec seznama
void dodajNaKonec(Igralec *&zac, Igralec *&tmp){
    if(zac == NULL){
        zac = tmp;
    }
    else{
        Igralec* tempK = zac;
        while(tempK -> next != nullptr){
            tempK = tempK -> next; 
        }
        tempK -> next = tmp;
    }
}

//izracun tock
int zracunajTocke(Igralec *&player){
    if(player != NULL){
        int total = 0;
        //ce je uporabnik uganil geslo => pristej 100 tock
        if(player -> geslo == player -> ugibane) total += 100;

        //razmerje med stevilom ugibanih crk in stevilim poskusov
        string guessed = remove((player -> ugibane), '_');
        double ratio = guessed.length();
        if(player -> poskusi > 0) ratio /= (player -> poskusi);
        total += (int)(ratio * 100);

        return total;
    }
    return 0;
}

//najde najslabsega in ga zbrise z 'zbrisi' funkcijo
void zbrisiNajslabsega(Igralec *&zac){
    //brisi samo ce sta vsaj dva igralca v igri
    if(zac != NULL && zac -> next != NULL){
        Igralec *tempK = zac;
        int id = zac -> id;
        int min = zracunajTocke(zac);

        while(tempK -> next != NULL){
            tempK = tempK -> next;
            if(tempK -> poskusi <= 0) continue;
            int temp = zracunajTocke(tempK);
            if(temp < min) {
                id = tempK -> id;
                min = temp;
            }
        }

        //zbrisi najslabsega igralca
        zbrisi(zac, id);
    }
}

//zbrise igralca s podanim id
void zbrisi(Igralec *&zac, int id){
    Igralec* tempK = zac;

    //brisanje na zacetku
    if(id == zac -> id){
        tempK = zac;
        zac = zac -> next;
        cout << "Izpade \"" << tempK -> ime << "\" => " << zracunajTocke(tempK) << " tock\n\n"; 
        delete tempK;
    }

    //brisanje vmes oz na koncu seznama
    else{
        Igralec *tempNext = tempK -> next;
        for(int i = 1; i <= id; i++){
            //naslednega elementa ni - konec
            if(tempNext == NULL) break;

            //najden id - spremeni kazalce, brisi naslednega
            if(tempNext -> id == id)
            {
                tempK -> next = tempNext -> next;
                cout << "Izpade \"" << tempNext -> ime << "\" => " << zracunajTocke(tempNext) << " tock\n\n"; 
                delete tempNext;
                break;
            }
        
            tempK = tempK -> next;
            tempNext = tempK -> next;
        }
    }
}

//izpisi podan znak v zanki
string printChr(char ch, int amount)
{
    string output = "";
    for (int i = 0; i < amount; i++) output += ch;
    output += "\n";
    cout << output;
    return output;
}

//odstranjevanje znakov iz niza - presledkov iz gesel
string remove(string input, char ch){
    int len = input.length();
    bool isGood = true;

    for(int i = 0; i < len; i++){
        //najden prepovedan znak
        if(input[i] == ch){
            isGood = false;
            string left = "", right = "";
            //zberi nize levo in desno od prepovedanega znaka
            for(int j = 0, k = (i + 1); j < i || k < len;){
                if(j < i){
                    left += input[j];
                    j++;
                }
                if(k < len){
                    right += input[k];
                    k++;
                }
            }
            //zlepi nize
            input = left + right;
            break;
        }
    }

    if(isGood) return input;
    //rekurzivno brisi znake dokler jih ni vec
    return remove(input, ch);
}

/*FORMAT SLIK:
          
          
          
          
          
          
========= ,
          
       |  
       |  
       |  
       |  
       |  
========= ,
   +---+  
       |  
       |  
       |  
       |  
       |  
========= ,
   +---+  
   |   |  
       |  
       |  
       |  
       |  
========= ,
   +---+  
   |   |  
   0   |  
       |  
       |  
       |  
========= ,
   +---+  
   |   |  
   0   |  
   |   |  
       |  
       |  
========= ,
   +---+  
   |   |  
   0   |  
   |   |  
  /    |  
       |  
========= ,
   +---+  
   |   |  
   0   |  
   |   |  
  / \  |  
       |  
========= ,
   +---+  
   |   |  
   0   |  
  /|   |  
  / \  |  
       |  
========= ,
   +---+  
   |   |  
   0   |  
  /|\  |  
  / \  |  
 KONEC |  
========= 
*/
