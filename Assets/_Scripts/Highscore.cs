using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    [System.Serializable]
    private class HighscoreEntry
    {
        public int wave;
        public int kills;
    }

    private class Highscores { public List<HighscoreEntry> highscoreEntryList; }

    private Transform highscoreTemplate;
    private Transform highScoreContainer;
    private List<Transform> highScoreTransformList;

    private void Awake()
    {
        highscoreTemplate = transform.Find("HSText");
        highScoreContainer = highscoreTemplate.Find("Container");

        Debug.Log(highScoreContainer);

        // Load highscores
        string jsonString = PlayerPrefs.GetString("Highscore");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Sort the highscores
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            for (int j = 0; j < highscores.highscoreEntryList.Count; j++)
                if (highscores.highscoreEntryList[j].wave > highscores.highscoreEntryList[i].wave)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;

                    if (highscores.highscoreEntryList[j].kills > highscores.highscoreEntryList[i].kills)
                    {
                        HighscoreEntry temp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = temp;
                    }     
        }

        // Create the highscores
        foreach (HighscoreEntry highScore in highscores.highscoreEntryList)
            CreateHighscoreEntry(highScore, highscoreTemplate, highScoreTransformList);

    }

    private void AddHighScore(int wave, int kills)
    {
        // Create highscore
        HighscoreEntry highscoreEntry = new HighscoreEntry { wave = wave, kills = kills};

        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("Highscore");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add highscore
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save highscore
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("Highscore", json);
        PlayerPrefs.Save();

    }

    private void CreateHighscoreEntry(HighscoreEntry highScoreEntry, Transform container, List<Transform> list)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(highScoreContainer, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * list.Count);

        int rank = list.Count + 1;
        string rankString;

        switch (rank)
        {
            default: rankString = rank + "TH";
                break;

            case 1: rankString = "ST";
                break;

            case 2: rankString = "ND";
                break;

            case 3: rankString = "RD";
                break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int wave = highScoreEntry.wave;
        entryTransform.Find("waveText").GetComponent<Text>().text = wave.ToString();

        int kills = highScoreEntry.kills;
        entryTransform.Find("scoreText").GetComponent<Text>().text = kills.ToString();

        list.Add(entryTransform);
    }
}
