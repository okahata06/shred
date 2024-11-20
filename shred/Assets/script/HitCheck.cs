using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class HitCheck : MonoBehaviour
{
    EnemyBullet EnemyBullet;

    BoxCollider BC;
    CapsuleCollider CC;

    bool E_BulletHit;
    int fastbreak=10;
    int secondbreak=20;
    int thredbreak=30;
    int Hit_C = 0;
    AudioClip HitSE;
    AudioSource audiosource;
    AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        //スクリプト内で音を入れてみる
        HitSE = (AudioClip)Resources.Load("破壊音_短い");//音源取得
        audiosource =gameObject.AddComponent<AudioSource>();//コンポ作成
        audiosource.clip = HitSE;//音源セット
        audioMixer= (AudioMixer)Resources.Load("AudioMixer");//ミキサー取得。グループだけの取得はできなかった
        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("SE")[0];//ミキサーグループの取得


        EnemyBullet = new EnemyBullet();
        E_BulletHit = EnemyBullet.E_FastHitGetSet;
        //種別コライダーの取得
        if (gameObject.GetComponent<BoxCollider>() != null)
        {
            BC = gameObject.GetComponent<BoxCollider>();
        }
        if (gameObject.GetComponent<CapsuleCollider>() != null)
        {
            CC = gameObject.GetComponent<CapsuleCollider>();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        E_BulletHit = EnemyBullet.E_FastHitGetSet;
        
        //一定以上当たったらサイズを消して破壊する
        if (col.gameObject.tag == ("Nail"))
        {
            audiosource.Play();
            Hit_C++;
            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//左太もも
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftCalf"))//左ふくらはぎ
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftFoot"))//左足先
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightLeg"))//右太もも
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightCalf"))//右ふくらはぎ
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightFoot"))//右足先
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftUpperArm"))//左上腕
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftArm"))//左腕
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftHand"))//左手
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightUpperArm"))//右上腕
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightArm"))//右腕
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightHand"))//右手
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("Head"))//頭部
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
        }
        //弾に当たった場合
        if ( col.gameObject.tag == ("EnemyBullet") && E_BulletHit)
        {
            Hit_C++;
            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//左太もも
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftCalf"))//左ふくらはぎ
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftFoot"))//左足先
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightLeg"))//右太もも
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightCalf"))//右ふくらはぎ
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightFoot"))//右足先
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftUpperArm"))//左上腕
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftArm"))//左腕
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftHand"))//左手
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightUpperArm"))//右上腕
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightArm"))//右腕
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightHand"))//右手
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("Head"))//頭部
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }


        }
    }
}
