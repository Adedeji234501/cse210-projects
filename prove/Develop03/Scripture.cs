public class Scripture
{
    private readonly Reference reference;
    private readonly List<Word> words;

    public bool AllWordsHidden => words.All(word => word.IsHidden);

    public Scripture(string referenceText, string scriptureText)
    {
        reference = new Reference(referenceText);
        words = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
    }

    public bool HideRandomWords()
    {
        List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();

        if (visibleWords.Count > 0)
        {
            Random random = new Random();

            // Randomly hide a few words
            int wordsToHide = Math.Min(visibleWords.Count, 3); // Hide up to 3 words
            for (int i = 0; i < wordsToHide; i++)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
            }

            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{reference}: {string.Join(" ", words)}";
    }
}