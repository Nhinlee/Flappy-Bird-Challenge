using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Score
    public float Score { get; private set; }

    // Cache Component
    AudioFactory _audioFactory;

    private void Awake()
    {
        Screen.SetResolution(600, 1000, false);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // Cache AudioFactory to use easy later
        _audioFactory = FindObjectOfType<AudioFactory>();
    }

    public void AddScore(float score)
    {
        _audioFactory.PlayAudioAddScore();
        Score += score;
    }

    
}
