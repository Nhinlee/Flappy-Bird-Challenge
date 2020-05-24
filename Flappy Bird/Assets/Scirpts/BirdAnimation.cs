using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    // Cache Component
    Animator _myAnime;
    BirdInput _birdInput;
    BirdMovement _birdMovement;
    // Parameter ID
    int _FlyTriggerParamID;
    int _HurtTriggerParamID;
    // Start is called before the first frame update
    void Start()
    {
        // Get component
        _myAnime = GetComponent<Animator>();
        _birdInput = GetComponentInParent<BirdInput>();
        _birdMovement = GetComponentInParent<BirdMovement>();

        // String to hash of parameter string
        _FlyTriggerParamID = Animator.StringToHash("Fly");
        _HurtTriggerParamID = Animator.StringToHash("Hurt");
    }

    private void Update()
    {
        if (_birdInput.isInputTap)
        {
            _myAnime.SetTrigger(_FlyTriggerParamID);
        }
        if(_birdMovement.IsDead)
        {
            _myAnime.SetTrigger(_HurtTriggerParamID);
        }
    }
}
