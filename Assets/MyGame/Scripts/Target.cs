using UnityEngine;


public class Target : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnMouseDown()
    {
        Debug.Log("clicked");
        Destroy(gameObject);
        gameManager.AddScore(1); 
    }
}
