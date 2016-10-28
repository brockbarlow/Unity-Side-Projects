using UnityEngine;

public class TreeRotate : MonoBehaviour
{
    public void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 15, 0));
    }
}