using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMove : MonoBehaviour
{
    public float moveSpeed = 0.01f;

    void Start()
    {

    }

    private void Update()
    {
        Vector2 rubyPostion = transform.position;
        rubyPostion.x = rubyPostion.x + moveSpeed * Input.GetAxis("Horizontal");
        rubyPostion.y = rubyPostion.y + moveSpeed * Input.GetAxis("Vertical");
        transform.position = rubyPostion;

    }
}