const squareSize = process.argv.slice(2)

//inline
let count1 = 1
let squareArray1 = []
let output1 = ""
for (let i = 0; i < squareSize; i++) {
    squareArray1[i] = []
    for (let j = 0; j < squareSize; j++) {
        squareArray1[i][j] = count1
        count1++
    }
    output1 += squareArray1[i] + "\n"
}
console.log(output1);


//in column
let count2 = 1
let squareArray2 = []
let output2 = ""
for (let i = 0; i < squareSize; i++) {
    squareArray2[i] = []
}
for (let i = 0; i < squareSize; i++) {
    for (let j = 0; j < squareSize; j++) {
        squareArray2[j][i] = count2
        count2++
    }
}

for (let i = 0; i < squareSize; i++) {
    output2 += squareArray2[i] + "\n"
}
console.log(output2)


//spiral

let i = 0
let j = 0
function droite(vecteurD) {
    squareArray3[j] = squareArray3[j + 1]
}

function bas(vecteurB) {
    squareArray3[i] = squareArray3[i + 1]
}

function gauche(vecteurG) {
    squareArray3[j] = squareArray3[j - 1]
}

function haut(vecteurH) {
    squareArray3[i] = squareArray3[i + 1]
}

let squareArray3 = []
for (i = 0; i < squareSize; i++) {
    squareArray3[i] = []
    for (j = 0; j < squareSize; j++) {
        squareArray3[i][j] = 'x'
    }
    console.log(squareArray3[i])
}



