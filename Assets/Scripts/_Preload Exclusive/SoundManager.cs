/*---------------------------------------------------
 * 制作日 : 2018年10月29日
 * 制作者：シスワントレサ
 * 内容　：サウンドマネージャー
 * 最後の更新：2018年10月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource musicSource;
    public AudioSource efxSource;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;
    
    // シングルサウンドクリップをプレイ
    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void RandomizeSFX (params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;

        efxSource.clip = clips[randomIndex];

        efxSource.Play();
    }
}
