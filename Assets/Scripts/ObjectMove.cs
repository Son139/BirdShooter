using UnityEngine;
using System.Collections;

public class ObjectMove : MonoBehaviour 
{
	Rigidbody2D m_rb;

	GameManager m_gc;
	private void Awake()
    {
		m_rb = GetComponent<Rigidbody2D>();
    }
	private void Start()
    {
		m_gc = FindObjectOfType<GameManager>();
    }
	void FixedUpdate () 
	{
		transform.position = new Vector3(transform.position.x , transform.position.y - 0.05f, 0);
	}
	public void Die()
    {
		GameManager.Ins.BoomExplored++;
		Destroy(gameObject);
		GameGUIController.Ins.UpdateBoomCounting(GameManager.Ins.BoomExplored);
	}
}
