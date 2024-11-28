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
        fastBGM = (AudioClip)Resources.Load("BGM\\���t");//�����擾
        NormalBGM = (AudioClip)Resources.Load("BGM\\�ʏ�BGM");
        audiosource =GetComponent<AudioSource>();
        audioMixer = (AudioMixer)Resources.Load("AudioMixer");//�~�L�T�[�擾�B�O���[�v�����̎擾�͂ł��Ȃ�����
        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("BGM")[0];//�~�L�T�[�O���[�v�̎擾
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
