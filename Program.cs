// Anand Charvin.G

// Assignment 1 - String Conversion and Encryption/Decryption Program
// This C# program takes user input (full name),
// converts it to various formats (binary, hexadecimal, Base64),
// and then demonstrates encryption and decryption using a shift cipher.

using System;

class Program
{
    static void Main()
    {
        // Prompt the user to enter their full name
        Console.WriteLine("Please enter your full name:");
        string fullName = Console.ReadLine();

        // This was added to remove a warning about the null Literal,
        // but the issue still remain, Regardless
        // Know issue on some cases after research on the matter
        // Will try to find a fix for this later down the line.

        if (string.IsNullOrEmpty(fullName))
        {
            Console.WriteLine("Full name cannot be empty.");
            return;
        }

        // Create instances of the converter classes
        // These instances are created and used to remove a static error while trying to compile the code.
        var binaryConverter = new BinaryConverter();
        var hexadecimalConverter = new HexadecimalConverter();

        // Task 1 : String to Binary Conversion
        Console.WriteLine("\n========= Binary Converter =========");
        string binaryResult = binaryConverter.StringToBinary(fullName);
        Console.WriteLine($"Binary of \"{fullName}\" = {binaryResult}");
        // Binary to String Reconstruction
        string originalFullName = binaryConverter.BinaryToString(binaryResult); // Variable with the name
        Console.WriteLine($"Original Full Name: {originalFullName}");


        // Task 2 : String to HexaDecimal Conversion
        Console.WriteLine("\n========= Hexadecimal Converter =========");
        string hexResult = hexadecimalConverter.StringToHexadecimal(fullName);
        Console.WriteLine($"Hexadecimal of \"{fullName}\" = {hexResult}");
        // Hexadecimal to String Reverse Conversion
        string originalHexFullName = hexadecimalConverter.HexadecimalToString(hexResult); // Changed variable name to avoid conflict
        Console.WriteLine($"Original Full Name: {originalHexFullName}");


        // Task 3 : String to Base64 Conversion
        Console.WriteLine("\n========= Base64 Converter =========");
        string base64Result = Base64Converter.StringToBase64(fullName);
        Console.WriteLine($"Base64 of \"{fullName}\" = {base64Result}");
        // Convert Base64 back to the original string
        string originalFullNameFromBase64 = Base64Converter.Base64ToString(base64Result);
        Console.WriteLine($"Original Full Name (from Base64): {originalFullNameFromBase64}");


        // Task 4 : Encryption and Decryption
        Console.WriteLine("\n========= Encryption and Decryption =========");
        int shiftKey = 5; // Replace with your desired shift key (using 5 now)
        string encrypted = EncryptDecrypt.EncryptMessage(fullName, shiftKey);
        Console.WriteLine($"Encrypted: {encrypted}");
        // Decrypt the encrypted full name using the EncryptDecrypt class
        string decrypted = EncryptDecrypt.DecryptMessage(encrypted, shiftKey);
        Console.WriteLine($"Decrypted: {decrypted}");
    }
}
