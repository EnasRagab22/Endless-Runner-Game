using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTIVATE_FLY_POWER : MonoBehaviour
{
    [SerializeField] private GameObject PlayerWings;
    private float CoinsSpawned, CurrentCoinPos, CoinStartPosition, CoinEndPosition;
    [SerializeField] private int ChangeLaneOn;
    int Offset_Z = 6;
    int X_position = 0;
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement.IsFlying = true;
        PlayerWings.SetActive(true);
        gameObject.SetActive(false);

        CoinStartPosition = transform.position.z;
        CoinEndPosition = CoinStartPosition + 90;
        CurrentCoinPos = CoinStartPosition;
        while (CurrentCoinPos < CoinEndPosition)
        {
            GameObject Coin = ObjectPool.SharedInstance.GetPooledObject();
            if (Coin != null)
            {
               
                if (CoinsSpawned == ChangeLaneOn)
                {
                    if (X_position == 0)
                    {
                        if (Random.value > 0.5f)
                            X_position = -2;
                        else
                            X_position = 2;
                    }
                    else if (X_position == 2)
                    {
                        X_position = 0;
                    }
                    else if (X_position == -2)
                    {
                        X_position = 0;
                    }
                }
                Coin.SetActive(true);
                Coin.transform.position = new Vector3(X_position, 11.35f, CurrentCoinPos+ Offset_Z);
                CurrentCoinPos+= Offset_Z;
                CoinsSpawned++;

                if (CoinsSpawned > ChangeLaneOn)
                    CoinsSpawned = 0;
            }
            else
            {
                return;
            }
        }
    }
}
