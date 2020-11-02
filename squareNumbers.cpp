/*
 * -----------------------------------------------------------------
 * author      : Richard Tenorio
 * date        : 2020-10-15
 * description : Read the README.md file
 * compiler    : gcc version 10.2.0 (Homebrew GCC 10.2.0)
 * flags       : -DCMAKE_CXX_FLAGS="-Wall -Wextra -Wconversion
 *               -Wsign-conversion -pedantic"
 * -----------------------------------------------------------------
 */

#include <iostream> // cout, cin etc..
#include <cstdlib>  // EXIT_SUCCESS
#include <iomanip>  // setw, setfill
#include <cmath>    // log10

using namespace std;

int row(int n, int nbDigits);
int column(int n, int nbDigits);
int spiral(int n, int nbDigits);
void turn(int& dx, int& dy);

int main(int argc, char** argv) {

    if (argc >= 1 && argv[1] != NULL){
        int n;
        try {
            n = stoi(argv[1]);
        } catch(invalid_argument& e){
            cout << "you must pass an integer as argument";
            return EXIT_FAILURE;
        }catch(out_of_range& e){
            cout << "the integer passed was too long";
            return EXIT_FAILURE;
        }

        int nbDigits = (int)log10((n*n))+1; //get number of digits n squared

        row(n,nbDigits);
        column(n, nbDigits);
        spiral(n, nbDigits);

   } else {
       cout << "You must pass an integer as argument to run this program"
            << endl;
   }

    return EXIT_SUCCESS;
}

int row(int n, int nbDigits){
    cout << "row: " << n << " * " << n << endl;

    int squared = n * n;

    for (int i = 1; i <= squared; ++i){
        cout << setw(nbDigits) << setfill('0') << i << " ";
        if(i % n == 0){
            cout << endl;
        }
    }

    cout << endl;
    return EXIT_SUCCESS;
}

int column(int n, int nbDigits){

    cout << "column: " << n << " * " << n << endl;

    int counter = n;

    for(int i = 1; i <= n; ++i){
        cout << setw(nbDigits) << setfill('0') << i << " ";
        int curr = i;
        for(int j = 1; j < counter; ++j){
            curr += n;
            cout << setw(nbDigits) << setfill('0') << curr << " ";
        }
        cout << endl;
    }

    cout << endl;
    return EXIT_SUCCESS;
}

int spiral(int n, int nbDigits){
    int square = n * n;

    int matrice[n][n];
    cout << "spiral: " << n << " * " << n << endl;

    // create matrice
    for(int i = 0; i < n; ++i){
        for (int j = 0; j < n; ++j){
            matrice[i][j] = 0;
        }
    }

    int x = n - 1;
    int y = 0;

    int dx = -1;
    int dy = 0;

    int new_x;
    int new_y;


    for(int current = square; current > 0; --current){
        matrice[y][x] = current;

        new_x = x + dx;
        new_y = y + dy;

        if(new_x >= 0
           && new_x < n
           && new_y >= 0
           && new_y < n
           && !matrice[new_y][new_x]){

            x = new_x;
            y = new_y;

        } else {
            turn(dx, dy);
            x = x + dx;
            y = y + dy;
        }
    }

    // print matrice
    for(int i = 0; i < n; ++i){
        for(int j = 0; j < n; ++j){
            cout << setw(nbDigits) << setfill('0') << matrice[i][j] << " ";
        }
        cout << endl;
    }
    cout << endl;
    return EXIT_SUCCESS;
}

void turn(int& dx, int& dy){
    if (dx == 0 && dy == -1) {            // UP
        dx = -1;                               // LEFT
        dy = 0;
    } else if (dx == 1 && dy == 0) {       // RIGHT
        dx = 0;                                // UP
        dy = -1;
    } else if (dx == 0 && dy == 1) {       // DOWN
        dx = 1;                                // RIGHT
        dy = 0;
    } else if(dx == -1 && dy == 0) {       // LEFT
        dx = 0;                                // DOWN
        dy = 1;
    } else {
        cout << "prout" << endl;
    }
}

