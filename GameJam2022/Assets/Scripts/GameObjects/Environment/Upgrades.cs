using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public Upgrade upgrades;
    public float UpgradeAmount;
    public TMP_Text UpgradeNotif;

    private GameObject pointObject;
    private GameObject notifObject;

    private void Start()
    {
        notifObject = GameObject.Find("Notification");
        UpgradeNotif = notifObject.GetComponent<TextMeshProUGUI>();
        pointObject = gameObject;

        StartCoroutine(nameof(ChangeColor));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject Player = collision.gameObject;

            switch (upgrades)
            {
                case Upgrade.Jumping:
                    Player.GetComponent<PlayerMovement>().Jumping = true;
                    UpgradeNotif.GetComponent<NotificationScript>().NewNotif("+ Jumping");
                    break;
                case Upgrade.DoubleJumping:
                    if (!Player.GetComponent<PlayerMovement>().Jumping)
                    {
                        Player.GetComponent<PlayerMovement>().Jumping = true;
                        UpgradeNotif.GetComponent<NotificationScript>().NewNotif("+ Jumping");
                        return;
                    }
                    else
                    {
                        UpgradeNotif.GetComponent<NotificationScript>().NewNotif("+ DoubleJumping");
                        Player.GetComponent<PlayerMovement>().DoubleJumping = true;
                        break;
                    }
                case Upgrade.Speed:
                    Player.GetComponent<PlayerMovement>().Speed += UpgradeAmount;
                    UpgradeNotif.GetComponent<NotificationScript>().NewNotif("+ " + UpgradeAmount.ToString() + " Speed");
                    break;
                case Upgrade.JumpHeight:
                    Player.GetComponent<PlayerMovement>().JumpHeight.y += UpgradeAmount;
                    UpgradeNotif.GetComponent<NotificationScript>().NewNotif("+ " + UpgradeAmount.ToString() + " JumpHeight");
                    break;
                case Upgrade.JumpDelay:
                    Player.GetComponent<PlayerMovement>().OrgJumpDelay -= UpgradeAmount;
                    UpgradeNotif.GetComponent<NotificationScript>().NewNotif("- " + UpgradeAmount.ToString() + " JumpDelay");
                    break;
            }
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ChangeColor()
    {
        while (pointObject.activeSelf)
        {
            yield return new WaitForSeconds(0.2f);
            pointObject.GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

    public enum Upgrade
    {
        Speed,
        JumpHeight,
        JumpDelay,
        Jumping,
        DoubleJumping
    }
}

[CustomEditor(typeof(Upgrades))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        Upgrades upgradeScript = target as Upgrades;

        upgradeScript.upgrades = (Upgrades.Upgrade)EditorGUILayout.EnumPopup(upgradeScript.upgrades);

        using var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(upgradeScript.upgrades));
        switch (upgradeScript.upgrades)
        {
            case Upgrades.Upgrade.Speed:
                upgradeScript.UpgradeAmount = EditorGUILayout.FloatField(upgradeScript.UpgradeAmount);
                break;
            case Upgrades.Upgrade.JumpHeight:
                upgradeScript.UpgradeAmount = EditorGUILayout.FloatField(upgradeScript.UpgradeAmount);
                break;
            case Upgrades.Upgrade.JumpDelay:
                upgradeScript.UpgradeAmount = EditorGUILayout.FloatField(upgradeScript.UpgradeAmount);
                break;
        }
        serializedObject.Update();
    }
}