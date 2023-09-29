// Anand Charvin.G

// HexadecimalConverter - Converts strings to hexadecimal and vice versa
// This class offers methods for converting strings to hexadecimal representation and converting
// hexadecimal strings back to the original strings. It is used for hexadecimal encoding and decoding.

// Modified from the code provided in class. (Optimised looping through letters one by one.)

public class HexadecimalConverter
{
    // Converts a string to hexadecimal
    public string StringToHexadecimal(string data)
    {
        string hexadecimal = "";
        // Iterate over each character in the string
        foreach (char c in data)
        {
            // Convert the character to hexadecimal and add it to the hexadecimal string
            hexadecimal += ConvertToHexadecimal(c);
        }
        return hexadecimal;
    }

    // Converts a hexadecimal string back to a regular string
    public string HexadecimalToString(string data)
    {
        string text = "";
        // Iterate over the hexadecimal string, 2 characters at a time
        for (int i = 0; i < data.Length; i += 2)
        {
            // Convert the 2-character hexadecimal number to a character and add it to the text string
            text += ConvertToChar(data.Substring(i, 2));
        }
        return text;
    }

    // Converts a character to its hexadecimal representation

    // The Method used here is as such 
    // It calculates the ASCII value of the character and converts it to hexadecimal.
    // If the remainder is 10 or more, it’s converted to ‘A’-‘F’. If the hexadecimal value is less than two digits,
    // a leading zero is added.

    private string ConvertToHexadecimal(char c)
    {
        int ascii = (int)c;
        string hexadecimal = "";
        // Convert the ASCII value to hexadecimal
        while (ascii > 0)
        {
            int remainder = ascii % 16;
            if (remainder < 10)
                hexadecimal = remainder + hexadecimal;
            else
                hexadecimal = (char)(remainder - 10 + 'A') + hexadecimal;
            ascii /= 16;
        }
        // Pad the hexadecimal number with zeros to make it 2 characters long
        while (hexadecimal.Length < 2)
        {
            hexadecimal = "0" + hexadecimal;
        }
        return hexadecimal;
    }

    // Converts a 2-character hexadecimal number to a character
    private char ConvertToChar(string hexadecimal)
    {
        int ascii = 0;
        // Convert the hexadecimal number to an ASCII value
        for (int i = 0; i < 2; i++)
        {
            int digit;
            if (hexadecimal[i] >= 'A')
                digit = hexadecimal[i] - 'A' + 10;
            else
                digit = hexadecimal[i] - '0';
            ascii += digit * (int)Math.Pow(16, 1 - i);
        }
        // Convert the ASCII value to a character
        return (char)ascii;
    }
}
