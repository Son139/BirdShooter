using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float fireRate;
    float m_curFireRate;
    public GameObject viewFinder;

    bool m_isShooted;
    GameObject m_viewFinderClone;
    public GameObject PauseBtn;

    private void Awake()
    {
        m_curFireRate = fireRate;
    }

    private void Start()
    {
        if (viewFinder)
        {
           m_viewFinderClone = Instantiate(viewFinder, Vector3.zero, Quaternion.identity);
        }
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Shoot(mousePos);

        if (Input.GetMouseButtonDown(0) &&!m_isShooted &&!GameManager.Ins.IsGameover)
        {
            Shoot(mousePos);
        }

        if (m_isShooted)
        {
            m_curFireRate -= Time.deltaTime;

            if (m_curFireRate <= 0)
            {
                m_isShooted = false;

                m_curFireRate = fireRate;
            }

            GameGUIController.Ins.UpdateFireRate(m_curFireRate/fireRate);
        }
        if (m_viewFinderClone)
        {
            m_viewFinderClone.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        }
        if (GameManager.Ins.IsGameover)
        {
            PauseBtn.SetActive(false);
        }
    }

    void Shoot(Vector3 mousePos)
    {
        m_isShooted = true;

        Vector3 shootDir = Camera.main.transform.position - mousePos;
        
        //lam tron
        shootDir.Normalize();

        //
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shootDir);

        if (hits != null & hits.Length > 0 && !GameManager.Ins.IsGameover)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                if (hit != null && hit.collider)
                {
                    if (hit.collider && (Vector3.Distance((Vector2)hit.collider.transform.position, (Vector2)mousePos) <= 0.4f)){
                        Debug.Log(hit.collider.name);
                        Bird bird = hit.collider.GetComponent<Bird>();
                        ObjectMove boom = hit.collider.GetComponent<ObjectMove>();
                        //bird bi ban trung
                        if (bird)
                        {
                            bird.Die(); 

                        }
                        if (boom)
                        {
                            boom.Die();
                        }
                    }
                }
            }
            CineController.Ins.ShakeTrigger();

            AudioController.Ins.PlaySound(AudioController.Ins.shooting);
        }
        
    }
    
}
