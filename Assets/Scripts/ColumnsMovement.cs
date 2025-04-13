using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ColumnsMovement : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] GameObject column;
    [SerializeField] float duration = 2f;
    [SerializeField] AnimationCurve curve;
    Vector3 whereIsColumn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountOverTime());
    }

    // Update is called once per frame
    private IEnumerator CountOverTime()
    {
        while (true)
        {
            
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float normalizedElapsedTime = elapsedTime / duration;
                float eval = curve.Evaluate(normalizedElapsedTime);
                Vector3 finalTransform = Vector3.Lerp(pointA.position,pointB.position, eval);
                column.transform.position = finalTransform;
                yield return new WaitForEndOfFrame();
            }
            elapsedTime = 0;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float normalizedElapsedTime = elapsedTime / duration;
                float eval = curve.Evaluate(normalizedElapsedTime);
                Vector3 finalTransform = Vector3.Lerp(pointB.position, pointA.position, eval);
                column.transform.position = finalTransform;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
