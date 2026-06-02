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

        var sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char current = text[i];
            sb.Append(current);

            if (IsHarakah(current))
            {
                continue;
            }

            int nextIndex = i + 1;
            while (nextIndex < text.Length && IsHarakah(text[nextIndex]))
            {
                nextIndex++;
            }

            if (nextIndex < text.Length)
            {
                char nextRealChar = text[nextIndex];

                if (ElongatableChars.Contains(current) && CanConnectFromRight(nextRealChar))
                {
                    if (current == 'ل' && nextRealChar == 'ا')
                    {
                        continue;
                    }

                    int diacriticCount = nextIndex - (i + 1);
                    for (int d = 1; d <= diacriticCount; d++)
                    {
                        sb.Append(text[i + d]);
                    }

                    sb.Append(new string(KashidaChar, kashidaCount));

                    i += diacriticCount;
                }
            }
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

    private static bool CanConnectFromRight(char ch)
    {
        string nonConnectingRight = "ءآأؤإاةدذرزوٰ ";
        return ch >= 0x0600 && ch <= 0x06FF && !nonConnectingRight.Contains(ch);
    }
}
