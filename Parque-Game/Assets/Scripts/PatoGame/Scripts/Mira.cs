using UnityEngine;

public class Mira : MonoBehaviour
{
RectTransform rectTransform;
   void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Cursor.visible = false;
    }

    void Update()
    {
        rectTransform.position = Input.mousePosition;
    }
}
