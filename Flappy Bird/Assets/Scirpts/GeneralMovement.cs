using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovement : MonoBehaviour
{
    // Move Left Speed
    [SerializeField] float _moveLeftSpeed = 1f;

    // X-Axis Limit to disble this block and respawn at #BlockSpawner (Count in view world port)
    float _xLimit = -4f;

    private void FixedUpdate()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        Vector2 newPos = new Vector2(transform.position.x - _moveLeftSpeed * Time.deltaTime, transform.position.y);
        transform.position = newPos;
        if (transform.position.x <= _xLimit)
        {
            gameObject.SetActive(false); // pooling
        }
    }
}
