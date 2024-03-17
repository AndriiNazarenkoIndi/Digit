using TMPro;

public class TextSetter
{
    public void IntValueSetText<T>(T source, TMP_Text text, int value)
    {
        if (source != null)
        {
            text.text = value.ToString();
        }
    }
}