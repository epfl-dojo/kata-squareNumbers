# Kata Square Number (Carré de chiffres)

Kata : remplir un carré de chiffres organisés en lignes, colonnes et spirale.

<!-- start:apropos -->
> **À propos**
>
> ⓘ Ceci est la donnée d'un [kata], un _exercice de programmation_ qui se
> déroule généralement dans le cadre d'un [coding dojo]. Il est proposé aux
> membres du dojo de l'[EPFL] et fait partie d'une collection de différents
> katas identifiés par le tag **[epfl-dojo-kata]** sur GitHub.  
> Vous êtes plus que bienvenu·e d'essayer de le réaliser dans le langage de
> programmation de votre choix. Lorsque c'est terminé, ajoutez-vous à la liste
> de ceux qui l'ont fait dans ce document en proposant une [Pull Request]. Vous
> pouvez également partager votre intérêt pour ce dépôt en
> le «[stargazant]», c'est à dire en lui ajoutant une ⭐.  
> Bonne lecture et bon code !

[kata]: https://fr.wikipedia.org/wiki/Coding_dojo#Kata
[coding dojo]: https://fr.wikipedia.org/wiki/Coding_dojo
[EPFL]: https://www.epfl.ch
[epfl-dojo-kata]: https://github.com/topics/epfl-dojo-kata
[Pull Request]: https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests
[stargazant]: https://docs.github.com/en/get-started/exploring-projects-on-github/saving-repositories-with-stars
<!-- end:apropos -->

## But

Cet exercice permet de travailler les boucles dans le langage de votre choix.


## Comment procéder

[Forker](https://github.com/epfl-dojo/kata-squareNumbers/#fork-destination-box)
le repo et créer une branche (`git checkout -b username-langage` par exemple
`git checkout -b ponsfrilus-nodejs`, depuis votre fork). Faire ensuite une pull
request pour l'ajouter à ce repo en vous ajoutant comme contributeurs en bas de
ce fichier.


## Problème

Générer un carré de chiffres en lignes, colonnes et spirale. L'utilisateur doit
entrer la taille du carré. Le programme affichera les trois versions (lignes,
colonnes, spirale), selon exemples ci-dessous.

  * L'utilisateur peut entrer que des chiffres (gestion de l'input/message
    d'erreur);
  * Les nombres doivent être préfixés d'autant de 0 que nécessaire (e.g. 001 →
    100);
  * Les trois carrés de chiffres doivent être affichés.

### - en lignes
```
 3x3          5x5
1 2 3    01 02 03 04 05
4 5 6    06 07 08 09 10
7 8 9    11 12 13 14 15
         16 17 18 19 20
         21 22 23 24 25
```

### - en colonnes
```
 3x3          5x5
1 4 7    01 06 11 16 21
2 5 8    02 07 12 17 22
3 6 9    03 08 13 18 23
         04 09 14 19 24
         05 10 15 20 25
```

### - en spirale
```
 3x3          5x5
7 8 9    21 22 23 24 25
6 1 2    20 07 08 09 10
5 4 3    19 06 01 02 11
         18 05 04 03 12
         17 16 15 14 13
```


## Contributeurs (langages par ordre alphabétique)

* [python](./squareNumbers.py) → [@epfl-dojo](https://github.com/epfl-dojo)
* [c++](./squareNumbers.cpp) → [@richmartins](https://github.com/richmartins)
* [c#](./squareNumbers.cs) → [@saphirevert](https://github.com/saphirevert)
* [PHP](./squareNumbers.php) → [@epfl-dojo](https://github.com/epfl-dojo)
