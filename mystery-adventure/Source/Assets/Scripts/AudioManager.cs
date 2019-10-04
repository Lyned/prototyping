using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    static public AudioManager instance;

    [SerializeField] AudioSource ItemSound;
    [SerializeField] AudioSource ButtonSound;

    void Start()
    {
        instance = this;
    }

    public void PlaySound(string name)
    {
        switch (name)
        {
            case "Button":
                ButtonSound.Play();
                break;
            case "PickingUpItem":
                ItemSound.Play();
                break;
        }
    }


}
