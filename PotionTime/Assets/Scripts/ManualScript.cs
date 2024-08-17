using UnityEngine;
using UnityEngine.UI;

public class ManualScript : MonoBehaviour
{
    private bool manualActive = false;
    public GameObject manual;
    public GameObject manualOverlay;
    public Button button;
    public Sprite left;
    public Sprite right;
    public void ButtonPress()
    {
        if (manualActive)
        {
            MoveOut();
            manualActive = false;
        }
        else
        {
            MoveIn();
            manualActive = true;
        }
    }
    private void MoveIn()
    {
        manual.transform.localPosition = new Vector3(-960, -540, 0);
        manualOverlay.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        button.transform.localPosition = new Vector3(670, 0, 2);
        button.GetComponent<Image>().sprite = right;
    }

    private void MoveOut()
    {
        manual.transform.localPosition = new Vector3(620, -540, 20);
        manualOverlay.GetComponent<RectTransform>().anchoredPosition = new Vector3(1600, 0, 0);
        button.transform.localPosition = new Vector3(830, 0, 2);
        button.GetComponent<Image>().sprite = left;
    }
}
