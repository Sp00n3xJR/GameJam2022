using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class LevelEndUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ElapsedTimeObj;

    [SerializeField]
    private TMP_Text FinalTimeObj;

    void OnEnable()
    {
        FinalTimeObj.text = "Final time: " + ElapsedTimeObj.GetComponent<ElapsedTime>().elapsedTime.ToString() + " seconds!";
    }
}
