using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform Camera;
    public bool isPassed;
    RaycastHit hit;
    public float Range = 200f;
    public ParticleSystem MuzzleFlash;

    private float LastTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPassed && Time.time > LastTime + 0.15f) 
        {
            shoot();
            LastTime = Time.time;
        }
    }
    public void shoot()
    {
        MuzzleFlash.Play();
        if(Physics.Raycast(Camera.position ,Camera.forward ,out hit ,Range)) 
        {
            
        }
    }
}
