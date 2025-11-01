using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject CreditCanvas;
    public GameObject CreditButton;
    public GameObject ExitCredit;
    // Start is called before the first frame update
    void Start()
    {
        CreditButton.SetActive(true);
        CreditCanvas.SetActive(false);
        ExitCredit.SetActive(false);
    }

    // Update is called once per frame
    public void CreditShow(){
        CreditButton.SetActive(false);
        CreditCanvas.SetActive(true);
        ExitCredit.SetActive(true);
    }
    public void CreditClose(){
        CreditButton.SetActive(true);
        CreditCanvas.SetActive(false);
        ExitCredit.SetActive(false);
    }
}
