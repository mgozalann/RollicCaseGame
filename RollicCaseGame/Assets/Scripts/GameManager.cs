using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText, nextLevelText;
    [SerializeField] Image[] steps;

    private Player player;
    [SerializeField] public GameObject playButton;

    int platformCount;
    int passedPlatform = 0;

    [Header("Pint")]
    public GameObject[] checkPoints;

    [Header("Controller")]
    private LevelController levelController;
    void Start()
    {
        StartingEvents();
        player = GameObject.FindObjectOfType<Player>();
        levelController = GameObject.FindObjectOfType<LevelController>();
        platformCount = GameObject.FindGameObjectsWithTag("Platform").Length;
    }
    void Update()
    {
       
    }
    public void StartingEvents()
    {       
        checkPoints = null;
        checkPoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        playButton.SetActive(true);
    }
    public void TapToPlay()
    {
        player.isMoving = true;
        playButton.SetActive(false);
    }


    public void GetLevelSteps()
    {
       if(passedPlatform < platformCount)
        {
            steps[passedPlatform].color = Color.red;
            passedPlatform++;
        }
        else
        {
            for(int i = 0; i < platformCount; i++)
            {
                steps[i].color = Color.red;
                levelController.CreateNextLevel();
                player.StartingEvents();
            }
        }
    }

    public void SendToCharacterPoint()
    {
        player.BackToTheCheckPoint(checkPoints[passedPlatform].transform);
    }
}
