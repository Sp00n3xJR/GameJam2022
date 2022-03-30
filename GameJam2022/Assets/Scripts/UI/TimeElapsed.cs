using System.Collections;
using UnityEngine;
using TMPro;

public class TimeElapsed : MonoBehaviour
{
    [SerializeField]
    private TMP_Text UIObject;

    public int elapsedTime;

    void Start()
    {
        StartCoroutine(CountSeconds());
    }

    private IEnumerator CountSeconds()
    {
        // Might be horribly inefficient, but works for now.
        while (elapsedTime > -1)
        {
            yield return new WaitForSeconds(1f);
            elapsedTime += 1;
            UIObject.text = "Time Elapsed : " + elapsedTime;
        }
    }
}
