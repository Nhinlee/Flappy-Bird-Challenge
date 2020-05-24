using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    TextMeshProUGUI textScore;
    GameManager gameManager;
    void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        textScore.text = gameManager.Score.ToString();
    }
}
