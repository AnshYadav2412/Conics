using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 45f;
    [SerializeField] float offset = 2.5f;


    
    private void Update()
    {
        transform.position = new Vector3(1, 0, 0) * offset;
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
