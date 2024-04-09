using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Bird[] birdsPrefabs;
    public float spawnTime;
    public float spawnBoomTime;
    public ObjectMove boom;
    bool m_isGameover;

    public int timeLimit;
    int m_curTimeLimit;
    public int birdKilled;
    public GameObject ReplayBtn, ResumBtn;
    int m_birdKilled;
    int m_boomExplored;

    public bool IsGameover { get => m_isGameover; set => m_isGameover = value; }
    public int BirdKilled { get => m_birdKilled; set => m_birdKilled = value; }

    public int BoomExplored { get => m_boomExplored; set => m_boomExplored = value; }

    // ko de bien o lop nay khi ke thua sang lop khac bi luu gia tri
    public override void Awake()
    {
        MakeSingleton(false);

        m_curTimeLimit = timeLimit;

        //PlayerPrefs.DeleteAll();
    }

    public override void Start()
    {
        //dem thoi gian GameSpawn
        StartCoroutine(GameSpawn());
        //dem thoi gian curTimeLimit
        StartCoroutine(TimeCountDown());

        StartCoroutine(GameSpawnBoom());

        GameGUIController.Ins.ShowGameGui(true);
        GameGUIController.Ins.UpdateKilledCounting(m_birdKilled);
        GameGUIController.Ins.UpdateBoomCounting(m_boomExplored);
    }

    

    IEnumerator TimeCountDown()
    {
        while (m_curTimeLimit>0)
        {
            yield return new WaitForSeconds(1f);
            m_curTimeLimit--;
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            if (m_boomExplored>=3 && currentLevel == 2)
            {
                m_isGameover = true;
                GameGUIController.Ins.gameDialog.UpdateDialog("YOU LOST", "SCORE : x" + m_birdKilled);
                ReplayBtn.SetActive(false);
                ResumBtn.SetActive(true);
                GameGUIController.Ins.gameDialog.Show(true);
                GameGUIController.Ins.CurDialog = GameGUIController.Ins.gameDialog;
                m_curTimeLimit = 0;
                GameGUIController.Ins.UpdateTimer(IntToTime(m_curTimeLimit));
                AudioController.Ins.PlaySound(AudioController.Ins.lose);
                break;
            }
            if (m_boomExplored >= 2 && currentLevel == 3)
            {
                m_isGameover = true;
                GameGUIController.Ins.gameDialog.UpdateDialog("YOU LOST", "SCORE : x" + m_birdKilled);
                ReplayBtn.SetActive(false);
                ResumBtn.SetActive(true);
                GameGUIController.Ins.gameDialog.Show(true);
                GameGUIController.Ins.CurDialog = GameGUIController.Ins.gameDialog;
                m_curTimeLimit = 0;
                GameGUIController.Ins.UpdateTimer(IntToTime(m_curTimeLimit));
                AudioController.Ins.PlaySound(AudioController.Ins.lose);
                break;
            }
            if (m_boomExplored >= 1 && currentLevel == 4)
            {
                m_isGameover = true;
                GameGUIController.Ins.gameDialog.UpdateDialog("YOU LOST", "SCORE : x" + m_birdKilled);
                ReplayBtn.SetActive(false);
                ResumBtn.SetActive(true);
                GameGUIController.Ins.gameDialog.Show(true);
                GameGUIController.Ins.CurDialog = GameGUIController.Ins.gameDialog;
                m_curTimeLimit = 0;
                GameGUIController.Ins.UpdateTimer(IntToTime(m_curTimeLimit));
                AudioController.Ins.PlaySound(AudioController.Ins.lose);
                break;
            }
            if (m_curTimeLimit <= 0)
            {
                m_isGameover = true;

                int m_currentLevel = SceneManager.GetActiveScene().buildIndex;
                if (m_birdKilled >= birdKilled && m_currentLevel == 1)
                {
              
                    if (m_birdKilled > Pref.bestScore1)
                    {
                        GameGUIController.Ins.gameDialog.UpdateDialog("YOU WON", "NEW BEST KILLED : x" + m_birdKilled);
                        AudioController.Ins.PlaySound(AudioController.Ins.win);
                    }
                    else if (m_birdKilled <= Pref.bestScore1)
                    {
                        GameGUIController.Ins.gameDialog.UpdateDialog("YOW WON", "YOUR BEST KILLED : x" + Pref.bestScore1);
                        AudioController.Ins.PlaySound(AudioController.Ins.win);
                    }
                    Pref.bestScore1 = m_birdKilled;
                    Pref.level = m_currentLevel + 1;

                } else if(m_birdKilled < birdKilled && m_currentLevel == 1)
                {
                    GameGUIController.Ins.gameDialog.UpdateDialog("YOU LOST", "SCORE : x" + m_birdKilled);
                    AudioController.Ins.PlaySound(AudioController.Ins.lose);
                    ReplayBtn.SetActive(false);
                    ResumBtn.SetActive(true);

                }
                if (m_birdKilled >= birdKilled && m_currentLevel == 2)
                {

                    if (m_birdKilled > Pref.bestScore2)
                    {
                        GameGUIController.Ins.gameDialog.UpdateDialog("YOU WON", "NEW BEST KILLED : x" + m_birdKilled);
                        AudioController.Ins.PlaySound(AudioController.Ins.win);
                    }
                    else if (m_birdKilled <= Pref.bestScore2)
                    {
                        GameGUIController.Ins.gameDialog.UpdateDialog("YOW WON", "YOUR BEST KILLED : x" + Pref.bestScore2);
                        AudioController.Ins.PlaySound(AudioController.Ins.win);
                    }
                    Pref.bestScore2 = m_birdKilled;
                    Pref.level = m_currentLevel + 1;

                }
                else if (m_birdKilled < birdKilled && m_currentLevel == 2)
                {
                    GameGUIController.Ins.gameDialog.UpdateDialog("YOU LOST", "SCORE : x" + m_birdKilled);
                    AudioController.Ins.PlaySound(AudioController.Ins.lose);
                    ReplayBtn.SetActive(false);
                    ResumBtn.SetActive(true);

                }
                if (m_birdKilled >= birdKilled && m_currentLevel == 3)
                {

                    if (m_birdKilled > Pref.bestScore3)
                    {
                        GameGUIController.Ins.gameDialog.UpdateDialog("YOU WON", "NEW BEST KILLED : x" + m_birdKilled);
                        AudioController.Ins.PlaySound(AudioController.Ins.win);
                    }
                    else if (m_birdKilled <= Pref.bestScore3)
                    {
                        GameGUIController.Ins.gameDialog.UpdateDialog("YOW WON", "YOUR BEST KILLED : x" + Pref.bestScore3);
                        AudioController.Ins.PlaySound(AudioController.Ins.win);
                    }
                    Pref.bestScore3 = m_birdKilled;
                    Pref.level = m_currentLevel + 1;

                }
                else if (m_birdKilled < birdKilled && m_currentLevel == 3)
                {
                    GameGUIController.Ins.gameDialog.UpdateDialog("YOU LOST", "SCORE : x" + m_birdKilled);
                    AudioController.Ins.PlaySound(AudioController.Ins.lose);
                    ReplayBtn.SetActive(false);
                    ResumBtn.SetActive(true);

                }
                if (m_birdKilled >= birdKilled && m_currentLevel == 4)
                {

                    if (m_birdKilled > Pref.bestScore4)
                    {
                        GameGUIController.Ins.gameDialog.UpdateDialog("YOU WON", "NEW BEST KILLED : x" + m_birdKilled);
                        AudioController.Ins.PlaySound(AudioController.Ins.win);
                    }
                    else if (m_birdKilled <= Pref.bestScore4)
                    {
                        GameGUIController.Ins.gameDialog.UpdateDialog("YOW WON", "YOUR BEST KILLED : x" + Pref.bestScore4);
                        AudioController.Ins.PlaySound(AudioController.Ins.win);
                    }
                    Pref.bestScore4 = m_birdKilled;
                    Pref.level = m_currentLevel + 1;

                }
                else if (m_birdKilled < birdKilled && m_currentLevel == 4)
                {
                    GameGUIController.Ins.gameDialog.UpdateDialog("YOU LOST", "SCORE : x" + m_birdKilled);
                    AudioController.Ins.PlaySound(AudioController.Ins.lose);
                    ReplayBtn.SetActive(false);
                    ResumBtn.SetActive(true);

                }

                GameGUIController.Ins.gameDialog.Show(true);
                GameGUIController.Ins.CurDialog = GameGUIController.Ins.gameDialog;
            } 
            GameGUIController.Ins.UpdateTimer(IntToTime(m_curTimeLimit));
        }
    }

    IEnumerator GameSpawn()
    {
            while (!m_isGameover)
            {
                SpawnBird();
                yield return new WaitForSeconds(spawnTime);
            }
    }

    IEnumerator GameSpawnBoom()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel > 1)
        {
            while (!m_isGameover)
            {
                SpawnBoom();
                yield return new WaitForSeconds(spawnBoomTime);
            }
        }
    }

    void SpawnBird()
    {
        Vector3 spawnPos = Vector3.zero;

        float randCheck = Random.Range(0f, 1f);
          
        if (randCheck >= 0.5f)
        {
            spawnPos = new Vector3(12, Random.Range(1.5f, 4f));
        }
        else
        {
            spawnPos = new Vector3(-12, Random.Range(1.5f, 4f), 0);
        }

        if (birdsPrefabs != null && birdsPrefabs.Length > 0)
        {
            int randIdx = Random.Range(0, birdsPrefabs.Length);

            if (birdsPrefabs[randIdx] != null)
            {
                Bird birdClone = Instantiate(birdsPrefabs[randIdx], spawnPos, Quaternion.identity);
            }
        }
    }

    public void SpawnBoom()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-8f, 8f), 6);

        if (boom)
        {
            Instantiate(boom, spawnPos, Quaternion.identity);
        }
    }


    string IntToTime(int time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);

        return minutes.ToString("00") + " : " + seconds.ToString("00");
    }
}
