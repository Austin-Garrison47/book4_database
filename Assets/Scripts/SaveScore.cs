using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class SaveScore : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_InputField scoreInput;

    public void AddScore()
    {
        StartCoroutine(UpdateScore());
    }

    IEnumerator UpdateScore()
    {
        string playerName = playerNameInput.text;
        string score = scoreInput.text;

        string url =
            "http://localhost/updateScore_b.php?name=" +
            UnityWebRequest.EscapeURL(playerName) +
            "&score=" +
            UnityWebRequest.EscapeURL(score);

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}