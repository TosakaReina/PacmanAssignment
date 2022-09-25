using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTurnAudioClip : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Audio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Audio()
    {
        for(int i = 0; i < audioClips.Length; i++)
        {
            this.GetComponent<AudioSource>().clip = audioClips[i];
            this.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(audioClips[i].length);
        }
    }
}
