using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PresidentController : MonoBehaviour
{
    public Transform player;
    protected NavMeshAgent president;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        president = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (president.velocity.magnitude >= 0.1f)
        {
            anim.SetFloat("presidentwalk", 1f); 
        }
        else
        {
            anim.SetFloat("presidentwalk", 0f); 
        }

        president.SetDestination(player.position);
    }
}
