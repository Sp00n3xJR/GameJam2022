using System.Collections;
using UnityEngine;
using TMPro;

public class ElapsedTime : MonoBehaviour
{
    [SerializeField]
    private TMP_Text UIObject;

    [SerializeField]
    private GameObject EndUI;

    public int elapsedTime;

    void Start()
    {
        StartCoroutine(CountSeconds());
    }

    // Horrible to put this in Update()
    // but for a very small project like this which
    // will probably never be touched again does the
    // performance impact really matter?
    void Update()
    {
        if (EndUI.activeSelf)
        {
            StopAllCoroutines();
            UIObject.text = "";
        }
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
