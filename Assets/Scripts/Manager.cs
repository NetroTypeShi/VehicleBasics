using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool coinAdded;
    public int coinNumber;
    float normalizedElapsedTime;
    float eval;
    float elapsedTime = 0f;
    [SerializeField] float duration = 1.5f;
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
    Vector3 finalScalePu;
    Vector3 finalScalePk;
    Quaternion newRotationPu;
    Quaternion newRotationPk;
    Quaternion ogRotationPu;
    Quaternion ogRotationPk;
    Quaternion finalRotationPu;
    Quaternion finalRotationPk;
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

        pointText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public IEnumerator PointsAnimation()
    {
        
       
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
                elapsedTime += Time.deltaTime;
                normalizedElapsedTime = elapsedTime / duration;
                eval = curve.Evaluate(normalizedElapsedTime);

                finalScalePu = Vector3.Lerp(ogScalePu, newScalePu, eval);
                finalRotationPu = Quaternion.Lerp(ogRotationPu, newRotationPu, eval);

                finalScalePk = Vector3.Lerp(ogScalePk, newScalePk, eval);
                finalRotationPk = Quaternion.Lerp(ogRotationPk, newRotationPk, eval);

                pointText.text = coinNumber.ToString();

                purpleRectTransform.localScale = finalScalePu;
                purpleRectTransform.localRotation = finalRotationPu;

                pinkRectTransform.localScale = finalScalePk;
                pinkRectTransform.localRotation = finalRotationPk;
                yield return new WaitForEndOfFrame();
        }

        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            normalizedElapsedTime = elapsedTime / duration;
            eval = curve.Evaluate(normalizedElapsedTime);

            finalScalePu = Vector3.Lerp(newScalePu, ogScalePu, eval);
            finalRotationPu = Quaternion.Lerp(newRotationPu, ogRotationPu, eval);

            finalScalePk = Vector3.Lerp(newScalePk, ogScalePk, eval);
            finalRotationPk = Quaternion.Lerp(newRotationPk, ogRotationPk, eval);

            pointText.text = " ";

            purpleRectTransform.localScale = finalScalePu;
            purpleRectTransform.localRotation = finalRotationPu;

            pinkRectTransform.localScale = finalScalePk;
            pinkRectTransform.localRotation = finalRotationPk;
            yield return new WaitForEndOfFrame();
        }

    }
}
