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


    public void OnClickHandler()
    {
        ResourceManager.Instance.AddResource(resourceType, clickValue);
    }

    public void OnClickMoney()
    {

        ResourceManager.Instance.AddResource(ResourceType.Money, clickValue);

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


        AudioSource.PlayClipAtPoint(drumSounds[currentSoundIndex], Vector3.zero, 1f);

        currentSoundIndex = (currentSoundIndex + 1) % drumSounds.Count;
    }
}
