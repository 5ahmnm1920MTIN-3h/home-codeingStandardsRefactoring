﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject gameOverPanel;
    public Text scoreText;
    string defaultText;
    int score = 0;
    const string mainSceneKeyword = "MainScene";
    const string menuSceneKeyword = "MenuScene";


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("in Start");   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("in Update");
    }

    public void GameOver()
    {
        ObstacleSpawner.instance.isGameOver = true;
        StopScrolling();
        gameOverPanel.SetActive(true);
    }

    void StopScrolling()
    {
        TextureScroll[] scrollingObjects = FindObjectsOfType<TextureScroll>();

        foreach(TextureScroll item in scrollingObjects)
        {
            item.scrolBackground = false;
            Debug.Log(item.name);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("mainSceneKeyword");
    }

    public void Menu()
    {
        SceneManager.LoadScene("mainSceneKeyword");
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
