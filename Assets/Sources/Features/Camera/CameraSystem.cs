using Entitas;
using UnityEngine;

public class CameraSystem : IExecuteSystem
{
    public void Execute()
    {
       	Debug.Log ("follow target - character view");
        // Camera _camera = Camera.main;
        // _camera.transform.position = Vector3.zero;        
    }
}
