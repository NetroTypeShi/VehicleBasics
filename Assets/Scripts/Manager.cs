using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool coinAdded;
    public int coinNumber;
    [SerializeField] Canvas pointCanvas;
    [SerializeField] RectTransform purpleRectTransform;
    [SerializeField] RectTransform pinkRectTransform;
    [SerializeField] RectTransform newPurpleRectTransform;

    [SerializeField] TMP_Text pointText;
    [SerializeField] AnimationCurve curve;
    [SerializeField] float duration = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        coinNumber = 0;
        coinAdded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(coinAdded == true)
        {
            pointText.text = coinNumber.ToString();
            StartCoroutine(PointsAnimation());
        }
        else
        {
            pointText.text = " ";
        }
    }
    private IEnumerator PointsAnimation()
    {
        while (true)
        {
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                //purple OR = 135/purple NR 495.7
                //pink OR = 0/pink NR = 360
                float normalizedElapsedTime = elapsedTime / duration;
                float eval = curve.Evaluate(normalizedElapsedTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
