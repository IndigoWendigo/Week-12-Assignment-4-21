using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public int coinRequirement;
    public string sceneName;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Total Coins: " + coinCount.ToString();

        if(coinCount == coinRequirement)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
