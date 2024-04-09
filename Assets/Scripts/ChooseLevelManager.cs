using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChooseLevelManager : MonoBehaviour
{
    int levelsUnlocked;
    [SerializeField]
    private Button btNext, btPrev, btHome;
    [SerializeField]
    private Button[] ButtonOns;
    [SerializeField]
    private Button[] ButtonOffs;
    [SerializeField]
    private GameObject[] panels;
    private int dem = 0;
    private void Start()
    {
        levelsUnlocked = Pref.level;
        Debug.Log(levelsUnlocked);
        //ButtonOns[1].gameObject.SetActive(true);
        for (int i = 0; i < ButtonOns.Length; i++)
        {
            ButtonOns[i].gameObject.SetActive(false);
            ButtonOffs[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            ButtonOns[i].gameObject.SetActive(true);
            ButtonOffs[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (dem == 0) { btPrev.gameObject.SetActive(false); }
        else btPrev.gameObject.SetActive(true);
        if (dem == panels.Length - 1) { btNext.gameObject.SetActive(false); }
        else btNext.gameObject.SetActive(true);
    }
    public void LoadLevel(int IndexLevel)
    {
        SceneManager.LoadScene(IndexLevel);
    }
    public void _btNext()
    {
        dem++;
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[dem].SetActive(true);
        // hien thi panel tiep
    }

    public void _btPrev()
    {
        dem--;
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[dem].SetActive(true);

    }

    public void _bthome()
    {
        SceneManager.LoadScene("Menu");
    }
}
