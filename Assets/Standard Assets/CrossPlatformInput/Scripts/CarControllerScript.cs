using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CarControllerScript : MonoBehaviour
{

    public float maxTorque = 50f;
    public float rotateAngle = 45f;

    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public Transform[] tireMeshes = new Transform[4];

    // Update is called once per frame
    void Update () {

        UpdateMeshesPosition();

    }

    void FixedUpdate() {

        float steer = CrossPlatformInputManager.GetAxis("Horizontal");

        float finalAngle = steer * rotateAngle;

        wheelColliders[0].steerAngle = finalAngle;
        wheelColliders[3].steerAngle = finalAngle;

        for (int i = 0; i < 4; i++) {
            wheelColliders[i].motorTorque = maxTorque;
        }
    }

    void UpdateMeshesPosition() {

        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 pos;
            wheelColliders[i].GetWorldPose(out pos, out quat);

            tireMeshes[i].position = pos;
            tireMeshes[i].rotation = quat;
        }
    }
}
