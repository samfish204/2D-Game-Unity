using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    // fields
    [SerializeField] private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > 10) 
        {
            if (transform.parent == null)
            {
                Destroy(this.gameObject);
            } else
            {
                // double shot
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
