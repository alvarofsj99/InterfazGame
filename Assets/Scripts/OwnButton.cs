using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnButton : MonoBehaviour
{
    [SerializeField] bool isActive;
    Button ownButton;
    [SerializeField]GameObject iconError;
    Image icon;
    // Start is called before the first frame update
    void Start()
    {
        ownButton = GetComponent<Button>();
        iconError = transform.GetChild(0).gameObject;

        if (isActive)
        {
            ownButton.interactable = true;
            iconError.SetActive(false);
        }
        else
        {
            ownButton.interactable= false;
            iconError.SetActive(true);
        }
    }

    private void Update()
    {
        if (isActive)
        {
            ownButton.interactable = true;
            iconError.SetActive(false);
        }
        else
        {
            ownButton.interactable = false;
            iconError.SetActive(true);
        }
    }

    public void OpenWindowUI(GameObject windowUI)
    {
        windowUI.SetActive(true);
        icon = GetComponent<Image>();
        icon.color = Color.white;
    }
}
