using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//BGMの操作スクリプト
public class BGM : MonoBehaviour
{
    AudioClip fastBGM;
    AudioClip playBGM;
    AudioSource audiosource;
    AudioMixer audioMixer;

    void Start()
    {
        fastBGM = (AudioClip)Resources.Load("BGM\\伴奏");//音源取得
        playBGM = (AudioClip)Resources.Load("BGM\\通常BGM");
        audiosource =GetComponent<AudioSource>();
        audioMixer = (AudioMixer)Resources.Load("AudioMixer");//ミキサー取得。グループだけの取得はできなかった
        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("BGM")[0];//ミキサーグループの取得
        audiosource.clip = fastBGM;
        audiosource.Play();
    }

    void Update()
    {
        if(!audiosource.isPlaying) 
        {
            audiosource.clip = playBGM;
            audiosource.Play();
            
        }
    }
}
