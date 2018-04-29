using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public PlatformGenerator platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerControl player;
    private Vector3 playerStartPoint;

    private PlatformDestroy[] platformList;

    private ScoreManager scoreManager;

    public DeathMenu deathMenu;

	// Use this for initialization
	void Start () 
    {
        platformStartPoint = platformGenerator.transform.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
        //deathMenu.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void RestartGame()
    {
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);

        deathMenu.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void ResetPlayer()
    {
        deathMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroy>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.transform.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }

   /* public IEnumerator RestartGameCo()
    {
        
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroy>();
        for(int i = 0;i<platformList.Length;i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.transform.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }*/
}
