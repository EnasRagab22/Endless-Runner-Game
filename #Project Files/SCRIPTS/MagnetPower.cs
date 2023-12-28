using TMPro;
using UnityEngine;

public class MagnetPower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MagnetTimeeText;
    [SerializeField] private GameObject MagnetUI;
    [SerializeField] private GameObject Player;
    [SerializeField] private float MaxPowerTime;
    private float RemainingPowerTime = -1;
    public static int MagnetEnable = -1;

    // Update is called once per frame
    void Update()
    {
        if (MagnetEnable == 1)
        {
            if (!MagnetUI.activeInHierarchy)
            {
                MagnetUI.SetActive(true);
                RemainingPowerTime = MaxPowerTime;
            }
            if (RemainingPowerTime > 0)
            {
                transform.position = Player.transform.position;
                RemainingPowerTime = RemainingPowerTime - Time.deltaTime;
                MagnetTimeeText.text = ((int)RemainingPowerTime).ToString();
            }
            else
            {
                MagnetEnable = -1;
                MagnetUI.SetActive(false);
            }


        }

    }
}
