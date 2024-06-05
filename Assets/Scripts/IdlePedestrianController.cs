using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePedestrianController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        int animationIndex = Random.Range(0, 6);
        
        animator.SetInteger("IdleIndex", animationIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
