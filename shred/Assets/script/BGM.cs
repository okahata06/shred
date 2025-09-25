using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//BGM�̑���X�N���v�g
public class BGM : MonoBehaviour
{
    AudioClip fastBGM;
    AudioClip playBGM;
    AudioSource audiosource;
    AudioMixer audioMixer;

    void Start()
    {
        fastBGM = (AudioClip)Resources.Load("BGM\\���t");//�����擾
        playBGM = (AudioClip)Resources.Load("BGM\\�ʏ�BGM");
        audiosource =GetComponent<AudioSource>();
        audioMixer = (AudioMixer)Resources.Load("AudioMixer");//�~�L�T�[�擾�B�O���[�v�����̎擾�͂ł��Ȃ�����
        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("BGM")[0];//�~�L�T�[�O���[�v�̎擾
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
