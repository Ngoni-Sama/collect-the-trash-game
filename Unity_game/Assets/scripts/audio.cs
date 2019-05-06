using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour {

    // Use this for initialization
    AudioSource m_MyAudioSource;

    //Play the music
    bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
    }

    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal")==0)
        {
            //Play the audio you attach to the AudioSource component
            m_MyAudioSource.Stop();
            //Ensure audio doesn’t play more than once
        }
        //Check if you just set the toggle to false
        else{
            //Stop the audio
            m_MyAudioSource.Play();
            //Ensure audio doesn’t play more than once
      
        }
    }
}
