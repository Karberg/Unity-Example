using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    [SerializeField] private Transform player;

    public float vertical;
    public float horizontal;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + horizontal, vertical, transform.position.z);
    }
}
