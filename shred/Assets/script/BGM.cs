using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    AudioClip fastBGM;
    AudioClip NormalBGM;
    AudioSource audiosource;
    AudioMixer audioMixer;


    // Start is called before the first frame update
    void Start()
    {
        fastBGM = (AudioClip)Resources.Load("BGM\\伴奏");//音源取得
        NormalBGM = (AudioClip)Resources.Load("BGM\\通常BGM");
        audiosource =GetComponent<AudioSource>();
        audioMixer = (AudioMixer)Resources.Load("AudioMixer");//ミキサー取得。グループだけの取得はできなかった
        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("BGM")[0];//ミキサーグループの取得
        audiosource.clip = fastBGM;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audiosource.isPlaying) 
        {
            audiosource.clip = NormalBGM;
            audiosource.Play();
            
        }
    }
}
