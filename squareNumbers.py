#!/usr/local/bin/python3
import sys

if sys.argv[1] == "--size":
    size = int(sys.argv[2])
else:
    try:
        size=int(input('Square size:'))
    except ValueError:
        print ("Not a number")

def max_base10_size(max_n):
    return len(str(max_n))

squared_size = size*size

def print_list(list):
    print_string = ""
    for i in list:
        print_string += ' ' + str(i).rjust(max_base10_size(squared_size), '0')
        if i%size == 0:
            print_string += "\n"
    return print(print_string)

def print_array(arr):
    length = max_base10_size(squared_size)
    for line in arr:
        print_string = ""
        for item in line:
            print_string += " "
            if item is None:
                print_string += "-" * length
            else:
                print_string += str(item).rjust(max_base10_size(squared_size), '0')
        print(print_string)


def inline(size):
    inline_list = [x+1 for x in range(squared_size)]
    print_list(inline_list)

def vertical(size):
    numbers = [[None for i in range(size)] for j in range(size)]
    current = 1
    for i in range(size):
        for j in range(size):
            numbers[j][i] = current
            current+=1
    print_array(numbers)



def spiral(size):
    numbers = [[None for i in range(size)] for j in range(size)]
    current = squared_size
    i = 0
    j = size-1
    di = 0
    dj = -1

    while(current >1):
        while (True):
        #while ( i >= 0 and i < size and j>= 0 and j<size):
            numbers[i][j] = current
            if (current == 1): break

            newi = i + di
            newj = j + dj
            if newi >= 0 and newi < size and newj>= 0 and newj < size and numbers[newi][newj] is None:
                i = newi
                j = newj
                current -= 1
            else:
                break

        di,dj = turn(di, dj)
    print_array(numbers)

def turn(di, dj):
    if di==0 and dj==-1:
        dj = 0
        di = 1
    elif di == 1 and dj == 0:
        di = 0
        dj = 1
    elif di == 0 and dj == 1:
        di = -1
        dj = 0
    else:
        di = 0
        dj = -1
    return di, dj
inline(size)
vertical(size)
print()
spiral(size)
