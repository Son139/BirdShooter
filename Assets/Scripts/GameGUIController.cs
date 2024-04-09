using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameGUIController : Singleton<GameGUIController>
{
    public GameObject gameGui;
    public GameObject settingGui;

    public Dialog gameDialog;
    public Dialog pauseDialog;

    public Image fireRateFilled;
    public Text timerText;
    public Text killedCountingText;
    public Text boomCountingText;

    Dialog m_curDialog;

    

    public Dialog CurDialog { get => m_curDialog; set => m_curDialog = value; }
    
    //khong luu du lieu khi load scene
    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameGui(bool isShow)
    {
        if (isShow)
            gameGui.SetActive(true);
    }

    public void UpdateTimer(string time)
    {
        if (timerText)
            timerText.text = time;
    }


    public void UpdateKilledCounting(int killed)
    {
        if (killedCountingText)
            killedCountingText.text = "X" + killed.ToString();
    }

    public void UpdateBoomCounting(int boom)
    {
        if (boomCountingText)
            boomCountingText.text = "X" + boom.ToString();
    }

    public void UpdateFireRate(float rate)
    {
        if (fireRateFilled)
            fireRateFilled.fillAmount = rate;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;

        if (pauseDialog)
        {
            int m_currentLevel = SceneManager.GetActiveScene().buildIndex;
            if (m_currentLevel == 1)
            {
                pauseDialog.Show(true);
                pauseDialog.UpdateDialog("GAME PAUSE", "BEST KILLED: x" + Pref.bestScore1);
                m_curDialog = pauseDialog;
            }
            if (m_currentLevel == 2)
            {
                pauseDialog.Show(true);
                pauseDialog.UpdateDialog("GAME PAUSE", "BEST KILLED: x" + Pref.bestScore2);
                m_curDialog = pauseDialog;
            }
            if (m_currentLevel == 3)
            {
                pauseDialog.Show(true);
                pauseDialog.UpdateDialog("GAME PAUSE", "BEST KILLED: x" + Pref.bestScore3);
                m_curDialog = pauseDialog;
            }
            if (m_currentLevel == 4)
            {
                pauseDialog.Show(true);
                pauseDialog.UpdateDialog("GAME PAUSE", "BEST KILLED: x" + Pref.bestScore4);
                m_curDialog = pauseDialog;
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        if (m_curDialog)
            m_curDialog.Show(false);

        
    }

    public void BackToHome()
    {
        ResumeGame();

        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        if (m_curDialog)
            m_curDialog.Show(false);

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Main "+ (currentLevel + 1).ToString());
        //SceneManager.LoadScene("Main " + PlayerPrefs.GetInt("LevelChoose",1).ToString());

        GameManager.Ins.Start();

    }

    public void Replay()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingGame()
    {
        Time.timeScale = 0f;
        settingGui.SetActive(true);
        m_curDialog = pauseDialog;
    }

    public void ExitSettingGame()
    {
        ResumeGame();
        settingGui.SetActive(false);

    }
}


