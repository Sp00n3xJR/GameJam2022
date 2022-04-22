using UnityEngine;
using UnityEditor;
using System;

public class Upgrades : MonoBehaviour
{
    public Upgrade upgrades;
    public int UpgradeAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject Player = collision.gameObject;

            switch (upgrades)
            {
                case Upgrade.Jumping:
                    Player.GetComponent<PlayerMovement>().Jumping = true;
                    break;
                case Upgrade.DoubleJumping:
                    if (!Player.GetComponent<PlayerMovement>().Jumping)
                    {
                        Player.GetComponent<PlayerMovement>().Jumping = true;
                        return;
                    }
                    else
                    {
                        Player.GetComponent<PlayerMovement>().DoubleJumping = true;
                        break;
                    }
                case Upgrade.Speed:
                    Player.GetComponent<PlayerMovement>().Speed += UpgradeAmount;
                    break;
                case Upgrade.JumpHeight:
                    Player.GetComponent<PlayerMovement>().JumpHeight.y += UpgradeAmount;
                    break;
            }
            gameObject.SetActive(false);
        }
    }

    public enum Upgrade
    {
        Speed,
        JumpHeight,
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

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(upgradeScript.upgrades)))
        {
            switch(upgradeScript.upgrades)
            {
                case Upgrades.Upgrade.Speed:
                    upgradeScript.UpgradeAmount = EditorGUILayout.IntField(upgradeScript.UpgradeAmount);
                    serializedObject.Update();
                    break;
                case Upgrades.Upgrade.JumpHeight:
                    upgradeScript.UpgradeAmount = EditorGUILayout.IntField(upgradeScript.UpgradeAmount);
                    serializedObject.Update();
                    break;
            }
        }
    }
}