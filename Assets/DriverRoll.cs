using UnityEngine;

public class DriverRoll : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    private Vector3 _temp;

    private Quaternion _pp;

    private void Update()
    {
        _temp.x = parent.transform.eulerAngles.x;
        _temp.y = parent.transform.eulerAngles.y;

        gameObject.transform.eulerAngles = _temp;
    }
}
