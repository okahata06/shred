using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class HitCheck : MonoBehaviour
{
    EffectManager EM;
    GameObject effect;

    EnemyBullet EnemyBullet;

    BoxCollider BC;
    CapsuleCollider CC;



    bool E_BulletHit;
    int fastbreak=10;//第三関節
    int secondbreak=20;//第二関節
    int thredbreak=30;//第一関節
    int Hit_C = 0;


    //スクリプト内で音を入れてみる
    AudioClip HitSE_nail;
    AudioClip HitSE_bullet;
    AudioSource audiosource;
    AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        EM = GameObject.Find("effectManager").GetComponent<EffectManager>();
        effect = EM.Get1Effect;
        Debug.Log(EM.name);
        Debug.Log(effect.name);
        //スクリプト内で音を入れてみる
        HitSE_nail = (AudioClip)Resources.Load("大型ロボットの足音");//音源取得
        HitSE_bullet = (AudioClip)Resources.Load("大型ロボットの足音");//音源取得

        audiosource =gameObject.AddComponent<AudioSource>();//コンポ作成
        audioMixer= (AudioMixer)Resources.Load("AudioMixer");//ミキサー取得。グループだけの取得はできなかった
        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Hit")[0];//ミキサーグループの取得


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

            audiosource.clip = HitSE_nail;//音源セット

            Instantiate(effect,transform.position,transform.rotation);

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
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftCalf"))//左ふくらはぎ
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftFoot"))//左足先
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightLeg"))//右太もも
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightCalf"))//右ふくらはぎ
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightFoot"))//右足先
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftUpperArm"))//左上腕
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftArm"))//左腕
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftHand"))//左手
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightUpperArm"))//右上腕
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightArm"))//右腕
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightHand"))//右手
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("Head"))//頭部
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
        }
        //弾に当たった場合
        if ( col.gameObject.tag == ("EnemyBullet") && E_BulletHit)
        {


            audiosource.clip = HitSE_bullet;//音源セット

            //SE再生
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
    }
}
