// Anand Charvin.G
// Base64Converter - Converts strings to Base64-encoded strings and vice versa
// This class contains methods for converting strings to Base64-encoded strings and converting
// Base64-encoded strings back to the original strings. It is used for Base64 encoding and decoding.


public class Base64Converter
{
    private static readonly char[] Base64Letters = new[]
    {
        'A','B','C','D','E','F','G','H','I','J','K','L','M',
        'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        'a','b','c','d','e','f','g','h','i','j','k','l','m',
        'n','o','p','q','r','s','t','u','v','w','x','y','z',
        '0','1','2','3','4','5','6','7','8','9','+','/'
    };

    // Converts a string to a Base64-encoded string
    public static string StringToBase64(string input)
    {
        // Create an instance of the BinaryConverter class
        BinaryConverter binaryConverter = new BinaryConverter();

        // Convert the input string to binary using BinaryConverter
        string binaryString = binaryConverter.StringToBinary(input);

        // Pad the binary string with zeros if needed
        while (binaryString.Length % 6 != 0)
        {
            binaryString += "00";
        }

        string base64 = "";
        for (int i = 0; i < binaryString.Length; i += 6)
        {
            int index = Convert.ToInt32(binaryString.Substring(i, 6), 2);
            base64 += Base64Letters[index];
        }

        // Add padding characters if needed to make the length a multiple of 4
        while (base64.Length % 4 != 0)
        {
            base64 += "=";
        }

        return base64;
    }

    // The though process is as such, it goes as follows,
    // It starts by removing any padding characters.
    // Then, it converts each Base64 character into a 6-bit binary string.
    // If the total binary string isn't a full byte, it adds zeros. Finally,
    // it converts the binary string back to text,
    // and gives us the original text from the Base64 string.

    // Converts a Base64-encoded string to the original string
    public static string Base64ToString(string base64Input)
    {
        // Remove any padding characters from the input
        base64Input = base64Input.TrimEnd('=');

        // Initialize an empty string to store the binary representation
        string binaryString = "";

        // Iterate over each character in the Base64-encoded input string
        for (int i = 0; i < base64Input.Length; i++)
        {
            // Find the index of the current character in the Base64Letters array
            int index = Array.IndexOf(Base64Letters, base64Input[i]);

            // Convert the index to its binary representation and pad it to 6 bits
            binaryString += Convert.ToString(index, 2).PadLeft(6, '0');
        }

        // Pad the binary string with zeros as needed to make it a multiple of 8 bits
        while (binaryString.Length % 8 != 0)
        {
            binaryString += "0";
        }

        // Create an instance of the BinaryConverter class to facilitate binary-to-text conversion
        BinaryConverter binaryConverter = new BinaryConverter();

        // Convert the binary string back to the original text string using BinaryConverter
        return binaryConverter.BinaryToString(binaryString);
    }

}
