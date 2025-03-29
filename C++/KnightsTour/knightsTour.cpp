//Mark Sadnik
#include <iostream>
#include <string>
#include <iomanip>
#include <math.h>
using namespace std;

const int boardWidth = 8, boardHeight = 8;
const char crke[26] = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
const int validMoves[8][2] = {
    {-2, 1},
    {-2, -1},
    {2, 1},
    {2, -1},
    {-1, 2},
    {1, 2},
    {-1, -2},
    {1, -2}
};

bool isValidPosition(int row, int col){
    return (row >= 0 && row < boardHeight && col >= 0 && col < boardWidth);
}

int findMoves(int premiki[boardHeight][boardWidth], int row, int col){
    int numOfMoves = 0;
    
    //vrni stevilo moznih skokov v okolici
    for(int i = 0; i < 8; i++){
        int tempCol = col + validMoves[i][0], tempRow = row + validMoves[i][1];
        //skok mora biti veljaven in pristati na neobiskanem polju
        if(isValidPosition(tempRow, tempCol) && premiki[tempRow][tempCol] == 0){
            numOfMoves++;
        }
    }
    return numOfMoves;
}

void knightsTour(int premiki[boardHeight][boardWidth], int row, int col, int &steps){
    premiki[row][col] = steps;

    //preveri stevilo korakov
    if(steps < boardHeight * boardWidth){
        int nextRow = -1, nextCol = -1, minMoves = 10;

        //pregledaj vitezove premike in poisci naslednjega z najmanj moznimi skoki
        for(int i = 0; i < 8; i++){
            int tempCol = col + validMoves[i][0], tempRow = row + validMoves[i][1];
            if(isValidPosition(tempRow, tempCol) && premiki[tempRow][tempCol] == 0){
                int moves = findMoves(premiki, tempRow, tempCol);
                if(moves < minMoves){
                    minMoves = moves;
                    nextRow = tempRow;
                    nextCol = tempCol;
                }
            }
        }

        //prestavi viteza na polje z najmanj moznimi skoki
        if(nextRow != -1 && nextCol != -1){
            steps++;
            knightsTour(premiki, nextRow, nextCol, steps);
        }
    }
}

void outputMoves(int premiki[boardHeight][boardWidth]){
    int outputWidth = floor(log10(boardHeight * boardWidth)) + 1;
    for(int i = 0; i < boardHeight; i++){
        for(int j = 0; j < boardWidth; j++){
            cout << setw(outputWidth) << premiki[i][j] << " ";
        }
        cout << "\n";
    }
}

void drawBoard(){
    cout << "Sahovnica: \n";
    for(int i = 0; i < boardHeight; i++){
        for(int j = 0; j < boardWidth; j++){
            cout << crke[j] << (boardHeight - i) << " ";  
        }
        cout << "\n";
    }
    cout << "\n";
}

int main(){
    int step = 1;
    int premiki[boardHeight][boardWidth] = {0};

    //izris sahovnice
    drawBoard();

    //vpis zacetne pozicije na sahovnici
    char colInput;
    int rowInput;
    cout << "Vpisite stolpec (a-h): ";
    cin >> colInput;
    cout << "Vpisite vrstico (1-8): ";
    cin >> rowInput;

    //stolpec - crka   
    int col = 0;
    for(int i = 0; i < 26; i++){
        if(crke[i] == colInput){
            col = i;
        }
    }

    //vrstica - stevilka
    int row = 0;
    if(rowInput > 0 && rowInput <= boardHeight) row = boardHeight - rowInput;

    cout << "Zacetna pozicija: (" << row + 1 << ". vrstica, " << col + 1 << ". stolpec) = " << colInput << rowInput << "\n";

    //rekurzivni skoki viteza
    knightsTour(premiki, row, col, step);

    //izpis potez na sahovnici
    outputMoves(premiki);
    cout << "Stevilo skokov: " << step - 1 << "\n";
}
