using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    int coinNumber;
    // Start is called before the first frame update
    void Start()
    {
      coinNumber = 0;
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
            coinNumber++;
            print(coinNumber);
        }
    }
}
