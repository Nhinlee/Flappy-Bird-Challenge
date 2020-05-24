using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFactory : MonoBehaviour
{
    // Audio Add Score
    [SerializeField] AudioClip _audioAddScore;
    [SerializeField] [Range(0f, 1f)] float _addScoreVol = 0.3f;

    // Audio Tap to Fly
    [SerializeField] AudioClip _audioFlyTap;
    [SerializeField] [Range(0f, 1f)] float _FlyTapVol = 0.2f;

    // Audio Click Button
    [SerializeField] AudioClip _audioClick;
    [SerializeField] [Range(0f, 1f)] float _ClickVol = 0.3f;

    // Audio Hurt and Dead
    [SerializeField] AudioClip _audioHurt;
    [SerializeField] [Range(0f, 1f)] float _HurtVol = 0.3f;

    // Cache main camera position
    Vector3 cameraPos;

    private void Start()
    {
        cameraPos = Camera.main.transform.position;
    }
    public void PlayAudioAddScore()
    {
        AudioSource.PlayClipAtPoint(_audioAddScore, cameraPos, _addScoreVol);
    }
    public void PlayAudioFlyTap()
    {
        AudioSource.PlayClipAtPoint(_audioFlyTap, cameraPos, _FlyTapVol);
    }

    public void PlayAudioHurt()
    {
        AudioSource.PlayClipAtPoint(_audioHurt, cameraPos, _HurtVol);
    }

    public void PlayAudioClick()
    {
        AudioSource.PlayClipAtPoint(_audioClick, cameraPos, _ClickVol);
    }

}
