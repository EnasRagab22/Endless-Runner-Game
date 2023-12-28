using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Magnet;
    [SerializeField] private GameObject Wings;
    [SerializeField] private float PowerUPSpawnPercent;
    private void OnTriggerEnter(Collider other)
    {
        float rand = Random.Range(0, 100);
        if (rand < PowerUPSpawnPercent)
        {
            GameObject Power = Magnet;

            if (Random.value > 0.5)
            {
                Power = Wings;
            }
            Power.SetActive(true);
            Power.transform.position = this.transform.position;
        }
      


    }
}
