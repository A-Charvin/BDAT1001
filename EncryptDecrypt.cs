// Anand Charvin.G

// EncryptDecrypt - Encrypts and decrypts messages using a shift cipher
// This class provides methods for encrypting and decrypting messages using a shift cipher with
// a specified key. It is used for message encryption and decryption.


using System.Text;

public class EncryptDecrypt
{
    // Encrypts a message using a shift cipher
    public static string EncryptMessage(string message, int key)
    {
        StringBuilder encryptedMessage = new StringBuilder();
        foreach (char character in message)
        {
            if (char.IsLetter(character))
            {
                char shiftedChar = ShiftCharacter(character, key);
                encryptedMessage.Append(shiftedChar);
            }
            else
            {
                // Non-letter characters remain unchanged
                encryptedMessage.Append(character);
            }
        }
        return encryptedMessage.ToString();
    }

    // Decrypts a message using a shift cipher 
    public static string DecryptMessage(string encryptedMessage, int key)
    {
        // Decryption is the same as encryption with a negative key
        return EncryptMessage(encryptedMessage, -key);
    }

    // Helper function to shift a character by the specified key
    private static char ShiftCharacter(char character, int key)
    {
        char baseCharacter = char.IsUpper(character) ? 'A' : 'a';
        return (char)(((character - baseCharacter + key + 26) % 26) + baseCharacter);
    }
}
