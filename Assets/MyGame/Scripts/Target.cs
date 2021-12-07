using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        StartCoroutine(WaitForDespawn(4));
    }
    private void OnMouseDown()
    {
        Debug.Log("clicked");
        Destroy(gameObject);
        gameManager.AddScore(1); 
    }

    IEnumerator WaitForDespawn(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
