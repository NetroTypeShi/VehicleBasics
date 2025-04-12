using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject Manager;
    [SerializeField] string sceneName;
    Manager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = Manager.GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Column"))
        {
            print("YOU LOOSE");
            SceneManager.LoadScene(sceneName);
        }

        if (other.gameObject.CompareTag("Coin"))
        {

            gameManagerScript.coinNumber++;
            CoinAdded();
            print(gameManagerScript.coinNumber);
            Invoke("OffCoinAdded", 1f);
        }
    }
    void CoinAdded()
    {
        gameManagerScript.coinAdded = true;
        StartCoroutine(gameManagerScript.PointsAnimation());
    }

    void OffCoinAdded()
    {
        gameManagerScript.coinAdded = false;
    }
}
