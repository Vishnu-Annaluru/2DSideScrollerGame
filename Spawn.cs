using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    System.Random random = new System.Random();
    float t = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t+=Time.deltaTime;
        int r = random.Next(30, 100);

        if (t > 15f)
        {
            Instantiate(enemy, new Vector2(r, -3), Quaternion.identity);
            t = 0f;
        }
    }
}
