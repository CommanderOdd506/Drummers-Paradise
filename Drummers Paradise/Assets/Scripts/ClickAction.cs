using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    [Header("Resource Settings")]
    public ResourceType resourceType;
    public float clickValue = 1f;

    [Header("Sound Settings")]
    public AudioSource audioSource;
    public List<AudioClip> drumSounds;
    private int currentSoundIndex = 0;

    public float beatResetTime;

    private float clickTimer;


    public void OnClickHandler()
    {
        ResourceManager.Instance.AddResource(resourceType, clickValue);
    }

    public void OnClickMoney()
    {

        ResourceManager.Instance.AddResource(ResourceType.Money, clickValue);
        clickTimer = 0;
        PlayNextSound();
    }

    public void OnClickFollowers()
    {
        ResourceManager.Instance.AddResource(ResourceType.Followers, clickValue);
    }

    private void PlayNextSound()
    {
        if (drumSounds.Count == 0)
        {
            Debug.LogError("NO SOUNDS IN LIST");
            return;
        }


        audioSource.PlayOneShot(drumSounds[currentSoundIndex], 1f);

        currentSoundIndex = (currentSoundIndex + 1) % drumSounds.Count;
    }

    void Update()
    {
        clickTimer += Time.deltaTime;
        if(clickTimer > beatResetTime)
        {
            currentSoundIndex = 0;
        }
    }
}
