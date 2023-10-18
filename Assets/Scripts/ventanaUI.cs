using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ventanaUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    Vector3 mouseStartPos;

    [SerializeField] PointerEventData.InputButton inputInteract;

    RectTransform rectTransform;

    RectTransform rectTransformPC;

    public float borderSnapSize = 10;

    static HashSet<ventanaUI> allWindows = new HashSet<ventanaUI>();

    private void Awake()
    {
        rectTransform = (RectTransform)transform;

        allWindows.Add(this);
    }

    public void Minimizar(Image img)
    {
        img.color = Color.green;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(eventData.button == inputInteract)
        {
            transform.position = Input.mousePosition - mouseStartPos;
            TrapToScreen();
            SnapOtherWindows();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == inputInteract)
        {
            mouseStartPos = Input.mousePosition - transform.position;
        }
    }

    private void TrapToScreen()
    {
        Vector3 diffMin = rectTransform.position + (Vector3)rectTransform.rect.position;
        Vector3 diffMax = (Vector3)Camera.main.pixelRect.size - rectTransform.position + (Vector3)rectTransform.rect.position;

        if (diffMin.x < borderSnapSize)
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

    private void SnapOtherWindows()
    {
        foreach(ventanaUI ven in allWindows)
        {
            if (ven == this)
            {
                continue;
            }
            if (ven.gameObject.activeInHierarchy)
            {
                Vector3 DiffMin = ven.rectTransform.position - (Vector3) (ven.rectTransform.rect.position + rectTransform.rect.position) - rectTransform.position;    
                Vector3 DIffMax = ven.rectTransform.position + (Vector3)(ven.rectTransform.rect.position + rectTransform.rect.position) - rectTransform.position;
                if (Mathf.Abs(DiffMin.x) < borderSnapSize)
                {
                    rectTransform.position += new Vector3(DiffMin.x, 0, 0);
                }
                if (Mathf.Abs(DiffMin.y) < borderSnapSize)
                {
                    rectTransform.position += new Vector3(0, DiffMin.y, 0);
                }
                if (Mathf.Abs(DIffMax.x) < borderSnapSize)
                {
                    rectTransform.position += new Vector3(DIffMax.x, 0, 0);
                }
                if (Mathf.Abs(DIffMax.y) < borderSnapSize)
                {
                    rectTransform.position += new Vector3(0, DIffMax.y, 0);
                }
            }
        }
    }
}
