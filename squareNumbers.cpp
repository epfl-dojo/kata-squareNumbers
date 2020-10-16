/*
 * -----------------------------------------------------------------
 * author      : Richard Tenorio
 * date        : 2020-10-15
 * description : Read the README.md file
 * compiler    : g++ Apple clang version 12.0.0 (clang-1200.0.32.2)
 * flags       : -DCMAKE_CXX_FLAGS="-Wall -Wextra -Wconversion
 *               -Wsign-conversion -pedantic"
 * -----------------------------------------------------------------
 */

#include <iostream> // cout, cin etc..
#include <cstdlib>  // EXIT_SUCCESS
#include <iomanip>  // setw, setfill
#include <cmath>    // log10

using namespace std;

int row(int n, int nbDigits);    // done
int column(int n, int nbDigits); // done
int spiral(int n, int nbDigits); // WIP
int * turn(int dx, int dy);

int main(int argc, char** argv) {
    if (argc >= 1 && stoi(argv[1])) {
        int n = stoi(argv[1]);
        int nbDigits = (int)log10((n*n))+1; //get number of digits of square n

        row(n,nbDigits);
        column(n, nbDigits);
        spiral(n, nbDigits);

    } else {
        cout << "You must pass an argument and it should be an integer"
             << endl;
    }

    return EXIT_SUCCESS;
}

int row(int n, int nbDigits){
    cout << "row: " << n << " * " << n << endl;

    int tot = n * n;
    int curr = n;

    for (int i = 1; i <= tot; ++i){
        cout << setw(nbDigits) << setfill('0') << i << " ";
        if (i == curr){
            curr += n;
            cout << endl;
        }
    }

    cout << endl;
    return 0;
}

int column(int n, int nbDigits){

    cout << "column: " << n << " * " << n << endl;

    int tot = n * n;
    int counter = n;

    for(int i = 1; i <= n; ++i){
        cout << setw(2) << setfill('0') << i << " ";
        int curr = i;
        for(int j = 1; j < counter; ++j){
            curr += n;
            cout << setw(nbDigits) << setfill('0') << curr << " ";
        }
        cout << endl;
    }

    cout << endl;
    return 0;
}

/*
 * TODO: make it work lol
 */

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
    int dy = -1;

    for(int i = square; i > 0; --i){

        int new_x = x + dx;
        int new_y = y + dy;

        if(new_x >= 0 && new_x < n && new_y >= 0 && new_y < n && ! (matrice[new_y][new_x])){
            x = new_x;
            y = new_y;
        } else {
            int *res = turn(dx, dy);
            dx = res[0];
            dy = res[1];

            x = x + dx;
            y = y + dy;
        }
        // for(int line : matrice[]){
            // for(int value : line){

            // }
        // }
    }


    // print matrice
    for(int i = 0; i < n; ++i){
        for (int j = 0; j < n; ++j){
            cout << setw(2) << setfill('0') << matrice[i][j] << " ";
        }
        cout << endl;
    }

    cout << endl;
    return 0;
}

int * turn(int dx, int dy){
    if(dx == 0 && dy == -1){
        dx = -1;
        dy = 0;
    } else if (dx == 1 && dy == 0){
        dx = 0;
        dy = -1;
    } else if (dx == 0 && dy == 1){
        dx = 1;
        dy = 0;
    } else if (dx == -1 && dy == 0){
        dx = 0;
        dy = 1;
    } else {
        cout << "prout" <<  endl;
    }

    int res[2];
    res[0] = dx;
    res[1] = dy;

    return res;
}
