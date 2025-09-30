namespace Charon.Font;

public static class Charsets
{
    // Basic Latin lowercase letters
    public const string Lowercase = "abcdefghijklmnopqrstuvwxyz";

    // Basic Latin uppercase letters
    public const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    // Digits / numbers
    public const string Digits = "0123456789";

    // Hexadecimal lowercase
    public const string HexLower = "0123456789abcdef";

    // Hexadecimal uppercase
    public const string HexUpper = "0123456789ABCDEF";

    // Alphanumeric (letters + digits)
    public const string Alphanumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    // Printable ASCII characters
    public const string PrintableAscii = 
        " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

    // Base64 standard
    public const string Base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

    // Base64 URL-safe
    public const string Base64Url = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";

    // Letters + basic punctuation
    public const string LettersPunctuation = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ.,;:!?()[]{}<>-_'\"";
}
