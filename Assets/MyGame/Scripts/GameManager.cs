using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject audioSourceTemplate;   
    [SerializeField] private GameObject targetTemplate;
    [SerializeField] private GameObject targetParent;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text winText;
    [SerializeField] private int winAmmount = 3;
    [SerializeField] private int border = 10;

    private Camera cam;
    private int score = 0;

    private void Start()
    {
        winText.text = null;
        scoreText.text = score.ToString();

        cam = Camera.main;

        StartCoroutine(SpawnTargets());
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playShootSound();
        }
        if(score >= winAmmount)
        {
            StopAllCoroutines();

            DestroyRemainingTargets();

            winText.text = "Gewonnen!";
        }
    }
   
    IEnumerator SpawnTargets()
    {
        while (true)
        {
            float ypos =   Random.Range(border, Screen.height - border);
            float xpos = Random.Range(border, Screen.width - border);

            Vector3 screenPos = new Vector3(xpos, 0, ypos);
            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.z, 1));

            GameObject newTarget;
            newTarget = Instantiate(targetTemplate, targetParent.transform);
            newTarget.transform.position = worldPos; 

            yield return new WaitForSeconds(2);
        }
    }
 
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    private void playShootSound()
    {
        GameObject audioSource = Instantiate(audioSourceTemplate);
        AudioSource source = audioSource.GetComponent<AudioSource>();
        source.Play();
    }

    private void DestroyRemainingTargets()
    {
        foreach(Transform child in targetParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
