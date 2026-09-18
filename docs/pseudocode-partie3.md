FONCTION Encoder (textePorteur, messageSecret)
    messageSecret := MettreEnMajuscules(messageSecret)
    SI NON ValiderCaracteres(messageSecret) ALORS
        AFFICHER "Erreur : Caractères non autorisés dans le message secret"
        RETOURNER ""
    FIN SI

    texteMorse := ConvertirEnMorse(messageSecret)
    chaineInvisible := MorseVersUnicode(texteMorse)

    SI Longueur(textePorteur) < Longueur(chaineInvisible) ALORS
        AFFICHER "Erreur : Texte porteur trop court"
        RETOURNER ""
    FIN SI

    resultat := ""
    POUR i DE 0 A Longueur(textePorteur) - 1
        resultat := resultat + textePorteur[i]
        SI i < Longueur(chaineInvisible) ALORS
            resultat := resultat + chaineInvisible[i]
        FIN SI
    FIN POUR

    RETOURNER resultat
FIN FONCTION