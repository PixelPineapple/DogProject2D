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
    public AudioSource followUpEfxSource;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;
    public float highVolume = 0.5f;
    
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
    
    public void PlayOnceEFX(AudioClip firstClip, AudioClip secondClip = null)
    {
        efxSource.volume = highVolume;

        // 一番目のefxAudioを設定して、起動させる。
        efxSource.clip = firstClip;
        efxSource.Play();

        // 二番目のefxAudioがあれば、設定する
        if (secondClip != null)
        {
            followUpEfxSource.clip = secondClip;
            Invoke("PlayFollowUpClip", firstClip.length);
        }

        StartCoroutine(loweringSounds());
    }
    
    private void PlayFollowUpClip()
    {
        followUpEfxSource.Play();
    }


    IEnumerator loweringSounds()
    {
        yield return new WaitForSeconds(1.0f);
        PreloadComponent.soundManager.efxSource.volume = 0.4f;
        yield return new WaitForSeconds(1.0f);
        PreloadComponent.soundManager.efxSource.volume = 0.3f;
    }
}
