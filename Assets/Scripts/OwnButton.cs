using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnButton : MonoBehaviour
{
    [SerializeField] bool isActive;
    Button ownButton;
    [SerializeField]GameObject iconError;
    // Start is called before the first frame update
    void Start()
    {
        ownButton = GetComponent<Button>();
        

        if (isActive)
        {
            ownButton.interactable = true;
            
        }
        else
        {
            ownButton.interactable= false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
