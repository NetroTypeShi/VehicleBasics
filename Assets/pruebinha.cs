using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebinha : MonoBehaviour
{
    [SerializeField] GameObject thing;
    [SerializeField] float amount;
    [SerializeField] float speed;
    GameObject instantiatedObject;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateOverTime());
        instantiatedObject = GameObject.Instantiate(thing);
        
    }
    private void Update()
    {
        
    }

    IEnumerator InstantiateOverTime()
    {
        for (int i = 0; i<amount; i++)
        {
            Instantiate(thing);
            direction = new Vector3(Random.Range(0, 1), Random.Range(0, 1), 0);
            for (int j = 0; j <0; j++)
            {
                instantiatedObject.transform.position += direction * speed * Time.deltaTime;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
