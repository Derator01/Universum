namespace Universum.Misc;

public static class ULinq
{
    public static string ToPascalCase(this string input)
    {
        string[] words = input.Split(new char[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            char[] letters = words[i].ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            words[i] = new string(letters);
        }

        return string.Concat(words);
    }
}
