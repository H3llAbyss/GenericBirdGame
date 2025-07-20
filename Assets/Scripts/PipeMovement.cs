using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 5;
    public float deadZone = -6;

    private void Update()
    {
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
