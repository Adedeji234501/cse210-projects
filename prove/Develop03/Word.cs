public class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }
    public Reference Reference { get; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
        Reference = new Reference(""); // Dummy reference for now
    }

    public void Hide()
    {
        IsHidden = true;
    }
    public override string ToString()
    {
        return IsHidden ? "_____" : Text;
    }
}