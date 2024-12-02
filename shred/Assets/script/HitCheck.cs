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
    int fastbreak = 10;//第三関節
    int secondbreak = 20;//第二関節
    int thredbreak = 30;//第一関節
    int Hit_C = 0;

    //エフェクト取得用
    EffectManager EM;
    GameObject HitEffect;
    GameObject BreakEffect;

    //スクリプト内で音を入れてみる
    AudioClip HitSE_nail;
    AudioClip HitSE_bullet;
    AudioClip BreakSE;
    AudioSource audiosource;
    AudioMixer audioMixer;

    //カメラの振動
    camera cmr;
    bool isVibration;

    // Start is called before the first frame update
    void Start()
    {
        //カメラ振動bool取得
        cmr = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camera>();

        //エフェクト取得
        EM = GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>();
        HitEffect = EM.GetEffect1;
        BreakEffect = EM.GetEffect3;
        //スクリプト内で音を入れてみる
        HitSE_nail = (AudioClip)Resources.Load("大型ロボットの足音");//音源取得
        BreakSE = (AudioClip)Resources.Load("破壊音");//音源取得
        HitSE_bullet = (AudioClip)Resources.Load("大型ロボットの足音");//音源取得

        audiosource = gameObject.AddComponent<AudioSource>();//コンポ作成
        audioMixer = (AudioMixer)Resources.Load("AudioMixer");//ミキサー取得。グループだけの取得はできなかった
        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Hit")[0];//ミキサーグループの取得


        EnemyBullet = new EnemyBullet();//時間があればこっちもエフェクトと同じように書き換える
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

            audiosource.clip = HitSE_nail;//音源セット

            //Hitエフェクト再生
            Instantiate(HitEffect, transform.position, transform.rotation);

            //SE再生
            audiosource.Play();

            Hit_C++;



            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//左太もも
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;

                }
            }
            else if (gameObject.name == ("LeftCalf"))//左ふくらはぎ
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("LeftFoot"))//左足先
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("RightLeg"))//右太もも
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("RightCalf"))//右ふくらはぎ
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("RightFoot"))//右足先
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("LeftUpperArm"))//左上腕
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);

                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("LeftArm"))//左腕
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("LeftHand"))//左手
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("RightUpperArm"))//右上腕
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("RightArm"))//右腕
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("RightHand"))//右手
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
            else if (gameObject.name == ("Head"))//頭部
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                    cmr.GetSetVibLevel = 0.2f;
                    cmr.GetSetisViberation = true;
                }
            }
        }
        //弾に当たった場合
        if (col.gameObject.tag == ("EnemyBullet") && E_BulletHit)
        {


            audiosource.clip = HitSE_bullet;//音源セット

            //Hitエフェクト再生
            Instantiate(HitEffect, transform.position, transform.rotation);

            //SE再生
            audiosource.Play();

            Hit_C++;
            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//左太もも
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);

                }
            }
            else if (gameObject.name == ("LeftCalf"))//左ふくらはぎ
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("LeftFoot"))//左足先
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("RightLeg"))//右太もも
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("RightCalf"))//右ふくらはぎ
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("RightFoot"))//右足先
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("LeftUpperArm"))//左上腕
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);

                }
            }
            else if (gameObject.name == ("LeftArm"))//左腕
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("LeftHand"))//左手
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("RightUpperArm"))//右上腕
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("RightArm"))//右腕
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("RightHand"))//右手
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }
            else if (gameObject.name == ("Head"))//頭部
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    audiosource.clip = BreakSE;
                    audiosource.Play();
                    //breakエフェクト再生
                    Instantiate(BreakEffect, transform.position, transform.rotation);
                }
            }


        }
    }
}
