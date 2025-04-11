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
    //RectTransform newPurpleRectTransform;
    //RectTransform newPinkRectTransform;
    [SerializeField] TMP_Text pointText;
    [SerializeField] AnimationCurve curve;
    Vector3 newScalePu;
    Vector3 newScalePk;
    Vector3 ogScalePu;
    Vector3 ogScalePk;
    Quaternion newRotationPu;
    Quaternion newRotationPk;
    Quaternion ogRotationPu;
    Quaternion ogRotationPk;
    [SerializeField] float duration = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        coinNumber = 0;
        coinAdded = false;
        ogRotationPu = Quaternion.Euler(0,0,45f);
        ogRotationPk = Quaternion.identity;
        ogScalePu = Vector3.zero;
        ogScalePk = Vector3.zero;

        newRotationPu = Quaternion.Euler(0, 0, 45f);
        newRotationPk = Quaternion.Euler(0, 0, 360f);
        newScalePu = new Vector3(0.35f, 0.35f, 0.35f);
        newScalePk = new Vector3(0.35f, 0.35f, 0.35f);

        purpleRectTransform.localScale = ogScalePu;
        purpleRectTransform.localRotation = ogRotationPu;
        pinkRectTransform.localScale = ogScalePk;
        pinkRectTransform.localRotation = ogRotationPk;
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
            StopCoroutine(PointsAnimation());
        }
    }
    private IEnumerator PointsAnimation()
    {
        while (true)
        {
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float normalizedElapsedTime = elapsedTime / duration;
                // ... interpolaciones y asignaciones ...
                float eval = curve.Evaluate(normalizedElapsedTime);
                Vector3 finalScalePu = Vector3.Lerp(ogScalePu, newScalePu, eval);
                Quaternion finalRotationPu = Quaternion.Lerp(ogRotationPu, newRotationPu, eval);
                Vector3 finalScalePk = Vector3.Lerp(ogScalePk, newScalePk, eval);
                Quaternion finalRotationPk = Quaternion.Lerp(ogRotationPk, newRotationPk, eval);
                purpleRectTransform.localScale = finalScalePu;
                purpleRectTransform.localRotation = finalRotationPu;
                pinkRectTransform.localScale = finalScalePk;
                pinkRectTransform.localRotation = finalRotationPk;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
