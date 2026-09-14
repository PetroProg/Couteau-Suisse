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

## Prérequis

- .NET 9.0 SDK

## Lancer le programme

Depuis le dossier du projet, exécuter :

```bash
dotnet run --project morse/morse.csproj
```

Puis choisir une option dans le menu affiché dans la console.

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
