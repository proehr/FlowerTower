using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector3 diff = Vector3.RotateTowards(transform.forward, transform.position - cameraTransform.position , Time.deltaTime * 1f, 0.0f);
        transform.rotation = Quaternion.LookRotation(diff);
    }
}
