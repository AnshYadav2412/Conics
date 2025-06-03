using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 45f;
    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
