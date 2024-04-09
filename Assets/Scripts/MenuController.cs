using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : Singleton<MenuController>
{
    public static MenuController instance;
    public GameObject SettingGUI;
    public Dialog gameDialog, howToPlayDialog;

    public GameObject musicOn, musicOff, soundOn, soundOff;
    public override void Awake()
    {
        //MakeSingleton(false);
        instance = this;
    }

    public void OnClickPlayBtn()
    {
        SceneManager.LoadScene("Level");
    }

    public void OnClickTrophyBtn()
    {
        gameDialog.Show(true);
        MenuController.Ins.gameDialog.UpdateDialog("YOUR BEST", "BEST LEVEL : " + Pref.level);
    }
    public void OnClickHowToPlayBtn()
    {
        howToPlayDialog.Show(true);
    }

    public void OnClickLeftBtn()
    {
        gameDialog.Show(false);
        howToPlayDialog.Show(false);
    }

    public void OnClickSettingBtn()
    {
        SettingGUI.SetActive(true);
    }

    public void OnClickExitBtn()
    {
        SettingGUI.SetActive(false);
    }

    public void OnClickMusicOnBtn()
    {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
        AudioController.Ins.OnClickMusicOffBtn();
    }
    public void OnClickMusicOffBtn()
    {
        musicOn.SetActive(true);
        musicOff.SetActive(false);
        AudioController.Ins.OnClickMusicOnBtn();
    }
    public void OnClickSoundOnBtn()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        AudioController.Ins.OnClickSoundOffBtn();
    }
    public void OnClickSoundOffBtn()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        AudioController.Ins.OnClickSoundOnBtn();
    }
    public void OnClickQuitBtn()
    {
        Application.Quit(); 
    }
}
