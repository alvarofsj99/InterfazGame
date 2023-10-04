using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ventanaUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    Vector3 mouseStartPos;

    [SerializeField] PointerEventData.InputButton inputInteract;

    RectTransform rectTransform;

    public float borderSnapSize = 20;

    private void Awake()
    {
        rectTransform = (RectTransform)transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(eventData.button == inputInteract)
        {
            transform.localPosition = Input.mousePosition - mouseStartPos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == inputInteract)
        {
            mouseStartPos = Input.mousePosition - transform.localPosition;
        }
    }

    private void TrapToScreen()
    {
        Vector3 diffMin = rectTransform.position + (Vector3)rectTransform.rect.position;
        Vector3 diffMax = (Vector3)Camera.main.pixelRect.size - rectTransform.position + (Vector3)rectTransform.rect.position;

        if(diffMin.x < borderSnapSize)
        {
            rectTransform.position -= new Vector3(diffMin.x, 0, 0);
        }

        if(diffMin.y < borderSnapSize)
        {
            rectTransform.position -= new Vector3(0, diffMin.y, 0);
        }

        if (diffMax.x < borderSnapSize)
        {
            rectTransform.position += new Vector3(diffMax.x, 0, 0);
        }

        if (diffMax.y < borderSnapSize)
        {
            rectTransform.position += new Vector3(0, diffMax.y, 0);
        }
    }
}
