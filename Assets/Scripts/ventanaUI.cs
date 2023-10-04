using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ventanaUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    Vector3 mouseStartPos;

    [SerializeField] PointerEventData.InputButton inputInteract;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
