using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private GameObject currentLevel;
    [SerializeField] private GameObject[] levels;
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        if(PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 0);
        }

        CreateNextLevel();
    }

    public void CreateNextLevel()
    {
       currentLevel = Instantiate(levels[PlayerPrefs.GetInt("level")]);
       PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
    }

    public void DestroyLevel()
    {
        Destroy(currentLevel);
    }

    public void CreateSameLevel()
    {

    }

    public void CreateSameLevelWithCheckPoint()
    {
        DestroyLevel();
        currentLevel = Instantiate(levels[PlayerPrefs.GetInt("level")]);
        gameManager.StartingEvents();
        gameManager.SendToCharacterPoint();
    }



}
