# Couteau Suisse

Programme console écrit en C# permettant de convertir du texte en code Morse.
Le programme propose également plusieurs conversions entre bases numériques.

## Fonctionnalités

- Convertir une lettre, un mot ou une phrase en code Morse.
- Convertir un nombre décimal en binaire.
- Convertir un nombre binaire en décimal ou en octal.
- Convertir un nombre octal en binaire.
- Convertir un nombre hexadécimal en décimal.
- Sauvegarder une réponse Morse dans `reponseMorse.txt`.
- Encoder un message secret dans un texte à l'aide de caractères invisibles.
- Décoder un message secret depuis `messageEncode.txt`.

## Prérequis

- .NET 9.0 SDK

## Lancer le programme

Depuis la racine du dépôt (`Couteau-Suisse`), exécuter :

```bash
dotnet run --project .\morse\morse.csproj
```

Si le terminal est déjà dans le dossier `morse`, exécuter :

```bash
dotnet run --project .\morse.csproj
```

Puis choisir une option dans le menu affiché dans la console.

## Stéganographie

L'option `3. Stéganographie` propose deux opérations :

- Encoder un message secret composé de lettres et d'espaces dans un message porteur.
- Décoder le message secret contenu dans `messageEncode.txt`.

Lors de l'encodage, le résultat peut être sauvegardé dans `messageEncode.txt`.
Le message secret est converti en Morse puis représenté avec des caractères invisibles.

## Exemple

```text
Entrée : SOS
Sortie : ... --- ...
```

## Exemples de conversions entre bases

```text
Décimal 10       → Binaire    1010
Binaire 1010     → Décimal    10
Binaire 1010     → Octal      12
Octal 12         → Binaire    1010
Hexadécimal A    → Décimal    10
```

## Documentation

Les étapes de conception et les algorithmes du projet sont disponibles dans le
dossier `docs/` :

- `pseudocode-partie1.md` : conversion de texte en code Morse.
- `pseudocode-partie2.md` : conversions entre bases numériques.
- `pseudocode-partie3.md` : encodage stéganographique.
