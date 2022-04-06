using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlatformController : MonoBehaviour
{
    public int objectCount = 0;
    [SerializeField] int neededObjectCount;
    [SerializeField] Text objectCountCheckText;
    [SerializeField] GameObject plane, gecitSag,gecitSol;
    Player player;
    GameManager gameManager;
    LevelController levelController;    

    private bool islemlerBasladiMi;
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        levelController = FindObjectOfType<LevelController>();
        islemlerBasladiMi = false;

    }
    void Update()
    {
        objectCountCheckText.text = (objectCount.ToString() + "/" + neededObjectCount.ToString());
    }

    public void ObjeZemineÇarptý()
    {
        if(!islemlerBasladiMi)
        { 
            StartCoroutine(Couru());
            islemlerBasladiMi = true;
        }
    }


    IEnumerator Couru()
    {
        yield return new WaitForSeconds(2.5f);
        if(objectCount >= neededObjectCount)
        {
            plane.transform.DOLocalMove(new Vector3(0, -transform.position.y, 0), 1f);
            plane.transform.DOScale(new Vector3(1, 1, 1.05f), 1f).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(1f);
            gecitSag.GetComponent<Animator>().enabled = true;
            gecitSol.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(1f);
            player.SizeUp();
            gameManager.GetLevelSteps();
        }
        else
        {
            levelController.CreateSameLevelWithCheckPoint();
            islemlerBasladiMi = true;
        }
    }
}
