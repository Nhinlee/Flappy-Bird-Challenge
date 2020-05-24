using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    // IsDead
    public bool IsDead { get; private set; }
    // Cached Component
    BirdInput _birdInput;

    // Speed Field
    [SerializeField]
    float _maxForceUp = 12f;
    [SerializeField]
    float _flySpeed;
    [SerializeField]
    float _maxFallSpeed = -12f;
    [SerializeField]
    float _gravity = 1f;

    // How big the bird are
    public float _radius = 0.2f;
    float _maxHigh = 4.8f;

    // Audio Factory cached
    AudioFactory _audioFactory;

    // Floor cached
    [SerializeField] GameObject _floor;

    private void Start() 
    {
        // Get component
        _birdInput = GetComponent<BirdInput>();

        // Find audio factory to use easy later
        _audioFactory = FindObjectOfType<AudioFactory>();

    }

    private void FixedUpdate()
    {
        if(!IsDead)
        {
            // Update Fly Speed of the bird ( - Gravity to bird fall down)
            UpdateFlySpeed();
            // Check bird touch the Floor
            CheckTouchFloor();
            // Control position of the bird 
            // I call it Fly.
            Fly();
        }
    }

    private void CheckTouchFloor()
    {
        if (_floor.transform.position.y >= (this.transform.position.y - _radius))
        {
            Dead();
        }
    }

    private void UpdateFlySpeed()
    {
        if (_birdInput.isInputTap)
        {   
            // If player tap the button -> _flyspeed increase to max
            _flySpeed = _maxForceUp;

            // Play Audio Fly Tap
            _audioFactory.PlayAudioFlyTap();
        }
        else
        {
            // If player did not tap the button to jump -> _flyspeed descrease by gravity
            // every FixUpdate (0.2s ???)
            _flySpeed = Math.Max(_maxFallSpeed, _flySpeed - _gravity);
        }

    }

    private void Fly()
    {
        // Update position of the bird based on _flyspeed
        float newYPos = Math.Min(_maxHigh, transform.position.y + _flySpeed * Time.deltaTime);
        Vector2 newPos = new Vector2(transform.position.x, newYPos);
        transform.position = newPos;
    }

    public void Dead()
    {
        IsDead = true;
        _audioFactory.PlayAudioHurt();
        FindObjectOfType<GameLoader>().GameOver();
    }
}
