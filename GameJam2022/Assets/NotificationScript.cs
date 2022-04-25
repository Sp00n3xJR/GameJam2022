using UnityEngine;
using TMPro;

public class NotificationScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text notifObject;

    public void NewNotif(string newText)
    {
        notifObject.text = newText;
        Invoke("ClearNotif", 2);
    }

    public void ClearNotif()
    {
        notifObject.text = null;
    }
}