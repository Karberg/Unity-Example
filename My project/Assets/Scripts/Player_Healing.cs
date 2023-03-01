using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Healing : MonoBehaviour
{
    
    public Animator animator_healing;
    [SerializeField] private LayerMask enemyLayers;



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            Healing();
        }
    }


    void Healing()
    {
        animator_healing.SetTrigger("Healing");
    }



}
