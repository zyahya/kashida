namespace Kashida;

public static class Kashida
{
    private static readonly char[] ArabicCharacters = [
        'ء', 'آ', 'أ', 'ؤ', 'إ', 'ئ', 'ا', 'ب', 'ة', 'ت', 'ث', 'ج', 'ح', 'خ',
        'د', 'ذ', 'ر', 'ز', 'س', 'ش', 'ص', 'ض', 'ط', 'ظ', 'ع', 'غ', 'ف', 'ق',
        'ك', 'ل', 'م', 'ن', 'ه', 'و', 'ى', 'ي'
    ];
    private static readonly char[] AcceptingCharacters = [
        'ب', 'ي', 'س', 'ش', 'ل', 'ن', 'م', 'ك', 'ج', 'ح', 'خ',
        'ه', 'ع', 'غ', 'ف', 'ق', 'ث', 'ص', 'ض', 'ى', 'و', 'ط', 'ظ'
    ];
    private static readonly char[] NonAcceptingCharacters = ['ء', 'ر', 'ة', 'ا', 'أ', 'ؤ', 'و', 'د', 'ذ', 'ز'];
    private static readonly char ExtendedChar = 'ـ';

    public static string Apply(string input)
    {
        var inputList = input.ToList();
        List<string> result = [];

        for (int i = 0; i < inputList.Count; i++)
        {
            var currentChar = inputList[i];

            if (IsLastChar(string.Join("", inputList), currentChar))
            {
                result.Add(string.Concat(currentChar));
                break;
            }

            var nextChar = inputList[i + 1];

            if (!IsArabicChar(currentChar))
            {
                result.Add(string.Concat(currentChar));
            }

            if (IsArabicChar(currentChar))
            {
                if (IsInNonAcceptingCharacters(currentChar))
                {
                    result.Add(string.Concat(currentChar));
                }
                else if (nextChar == ' ' || !IsArabicChar(nextChar))
                {
                    result.Add(string.Concat(currentChar));
                }
                else
                {
                    result.Add(string.Concat(currentChar, ExtendedChar));
                }
            }
        }

        return string.Join("", result);
    }

    private static bool IsInAcceptingCharacters(char input)
    {
        return AcceptingCharacters.Contains(input);
    }

    private static bool IsInNonAcceptingCharacters(char input)
    {
        return NonAcceptingCharacters.Contains(input);
    }

    private static bool IsLastChar(string source, char input)
    {
        char lastChar = source[^1];
        return input == lastChar;
    }

    private static bool IsArabicChar(char input)
    {
        if (ArabicCharacters.Contains(input))
        {
            return true;
        }
        return false;
    }

    public static string Clear(string input)
    {
        var inputList = input.ToList();
        inputList.RemoveAll(e => e == ExtendedChar);
        return string.Join("", inputList);
    }
}
