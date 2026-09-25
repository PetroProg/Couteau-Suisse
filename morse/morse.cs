/****************************************************************************************************************************************************************************
* Programme morse.cs                                                                                                                                                        *     
*                                                                                                                                                                           *     
* Lieu   : ETML - section informatique                                                                                                                                      *     
* Auteur : Petro Maltsev                                                                                                                                                    *     
* Date   : 18.09.25                                                                                                                                                         *     
*                                                                                                                                                                           *     
* Modifications                                                                                                                                                             *     
*    Auteur  :                                                                                                                                                              *     
*    Version :                                                                                                                                                              *     
*    Date    :                                                                                                                                                              *     
*    Raisons :                                                                                                                                                              *     
*                                                                                                                                                                           *                                                                                                                                                                           *                  
* **************************************************************************************************************************************************************************/

/****************************************************************************************************************************************************************************
* DESCRIPTION                                                                                                                                                               *
*                                                                                                                                                                           *
* Le programme permet de convertir du texte en code Morse et vice-versa.                                                                                                    *
* Aussi, il permet de convertir vers differentes bases numeriques.                                                                                                          *
****************************************************************************************************************************************************************************/
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Morse
{
    class MorseCodeConverter
    {
        static void Main(string[] args)
        {
            // Déclaration des variables
            char chrChoix = ' ';  // Variable pour stocker les choix de l'utilisateur

            string strHexInput = ""; // Variable pour stocker le nombre hexadecimal saisi par l'utilisateur
            string strInput = ""; // Variable pour stocker le texte saisi par l'utilisateur
            string strMorseCode = "";  // Variable pour stocker le code Morse correspondant
            string strBinary = ""; // Variable pour stocker le nombre binaire saisi par l'utilisateur
            string strOctal = ""; // Variable pour stocker le nombre octal saisi par l'utilisateur
            string strBinaryInput = ""; // Variable pour stocker le nombre binaire saisi par l'utilisateur
            string strMessage = ""; // Variable pour stocker le message saisi par l'utilisateur
            string strMsgSecret = ""; // Variable pour stocker le message secret saisi par l'utilisateur
            
            uint uintDecimal = 0; // Variable pour stocker le nombre décimal saisi par l'utilisateur
            uint uintBinaireToDecimal = 0; // Variable pour stocker le nombre décimal converti à partir du binaire
            uint uintHexToDecimal = 0; // Variable pour stocker le nombre décimal converti à partir de l'hexadecimal

            // Boucle principale pour permettre à l'utilisateur de convertir plusieurs textes
            do{
                Console.Clear(); // Efface la console pour une meilleure lisibilité

                // Affichage du menu principal
                Console.WriteLine("=== Couteau Suisse - Utilitaires ===");
                Console.WriteLine("1. Convertir du texte en code Morse");
                Console.WriteLine("2. Convertir des nombres entre différentes bases (Décimal <> Binaire <> Octal)");
                Console.WriteLine("3. Stéganographie");
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
                            Console.WriteLine("5. Hexadecimal > Décimal");
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
                                        strBinaryInput = Console.ReadLine();
                                        strOctal = ConvertBinaryToOctal(strBinaryInput);
                                        Console.WriteLine("Le nombre octal correspondant est : " + strOctal);
                                        break;
                                    case '4':
                                        Console.Write("Entrez un nombre octal : ");
                                        strOctal = Console.ReadLine();
                                        strBinary = ConvertOctalToBinary(strOctal);
                                        Console.WriteLine("Le nombre binaire correspondant est : " + strBinary);
                                        break;
                                    case '5':
                                        Console.Write("Entrez un nombre hexadecimal : ");
                                        strHexInput = Console.ReadLine();
                                        uintHexToDecimal = ConvertHexadecimalToDecimal(strHexInput);
                                        Console.WriteLine("Le nombre décimal correspondant est : " + uintHexToDecimal);
                                        break;
                                    default:
                                        Console.WriteLine("Choix invalide.");
                                        break;
                                }
                            break;
                    case '3':
                        Console.WriteLine("Stéganographie");
                        Console.Write("Entrez le message : ");
                        strMessage = Console.ReadLine() ?? string.Empty;
                        
                        Console.Write("Entrez le message secret : ");
                        strMsgSecret = Console.ReadLine() ?? string.Empty;
                        
                        string strMessageEncode = Encoder(strMessage, strMsgSecret);
                        Console.WriteLine("Message encodé : " + strMessageEncode);
                        SaveEncodedMessageToFile(strMessageEncode);
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
            // Remonte de bin/Debug/netX.0 jusqu'à la racine du projet
            string strFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\reponseMorse.txt");

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

        // Méthode pour convertir un nombre binaire en décimal
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

        // Méthode pour convertir un nombre binaire en octal
        static string ConvertBinaryToOctal(string strBinaryInput)
        {
            // Convertir le binaire en décimal
            uint uintDecimal = ConvertBinaryToDecimal(strBinaryInput);

            // Convertir le décimal en octal
            string strOctalResult = "";
            if (uintDecimal == 0) return "0";

            while (uintDecimal > 0)
            {
                uint uintRemainder = uintDecimal % 8;
                strOctalResult = uintRemainder.ToString() + strOctalResult;
                uintDecimal /= 8;
            }

            return strOctalResult;   
        }

        // Méthode pour convertir un nombre octal en binaire
        static string ConvertOctalToBinary(string strOctalInput)
        {
            // Convertir l'octal en décimal
            uint uintDecimal = 0;
            byte bytLength = (byte)strOctalInput.Length;

            for (int i = 0; i < bytLength; i++)
            {
                char c = strOctalInput[bytLength - 1 - i];
                if (c >= '0' && c <= '7')
                {
                    uintDecimal += (uint)(c - '0') * (uint)Math.Pow(8, i);
                }
                else
                {
                    Console.WriteLine("Erreur : Le nombre octal contient un caractère non valide.");
                    return "";
                }
            }

            // Convertir le décimal en binaire
            return ConvertDecimalToBinary(uintDecimal);
        }

        // Méthode pour convertir un nombre hexadecimal en décimal
        static uint ConvertHexadecimalToDecimal(string strHexInput)
        {
            uint uintDecimalResult = 0;
            byte bytLength = (byte)strHexInput.Length;

            for (int i = 0; i < bytLength; i++)
            {
                char c = strHexInput[bytLength - 1 - i];
                uint uintValue;

                if (c >= '0' && c <= '9')
                {
                    uintValue = (uint)(c - '0');
                }
                else if (c >= 'A' && c <= 'F')
                {
                    uintValue = (uint)(c - 'A' + 10);
                }
                else if (c >= 'a' && c <= 'f')
                {
                    uintValue = (uint)(c - 'a' + 10);
                }
                else
                {
                    Console.WriteLine("Erreur : Le nombre hexadecimal contient un caractère non valide.");
                    return 0;
                }

                uintDecimalResult += uintValue * (uint)Math.Pow(16, i);
            }

            return uintDecimalResult;
        }

        // Méthode pour convertir le code morse en texte invisible
        static string MorseToInvisible(string strMorse)
        {
            string strResultat = "";
            // Implémentation pour convertir le code morse en texte invisible

            foreach (char c in strMorse)
            {
                if (c == '.')
                {
                    strResultat += '\u200B'; // Caractère invisible pour le point
                }
                else if (c == '-')
                {
                    strResultat += '\u200C'; // Caractère invisible pour le tiret
                }
                else if (c == ' ')
                {
                    strResultat += '\u200D'; // Caractère invisible pour l'espace
                }
                else if (c == '/')
                {
                    strResultat += '\u002F'; // Caractère invisible pour le séparateur de mots
                }
                else
                {
                    // Ignorer les caractères non valides
                }
            }

            return strResultat;
        }


        // Méthode pour encoder un message avec un message secret (stéganographie)
        static string Encoder(string strMessage, string strMsgSecret){
            // Vérification que le message secret ne contient que des lettres majuscules et des espaces
            string strRegex = "^[A-Z ]+$";
            bool bMessageValid = System.Text.RegularExpressions.Regex.IsMatch(strMsgSecret, strRegex, RegexOptions.IgnoreCase);
            if(!bMessageValid)
            {
                throw new ArgumentException("Les messages doivent contenir uniquement des lettres majuscules et des espaces.");
            }

            strMsgSecret = strMsgSecret.ToUpper();
            string strMorse = ConvertToMorse(strMsgSecret);
            string strInvisibleTexte = MorseToInvisible(strMorse);

            if (strInvisibleTexte.Length == 0)
            {
                return strMessage; // Aucun message secret à encoder
            }

            if (strMessage.Length == 0)
            {
                throw new ArgumentException("Le message principal ne peut pas être vide.");
            }

            string strResultat = "";
            int intPointer = 0;
            int intMessageLength = strMessage.Length;
            int intInvisibleTexte = strInvisibleTexte.Length;

            // Calculer le quota d'insertion pour chaque caractère du message principal
            for(int i = 0; i < intMessageLength; i++)
            {
                strResultat += strMessage[i];

               int intQuota = (int)Math.Ceiling((double)(i + 1) * intInvisibleTexte / intMessageLength);

                while (intPointer < intQuota)
                {
                    strResultat += strInvisibleTexte[intPointer];
                    intPointer++;
                }
            }

            return strResultat;
        }

        // Méthode pour sauvegarder le message encodé dans un fichier
        static void SaveEncodedMessageToFile(string strMessageEncode){
            
            string strFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\messageEncode.txt");

            Console.Write("Voulez-vous sauvegarder le message encodé dans un fichier ? (O/N) : ");
            char chrChoix = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Pour passer à la ligne suivante

            if (chrChoix == 'O' || chrChoix == 'o' && File.Exists(strFilePath) == false)
            {
                // Écriture du message encodé dans le fichier
                File.WriteAllText(strFilePath, strMessageEncode);
            }
            else if (chrChoix == 'O' || chrChoix == 'o' && File.Exists(strFilePath) == true)
            {
                // Si le fichier existe déjà, on ajoute le message encodé à la fin du fichier existant
                File.AppendAllText(strFilePath, strMessageEncode + Environment.NewLine);
            }
        }
    }
}

