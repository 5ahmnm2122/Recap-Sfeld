using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyAfterPlay : MonoBehaviour
{
    private float length; 
    private void Awake()
    {
        length = gameObject.GetComponent<AudioSource>().clip.length;
        StartCoroutine(WaitForClipEnd());
    }

    IEnumerator WaitForClipEnd()
    {
        yield return new WaitForSeconds(length);
        Destroy(gameObject); 
    }
}
