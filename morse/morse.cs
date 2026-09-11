using System;
using System.IO;

namespace Morse
{
    class MorseCodeConverter
    {
        static void Main(string[] args)
        {
            // Déclaration des variables
            char chrChoix = ' ';  // Variable pour stocker le choix de l'utilisateur
            string strInput = ""; // Variable pour stocker le texte saisi par l'utilisateur
            string strMorseCode = "";  // Variable pour stocker le code Morse correspondant
            
            // Boucle principale pour permettre à l'utilisateur de convertir plusieurs textes
            do{
                Console.WriteLine("=== Convertisseur du texte en Morse ===");
                Console.Write("Entrez un mot ou une phrase (sans accents, lettres A-Z) : ");

                // Lecture de l'entrée utilisateur
                strInput = Console.ReadLine() ?? string.Empty;

                // Remplace les espaces entre les mots par un séparateur visible
                strInput = VerifySpaces(strInput);

                // Conversion du texte en code Morse via une méthode dédiée
                strMorseCode = ConvertToMorse(strInput);

                // Affichage du code Morse correspondant
                Console.WriteLine("Le code Morse correspondant est : " + strMorseCode);
                Console.WriteLine();

                // Option pour sauvegarder le code Morse dans un fichier
                SaveResponseToFile(strMorseCode);
                
                // Demande à l'utilisateur s'il souhaite convertir un autre texte
                Console.Write("Voulez-vous convertir un autre texte ? (O/N) : ");
                chrChoix = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            while (chrChoix == 'O' || chrChoix   == 'o');
        }  
        
        static string VerifySpaces (string strInput)
        {
            // Vérifie si l'entrée utilisateur contient des espaces
            if (strInput.Contains(" "))
            {
                string[] strMots = strInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                strInput = string.Join("/", strMots);
            }
            return strInput;
        }
        
        // Méthode pour convertir un texte en code Morse
        static string ConvertToMorse(string strInput)
        {
            // Définition des lettres et de leur correspondance en code Morse
            char[] tabLettres =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z'
            };

            // Correspondance des lettres avec le code Morse
            string[] tabMorse =
            {
                ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---",
                "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-",
                "..-", "...-", ".--", "-..-", "-.--", "--.."
            };

            string strReponse = ""; // Variable pour stocker le code Morse final

            // Conversion de l'entrée utilisateur en majuscules
            strInput = strInput.ToUpperInvariant();

            // Parcours de chaque caractère de l'entrée utilisateur
            for (int i = 0; i < strInput.Length; i++)
            {
                char c = strInput[i];
                int intLettreIndex = Array.IndexOf(tabLettres, c); // Recherche de l'index de la lettre dans le tableau 'tabLettres'

                if (intLettreIndex >= 0)
                {
                    strReponse += tabMorse[intLettreIndex] + " ";
                }
                else if (c == '/')  // Vérifie si le caractère est un séparateur de mots
                {
                    strReponse += " / ";
                }
            }
            return strReponse;
        }   

        static void SaveResponseToFile(string strMorseCode)
        {
            string strFilePath = @"E:\Modules\I114\Projet\reponseMorse.txt"; // Définition du chemin du fichier de sortie

            Console.WriteLine("Voulez-vous sauvegarder le code Morse dans un fichier ? (O/N) : ");
            char chrChoix = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Pour passer à la ligne suivante

            if (chrChoix == 'O' || chrChoix == 'o' && File.Exists(strFilePath) == false)
            {
                // Écriture du code Morse dans le fichier
                File.WriteAllText(strFilePath, strMorseCode);
            }
            else if (chrChoix == 'O' || chrChoix == 'o' && File.Exists(strFilePath) == true)
            {
                // Si le fichier existe déjà, on ajoute le code Morse à la fin du fichier existant
                File.AppendAllText(strFilePath, strMorseCode + Environment.NewLine);
            }
        }  
    }
}

