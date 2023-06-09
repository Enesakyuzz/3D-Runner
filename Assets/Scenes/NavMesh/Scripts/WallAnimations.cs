using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimations : MonoBehaviour
{
    public float speed = 1f;
    public float strength = 2.5f;
    private float randomOffset;
    void Start()
    {
        randomOffset = Random.Range(-strength,strength);
    }

  
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed * randomOffset) * strength;
        transform.position = pos;      
    }
}
 