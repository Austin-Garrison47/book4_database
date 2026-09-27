using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class AccessDB : MonoBehaviour
{
    public TMP_Text namesText;
    public TMP_Text scoresText;

    void Start()
    {
        StartCoroutine(GetScores());
    }

    IEnumerator GetScores()
    {
        UnityWebRequest www =
            UnityWebRequest.Get("http://localhost/updateScore.php");

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string result = www.downloadHandler.text;

            namesText.text = "Names\n\n";
            scoresText.text = "Scores\n\n";

            string[] lines = result.Split('\n');

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(
                    new char[] { ' ', '\t' },
                    System.StringSplitOptions.RemoveEmptyEntries
                );

                if (parts.Length >= 2)
                {
                    namesText.text += parts[0] + "\n";
                    scoresText.text += parts[parts.Length - 1] + "\n";
                }
            }
        }
        else
        {
            namesText.text = "Names";
            scoresText.text = "Error loading scores";
            Debug.Log(www.error);
        }
    }
}