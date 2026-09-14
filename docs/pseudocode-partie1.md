# Convertisseur de texte en code Morse

## Objectif

Convertir une lettre, un mot ou une phrase saisie par l'utilisateur en code
Morse, afficher le résultat et proposer sa sauvegarde dans un fichier.

## Données utilisées

- `tabLettres` : alphabet de `A` à `Z`.
- `tabMorse` : code Morse correspondant à chaque lettre de `tabLettres`.
- `strInput` : texte saisi par l'utilisateur.
- `strMorseCode` : code Morse construit progressivement.
- `/` : séparateur entre deux mots.

## Algorithme principal

```text
DEBUT
    choix <- ' '

    REPETER
        EFFACER l'écran
        AFFICHER "=== Couteau Suisse - Utilitaires ==="
        AFFICHER "1. Convertir du texte en code Morse"
        AFFICHER "2. Convertir des nombres entre différentes bases"
        AFFICHER "3. En production"
        LIRE choix

        SELON choix FAIRE
            CAS '1' :
                AFFICHER "Entrez un mot ou une phrase (sans accents, lettres A-Z) :"
                LIRE texteEntree
                texteEntree <- RemplacerLesEspaces(texteEntree)
                texteRetour <- TransformerEnMorse(texteEntree)

                AFFICHER "Le code Morse correspondant est : " + texteRetour
                SauvegarderReponse(texteRetour)

            CAS '2' :
                // Les conversions entre bases sont traitées dans la partie 2.
                AFFICHER le sous-menu des conversions numériques

            CAS '3' :
                AFFICHER "En production"

            SINON :
                AFFICHER "Choix invalide."
        FIN SELON

        AFFICHER "Voulez-vous continuer ? (O/N) :"
        LIRE choix
    JUSQU'À ce que choix soit différent de 'O' et de 'o'
FIN
```

## Fonction de traitement des espaces

```text
FONCTION RemplacerLesEspaces(texteEntree)
    SI texteEntree contient un espace ALORS
        mots <- séparer texteEntree sur les espaces
        supprimer les éléments vides de mots
        texteEntree <- assembler mots avec `/`
    FIN SI

    RETOURNER texteEntree
FIN FONCTION
```

## Fonction de conversion

```text
FONCTION TransformerEnMorse(texteEntree)
    texteRetour <- ""
    texteEntree <- convertir texteEntree en majuscules

    POUR chaque caractere dans texteEntree FAIRE
        index <- rechercher caractere dans tabLettres

        SI index >= 0 ALORS
            texteRetour <- texteRetour + tabMorse[index] + " "
        SINON SI caractere vaut `/` ALORS
            texteRetour <- texteRetour + " / "
        FIN SI
    FIN POUR

    RETOURNER texteRetour
FIN FONCTION
```

## Fonction de sauvegarde

```text
FONCTION SauvegarderReponse(texteRetour)
    cheminFichier <- "reponseMorse.txt"

    AFFICHER "Voulez-vous sauvegarder le code Morse dans un fichier ? (O/N) :"
    LIRE choix

    SI choix vaut 'O' ou 'o' ALORS
        SI le fichier n'existe pas ALORS
            écrire texteRetour dans le fichier
        SINON
            ajouter texteRetour et un retour à la ligne à la fin du fichier
        FIN SI
    FIN SI
FIN FONCTION
```

## Exemple

```text
Entrée  : SOS
Sortie  : ... --- ...
```
