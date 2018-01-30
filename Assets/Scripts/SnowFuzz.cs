using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFuzz : MonoBehaviour
{
    float speed = 0.25f;
    Renderer renderer;

    void Start() {
        renderer = GetComponent<Renderer>();
    }

    void Update() {
        float moveX = Time.time * -speed;
        float moveY = Time.time * (speed * 4);
        renderer.material.SetTextureOffset("_MainTex", new Vector2(moveX, moveY));
    }
}
