DEBUT ConvertirDecimalVersBinaire(nombreEntree)
    // La méthode reçoit un entier non signé et renvoie une chaîne de caractères.

    SI nombreEntree = 0 ALORS
        RETOURNER "0"
    FIN SI

    resultatBinaire <- ""
    trouverUn <- FAUX

    // Parcourir les puissances de 2 de 2^31 à 2^0.
    POUR indice DE 31 A 0 AVEC UN PAS DE -1 FAIRE
        puissance <- 2^indice
        bit <- nombreEntree DIV puissance

        SI bit = 1 ALORS
            trouverUn <- VRAI
        FIN SI

        // Ne pas ajouter les zéros situés avant le premier 1.
        SI trouverUn = VRAI ALORS
            resultatBinaire <- resultatBinaire + bit
            nombreEntree <- nombreEntree MOD puissance
        FIN SI
    FIN POUR

    RETOURNER resultatBinaire
FIN ConvertirDecimalVersBinaire
        