using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenuControl : MonoBehaviour
{
    private float speed = 0.005f;
    public float contador = 0;
    void Update()
    {
        contador += Time.deltaTime;
        transform.Translate(Vector3.down * speed);
        if (contador >= 4)
        {
            Destroy(gameObject);
        }
    }
}
