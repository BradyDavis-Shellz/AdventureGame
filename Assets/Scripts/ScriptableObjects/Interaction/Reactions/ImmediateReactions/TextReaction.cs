using UnityEngine;

public class TextReaction : Reaction
{
    public string message;
    public Color textColor = Color.white;
    public float delay;


    private ITextManager textManager;

    public void SetTextManager(ITextManager textManager)
    {
        this.textManager = textManager;
    }


    protected override void SpecificInit()
    {
        textManager = FindObjectOfType<TextManager> ();
    }


    protected override void ImmediateReaction()
    {
        textManager.DisplayMessage (message, textColor, delay);
    }
}