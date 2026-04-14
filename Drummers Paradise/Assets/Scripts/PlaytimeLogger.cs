using System.IO;
using UnityEngine;

public class PlaytimeLogger : MonoBehaviour
{
    float startTime;
    string path;
    float totalTime;

    void Start()
    {
        startTime = Time.time;
        path = Path.Combine(Application.persistentDataPath, "playtime.txt");

        // If file doesn't exist, create it with 0 total time
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "0");
        }

        // Read total time from file
        string fileContent = File.ReadAllText(path);
        float.TryParse(fileContent, out totalTime);

        Debug.Log("Total Playtime: " + FormatTime(totalTime));
    }

    void OnApplicationQuit()
    {
        float sessionTime = Time.time - startTime;
        totalTime += sessionTime;

        // Save updated total time
        File.WriteAllText(path, totalTime.ToString());
    }

    string FormatTime(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return hours + "h " + minutes + "m " + seconds + "s";
    }
}