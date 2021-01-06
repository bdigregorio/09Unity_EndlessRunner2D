using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftParallax : MonoBehaviour
{
    public float speed = 15f;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
