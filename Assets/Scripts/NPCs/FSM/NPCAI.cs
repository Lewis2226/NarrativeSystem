using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCAI : MonoBehaviour
{
    Animator animator;
    public GameObject target;
    public float health = 1f;


    

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager._player;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("distance", Vector3.Distance(transform.position, target.transform.position));
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetFloat("healt", health);
    }

    public void UpdateHealt(float value)
    {
        health = value;
        animator.SetFloat("healt", health);
    }
    
}
