using UnityEngine;

public class InputFieldGrabber : MonoBehaviour
{
    private string inputText;
    public RuneDecipheringScript runeScript;

    public void GrabFromInputField (string input)
    {
        inputText = input;
        runeScript.CheckAnswer(input);
    }

}
