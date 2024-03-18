using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Destroy(this.gameObject, 3.0f);
        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
