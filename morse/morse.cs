using System;
using System.IO;

namespace Morse
{
    class MorseCodeConverter
    {
        static void Main(string[] args)
        {
            // Déclaration des variables
            char chrChoix = ' ';  // Variable pour stocker les choix de l'utilisateur
            
            string strInput = ""; // Variable pour stocker le texte saisi par l'utilisateur
            string strMorseCode = "";  // Variable pour stocker le code Morse correspondant
            string strBinary = ""; // Variable pour stocker le nombre binaire saisi par l'utilisateur
            string strBinaryInput = ""; // Variable pour stocker le nombre binaire saisi par l'utilisateur
            
            uint uintDecimal = 0; // Variable pour stocker le nombre décimal saisi par l'utilisateur
            uint uintBinaireToDecimal = 0; // Variable pour stocker le nombre décimal converti à partir du binaire

            
            // Boucle principale pour permettre à l'utilisateur de convertir plusieurs textes
            do{
                Console.Clear(); // Efface la console pour une meilleure lisibilité

                // Affichage du menu principal
                Console.WriteLine("=== Couteau Suisse - Utilitaires ===");
                Console.WriteLine("1. Convertir du texte en code Morse");
                Console.WriteLine("2. Convertir des nombres entre différentes bases (Décimal <> Binaire <> Octal)");
                Console.WriteLine("3. En production");
                Console.Write("Veuillez entrer votre choix : ");

                // Lecture du choix de l'utilisateur
                chrChoix = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine("==========================================================");
                // Traitement du choix de l'utilisateur
                switch (chrChoix)
                {
                    case '1':
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
                        break;
                    case '2':
                            Console.WriteLine("1. Décimal > Binaire");
                            Console.WriteLine("2. Binaire > Décimal");
                            Console.WriteLine("3. Binaire > Octal");
                            Console.WriteLine("4. Octal > Binaire");
                            Console.Write("Veuillez entrer votre choix : ");
                            chrChoix = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                                switch (chrChoix)
                                {
                                    case '1':
                                        Console.Write("Entrez un nombre décimal : ");
                                        uintDecimal = Convert.ToUInt32(Console.ReadLine());
                                        strBinary = ConvertDecimalToBinary(uintDecimal);
                                        Console.WriteLine("Le nombre binaire correspondant est : " + strBinary);
                                        break;
                                    case '2':
                                        Console.Write("Entrez un nombre binaire : ");
                                        strBinaryInput = Console.ReadLine();
                                        uintBinaireToDecimal = ConvertBinaryToDecimal(strBinaryInput);
                                        Console.WriteLine("Le nombre décimal correspondant est : " + uintBinaireToDecimal);
                                        break;
                                    case '3':
                                        Console.Write("Entrez un nombre binaire : ");
                                        break;
                                    case '4':
                                        Console.Write("Entrez un nombre octal : ");
                                        break;
                                    default:
                                        Console.WriteLine("Choix invalide.");
                                        break;
                                }
                            break;
                    case '3':
                        Console.WriteLine("En production");
                        break;

                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }

                

               
                
                // Demande à l'utilisateur s'il souhaite convertir un autre texte
                Console.Write("Voulez-vous continuer ? (O/N) : ");
                chrChoix = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            while (chrChoix == 'O' || chrChoix   == 'o');
        }  

        // Méthode pour vérifier et traiter les espaces dans l'entrée utilisateur
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

        // Méthode pour sauvegarder le code Morse dans un fichier
        static void SaveResponseToFile(string strMorseCode)
        {
            string strFilePath = @"E:\Modules\I114\Projet\Codification-du-Morse\reponseMorse.txt"; // Définition du chemin du fichier de sortie

            Console.Write("Voulez-vous sauvegarder le code Morse dans un fichier ? (O/N) : ");
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

        // Méthode pour convertir un nombre décimal en binaire
        static string ConvertDecimalToBinary(uint uintDecimal)
        {
            if (uintDecimal == 0) return "0";

            string strResultatBinaire = "";
            bool boolTrouverUn = false;

            // Parcours des bits de 31 à 0 pour construire la représentation binaire
            for (int i = 31; i >= 0; i--)
            {
                uint uintPuissance = (uint)Math.Pow(2, i); 
                uint uintBit = uintDecimal / uintPuissance;

                if (uintBit == 1)
                {
                    boolTrouverUn = true;
                }

                if (boolTrouverUn)
                {
                    strResultatBinaire += uintBit;
                    uintDecimal %= uintPuissance; 
                }
            }

            return strResultatBinaire;
        }

        static uint ConvertBinaryToDecimal(string strBinaryInput)
        {
            uint uintDecimalResult = 0;
            byte bytLength = (byte)strBinaryInput.Length;
            
            for (int i = 0; i < bytLength; i++)
            {
                if (strBinaryInput[bytLength - 1 - i] == '1')
                {
                    uintDecimalResult += (uint)Math.Pow(2, i);
                }
                else if (strBinaryInput[bytLength - 1 - i] == '0')
                {
                    // Ne rien faire, le bit est déjà à 0
                }
                else
                {
                    Console.WriteLine("Erreur : Le nombre binaire contient un caractère non valide.");
                    return 0;
                }
            }

            return uintDecimalResult;
        }
    }
}

