using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_TRIGGER_FALSE : MonoBehaviour
{

    private Transform NextPosition;
    private float T = -1;
    private void OnTriggerEnter(Collider other)
    {
        if (MagnetPower.MagnetEnable == 1 && other.CompareTag("Magnet"))
        {
            NextPosition = other.transform;
            T = 0;
        }
        else
        {
            gameObject.SetActive(false);
            T = -1;
        }

    }

    private void Update()
    {
        if (T >= 0)
        {
            T += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, NextPosition.position, T);
            if (T >= 1)
                T = -1;
        }
    }
}
