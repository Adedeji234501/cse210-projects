public class Reference
{
    public string Text { get; }

    public Reference(string text)
    {
        Text = text;
    }
    // Constructor for a verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Text = $"{book} {chapter}:{startVerse}-{endVerse}";
    }

    public static bool TryParse(string input, out Reference reference)
    {
        // Implement parsing logic for verse input
        // You may need to customize this based on your specific input format
        reference = new Reference(input);
        return true;
    }

    public bool Contains(Reference other)
    {
        // Implement logic to check if this reference contains another reference
        // For simplicity, assume they are the same for now
        return Text.Equals(other.Text);
    }

    public override string ToString()
    {
        return Text;
    }
}