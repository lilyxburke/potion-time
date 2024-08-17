using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform rect;

    void Start()
    {
        rect = this.gameObject.GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, rect.anchoredPosition.y - 10, 0);
        rect.sizeDelta = new Vector2(100,120);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, rect.anchoredPosition.y + 10, 0);
        rect.sizeDelta = new Vector2(120, 120);
    }
}
