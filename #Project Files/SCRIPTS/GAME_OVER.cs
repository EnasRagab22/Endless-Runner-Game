using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GAME_OVER : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinsCollected;
    void Start()
    {
        CoinsCollected.text = PlayerPrefs.GetInt("CoinsCollected").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}
