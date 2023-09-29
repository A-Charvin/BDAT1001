// Anand Charvin.G

// BinaryConverter - Converts strings to binary and vice versa
// This class provides methods for converting strings to binary representation and converting
// binary strings back to the original strings. It is used for binary encoding and decoding.

// Modified from the code provided in class.


using System;

// BinaryConverter.cs
public class BinaryConverter
{
    // Converts a string to binary
    public string StringToBinary(string data)
    {
        string binary = "";
        // Iterate over each character in the string
        foreach (char c in data)
        {
            // Convert the character to binary and add it to the binary string
            binary += ConvertToBinary(c);
        }
        return binary;
    }

    // Converts a binary string back to a regular string
    public string BinaryToString(string data)
    {
        string text = "";
        // Iterate over the binary string, 8 bits at a time
        for (int i = 0; i < data.Length; i += 8)
        {
            // Convert the 8-bit binary number to a character and add it to the text string
            text += ConvertToChar(data.Substring(i, 8));
        }
        return text;
    }

    // Converts a character to its binary representation
    private string ConvertToBinary(char c)
    {
        int ascii = (int)c;
        string binary = "";
        // Convert the ASCII value to binary
        while (ascii > 0)
        {
            binary = (ascii % 2) + binary;
            ascii /= 2;
        }
        // Pad the binary number with zeros to make it 8 bits long
        while (binary.Length < 8)
        {
            binary = "0" + binary;
        }
        return binary;
    }

    // Converts an 8-bit binary number to a character
    private char ConvertToChar(string binary)
    {
        int ascii = 0;
        // Convert the binary number to an ASCII value
        for (int i = 0; i < 8; i++)
        {
            ascii += int.Parse(binary[i].ToString()) * (int)Math.Pow(2, 7 - i);
        }
        // Convert the ASCII value to a character
        return (char)ascii;
    }
}
