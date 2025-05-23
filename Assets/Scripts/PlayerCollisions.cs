using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject Manager;
    [SerializeField] string sceneName;
    Manager gameManagerScript;
    void Start()
    {
        gameManagerScript = Manager.GetComponent<Manager>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {

            gameManagerScript.coinNumber++;
            CoinAdded();
            print(gameManagerScript.coinNumber);
            Invoke("OffCoinAdded", 1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Column"))
        {
            print("YOU LOOSE");
            SceneManager.LoadScene(sceneName);
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
