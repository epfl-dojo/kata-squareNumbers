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

using namespace std;

int row(int n);    // done
int column(int n); // done
int spiral(int n); // WIP

int main(int argc, char** argv) {
    if (argc >= 1 && stoi(argv[1])) {
        int n = stoi(argv[1]);
        // row(n);
        // column(n);
        spiral(n);
    } else {
        cout << "You must pass an argument and it should be an integer"
             << endl;
    }

    return EXIT_SUCCESS;
}

int row(int n){
    cout << "row: " << n << " * " << n << endl;

    int tot = n * n;
    int curr = n;

    for (int i = 1; i <= tot; ++i){
        cout << setw(2) << setfill('0') << i << " ";
        if (i == curr){
            curr += n;
            cout << endl;
        }
    }

    return 0;
}

int column(int n){

    cout << "column: " << n << " * " << n << endl;

    int tot = n * n;
    int counter = n;

    for(int i = 1; i <= n; ++i){
        cout << setw(2) << setfill('0') << i << " ";
        int curr = i;
        for(int j = 1; j < counter; ++j){
            curr += n;
            cout << setw(2) << setfill('0') << curr << " ";
        }
        cout << endl;
    }

    return 0;
}

/*
 * TODO: make it work lol
 */

int spiral(int n){
    int square = n * n;

    int matrice[n][n];

    // create matrice
    for(int i = 1; i <= n; ++i){
        for (int j = 1; j <= n; ++j){
            matrice[i][j] = 0;
        }
    }




    // print matrice
    for(int i = 1; i <= n; ++i){
        for (int j = 1; j <= n; ++j){
            cout << setw(2) << setfill('0') << matrice[i][j] << " ";
        }
        cout << endl;
    }

    return 0;
}
