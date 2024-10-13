using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float Xmove;
    private float Ymove;
    private float Xrotation;
    [SerializeField] private Transform PlayerBody;
    public Vector2 LockAxis;
    public float Sensitivity = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Xmove = LockAxis.x * Sensitivity * Time.deltaTime;
        Ymove = LockAxis.y * Sensitivity * Time.deltaTime;
        Xrotation -= Ymove;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Xrotation, 0, 0);
        PlayerBody.Rotate(Vector3.up * Xmove);
    }
}
