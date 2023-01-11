const prompt = require("prompt-sync")({ sigint: true })

let squareSize = prompt("What size do you want?")

let count = 1
let squareArray1 = []
let output1 = ""

//inline
for (let i = 0; i < squareSize; i++) {
    squareArray1[i] = []
    for (let j = 0; j <= squareSize - 1; j++) {
        squareArray1[i][j] = count
        count++
    }
    output1 += squareArray1[i] + "\n";
}
console.log(output1);


//in column
let squareArray2 = []
let output2 = ""
for (let i = 0; i < squareSize; i++) {
    squareArray2[i] = []
    squareArray2[i] = count
    count++
    j++
}
console.log(squareArray2)


