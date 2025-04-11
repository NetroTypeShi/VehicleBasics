using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject Manager;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Column"))
        {
            print("YOU LOOSE");
        }

        if (collision.gameObject.CompareTag("Coin"))
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
    }

    void OffCoinAdded()
    {
        gameManagerScript.coinAdded = false;
    }
}
