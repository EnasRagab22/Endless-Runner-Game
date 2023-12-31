using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActivateMagnetPower : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUIs;
    int counter = 5;
    void Start()
    {
        textMeshProUGUIs.text = "0";
    }
    private void OnTriggerEnter(Collider other)
    {
        textMeshProUGUIs.text= "5";
        MagnetPower.MagnetEnable = 1;
        StartCoroutine(countMagnet());
        //gameObject.SetActive(false);
        counter = 5;
    }

    IEnumerator countMagnet()
    {
        while (counter > 0)
        {
        yield return new WaitForSecondsRealtime(1f);
        counter --;
        textMeshProUGUIs.text = counter.ToString();
        }
    }
}
