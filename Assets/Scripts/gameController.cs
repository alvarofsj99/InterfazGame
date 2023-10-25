using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    [SerializeField] GameObject panelVictoria;
    [SerializeField] GameObject panelDerrota;

    [SerializeField] int zonaDescubierta = 0;

    [SerializeField] OwnButton buttonImpresora;

    [SerializeField] MapButtons mapButtons;

    // Start is called before the first frame update
    void Start()
    {
        buttonImpresora = GameObject.Find("ButtonImpresora").GetComponent<OwnButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(zonaDescubierta > 3)
        {
            buttonImpresora.isActive = true;
        }
    }

    public void ElegirSospechoso(bool sospechosoReal)
    {
        if (sospechosoReal)
        {
            panelVictoria.SetActive(true);
        }

        else
        {
            panelDerrota.SetActive(true);
        }
    }

    public void AumentarZona()
    {
        zonaDescubierta++;


    }
}
