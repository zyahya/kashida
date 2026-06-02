using System.Text;

namespace Kashida;

public static class Kashida
{
    private static readonly char KashidaChar = 'ـ';

    private static readonly HashSet<char> ElongatableChars = new HashSet<char> {
        'ب', 'ت', 'ث', 'ج', 'ح', 'خ', 'س', 'ش', 'ص', 'ض', 'ط', 'ظ', 'ع', 'غ', 'ف', 'ق', 'ك', 'ل', 'م', 'ن', 'ي'
    };

    /// <summary>
    /// Adds Kashida to elongatable Arabic letters, with full support for diacritics.
    /// </summary>
    public static string ApplyKashida(this string text, int kashidaCount = 1)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        var sb = new StringBuilder(text.Length);

        for (int i = 0; i < text.Length; i++)
        {
            char current = text[i];
            sb.Append(current);

            if (IsHarakah(current))
            {
                continue;
            }

            int nextIndex = SkipHarakah(text, i + 1);
            if (nextIndex >= text.Length)
            {
                continue;
            }

            char nextRealChar = text[nextIndex];
            if (!ElongatableChars.Contains(current) ||
                !CanConnectFromRight(nextRealChar) ||
                (current == 'ل' && nextRealChar == 'ا'))
            {
                continue;
            }

            for (int d = i + 1; d < nextIndex; d++)
            {
                sb.Append(text[d]);
            }

            sb.Append(new string(KashidaChar, kashidaCount));
            i = nextIndex - 1;
        }

        return sb.ToString();
    }

    /// <summary>
    /// Removes all Kashida (elongation) characters from the text, preserving diacritics.
    /// </summary>
    public static string ClearKashida(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return text.Replace(KashidaChar.ToString(), string.Empty);
    }

    /// <summary>
    /// Checks if a character is an Arabic diacritic (Harakah)
    /// </summary>
    private static bool IsHarakah(char ch)
    {
        return (ch >= 0x064B && ch <= 0x0652) ||
               ch == 0x0653 || ch == 0x0654;
    }

    private static int SkipHarakah(string text, int startIndex)
    {
        int index = startIndex;
        while (index < text.Length && IsHarakah(text[index]))
        {
            index++;
        }

        return index;
    }

    private static bool CanConnectFromRight(char ch)
    {
        string nonConnectingRight = "ءآأؤإاةدذرزوٰ ";
        return ch >= 0x0600 && ch <= 0x06FF && !nonConnectingRight.Contains(ch);
    }
}
