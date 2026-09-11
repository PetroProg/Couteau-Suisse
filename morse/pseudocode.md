# Convertisseur de texte en code Morse

## Objectif

Convertir une lettre, un mot ou une phrase saisie par l'utilisateur en code
Morse, puis afficher le résultat à l'écran.

## Données utilisées

- `tableauLettres` : alphabet de `A` à `Z`.
- `tableauMorse` : code Morse correspondant à chaque lettre de
  `tableauLettres`.
- `texteEntree` : texte saisi par l'utilisateur.
- `texteRetour` : code Morse construit progressivement.
- `\\` : séparateur entre deux mots.

## Algorithme principal

```text
DEBUT

    choix <- 'O'

    TANT QUE choix vaut 'O' ou 'o' FAIRE
        AFFICHER "=== Convertisseur du texte en Morse ==="
        AFFICHER "Entrez un mot ou une phrase (sans accents, lettres A-Z) :"

        LIRE texteEntree
        texteRetour <- TransformerEnMorse(texteEntree)

        AFFICHER "Le code Morse correspondant est : " + texteRetour
        AFFICHER "Voulez-vous convertir un autre texte ? (O/N) :"
        LIRE choix
    FIN TANT QUE

FIN
```

## Fonction de conversion

```text
FONCTION TransformerEnMorse(texteEntree)
    texteRetour <- ""
    texteEntree <- convertir texteEntree en majuscules

    POUR chaque caractere dans texteEntree FAIRE
        index <- rechercher caractere dans tableauLettres

        SI index >= 0 ALORS
            texteRetour <- texteRetour + tableauMorse[index] + " "
            SINON SI caractere vaut `/` ALORS
                texteRetour <- texteRetour + " / "
        FIN SI
    FIN POUR

    RETOURNER texteRetour
FIN FONCTION
```

## Exemple

```text
Entrée  : SOS
Sortie  : ... --- ...
```
