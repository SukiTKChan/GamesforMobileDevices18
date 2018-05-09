using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour 
{
    public static UIScript Instance { get; private set; }

	// Use this for initialization
	void Start () 
    {
        Instance = this;
	}

    [SerializeField]
    private Text pointsText;

    public void GetPoint()
    {
        GameManager.Instance.IncrementCounter();
    }

    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }

    public void Increment()
    {
        PlayGameScript.IncrementAchievement(GPGSIds.achievement_incremental, 20);
    }

    public void Unlock()
    {
        PlayGameScript.UnlockAchievement(GPGSIds.achievement_standard);
    }

    public void ShowAchievements()
    {
        PlayGameScript.showAchievementUI();
    }

    public void ShowLeaderboards()
    {
        PlayGameScript.showLeaderboardsUI();
    }

    public void UpdatePointsText()
    {
        pointsText.text = GameManager.Counter.ToString();
    }

}
