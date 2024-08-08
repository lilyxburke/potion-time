using UnityEngine;

public class NumberScript : MonoBehaviour
{
    public GameObject[] children;


    private GameObject[] GetChildren()
    {
        GameObject[] children = new GameObject[this.gameObject.transform.childCount];
        for (int i = 0; i < children.Length; ++i)
        {
            children[i] = this.gameObject.transform.GetChild(i).gameObject;
        }
        return children;
    }
    void Update()
    {
        children = GetChildren();
    }
}
