using UnityEngine;

public class NameInput : MonoBehaviour
{
    public void SetPlayerName()
    {
        string playerName = GetComponent<TMPro.TMP_InputField>().text;
        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
        }
        GameManager.Instance.playerName = playerName;
    }
}
