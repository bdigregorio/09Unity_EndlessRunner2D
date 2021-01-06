using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {
    
    private float minXBounds = -5;

    private void Update() {
        if (transform.position.x < minXBounds) {
            Destroy(gameObject);
        }
    }
}
