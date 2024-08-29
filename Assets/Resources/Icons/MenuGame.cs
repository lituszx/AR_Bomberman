using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuGame : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();
    public float contador = 0;
    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        Vector3 spawn = new Vector3(Random.Range(transform.position.x + 0.3f, transform.position.x - 0.3f), transform.position.y, transform.position.z);
        if (contador >= 0.7f)
        {
            GameObject tempItem = Instantiate(Items[(Random.Range(0, Items.Count))].gameObject, spawn, Quaternion.Euler(0, 0, 0), transform);
            contador = 0;
        }
    }
}
