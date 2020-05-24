using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    // Move Left Speed
    [SerializeField] float _moveLeftSpeed = 2f;

    // X-Axis Limit to disble this block and respawn at #BlockSpawner (Count in view world port)
    float _xLimit = -4f;

    // This length be calculated based on view world and it must be update when change size of the box
    // This is so dangerous but this is temporary solution and i wanna use BoxCollider :))
    float _edgeLength = 0.6f;

    // This Flag to declare this Block already add point or not
    bool _passed;

    // Cache Game Object
    BirdMovement _bird;
    GameManager _gameManager;

    // 
    private void Start()
    {
        _bird = FindObjectOfType<BirdMovement>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void FixedUpdate()
    {
        // Move left
        MoveLeft();
        // Check Collision
        CheckCollision();
    }

    private void Update()
    {
        // Check Add Score
        CheckAddScore();
    }

    private void CheckAddScore()
    {
        Vector2 birdPos = _bird.transform.position;
        if (!_passed && birdPos.x - _bird._radius > this.transform.position.x)
        {
            _passed = true;
            _gameManager.AddScore(0.5f);
        }
            
    }

    private void MoveLeft()
    {
        Vector2 newPos = new Vector2(transform.position.x - _moveLeftSpeed * Time.deltaTime, transform.position.y);
        transform.position = newPos;
        if(transform.position.x <= _xLimit)
        {
            // Reset Flag to add score again when spawner pull this gameObject at pool
            _passed = false;
            gameObject.SetActive(false); // pooling :))
        }
    }

    private void CheckCollision()
    {
        if (_bird.IsDead) return;
     
        Vector2 birdPos = _bird.transform.position;
        Vector2 blockPos = transform.position;
        if (birdPos.x - _bird._radius <= blockPos.x + _edgeLength
            && birdPos.x + _bird._radius >= blockPos.x)
        {
            if((gameObject.name.Contains("Top") && birdPos.y + _bird._radius >= blockPos.y)
                || gameObject.name.Contains("Down") && birdPos.y - _bird._radius <= blockPos.y)
            {
                _bird.Dead();
            }
        }
    }
}
