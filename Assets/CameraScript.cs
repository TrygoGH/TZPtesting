using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform camOrigin;

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject target;

    [SerializeField] private Vector3 camOffset;

    private Transform targetOrientation;

    public float FOV
    {
        get { return _FOV; }
        set { _FOV = value; }
    }
    [SerializeField] private float _FOV = 60;

    [SerializeField] private float lerpSpeed;

    public enum CameraModes
    {
        FirstPerson, ThirdPerson, Cinematic,
    }

    public CameraModes CameraMode
    {
        get { return _cameraMode; }
        set
        {
            _cameraMode = value;

        }
    }

    [SerializeField] private CameraModes _cameraMode;

    public bool MouseVisible
    {
        get { return _mouseVisible; }
        set
        {
            _mouseVisible = value;
            UpdateSettings();
        }
    }
    [SerializeField] private bool _mouseVisible;

    private void Start()
    {
        UpdateSettings();
        camOrigin = transform;
        targetOrientation = target.transform.Find("Orientation");
        
    }
    private void LateUpdate()
    {
        cam.fieldOfView = FOV;
        switch (_cameraMode)
        {
            case CameraModes.FirstPerson:
                cam.transform.SetPositionAndRotation(target.transform.position, targetOrientation.rotation);
               
                break;
            case CameraModes.ThirdPerson:
                camOrigin.SetPositionAndRotation(MoveTo(target.transform.position, camOrigin.transform.position), targetOrientation.rotation);
                cam.transform.localPosition = camOffset;
                cam.transform.LookAt(target.transform.position);

                break;
            case CameraModes.Cinematic:
                cam.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
                
                break;
            default:
                break;
        }

    }

    private void UpdateSettings()
    {
        Cursor.visible = _mouseVisible;

        switch (_cameraMode)
        {
            case CameraModes.FirstPerson:
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case CameraModes.ThirdPerson:
             
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case CameraModes.Cinematic:
                Cursor.lockState = CursorLockMode.Locked;
                break;
            default:
                break;
        }
       
    }

    private Vector3 Move(Vector3 targetPosition, Vector3 currentPosition, float lerp = 1, bool useDeltaTime = true)
    {
        Vector3 newPosition;
        
        if(lerp != 1)
        {
            float deltaTime = useDeltaTime ? Time.deltaTime : 1;
            if(lerp > 1 || lerp < 0) Mathf.Clamp(lerp, 0, 1);
            lerp = Mathf.Pow(lerp, deltaTime);
            newPosition = Vector3.Lerp(targetPosition, currentPosition, lerp);
            return newPosition;
        }
        newPosition = targetPosition - currentPosition;
        return newPosition;
    }

    private Vector3 MoveTo(Vector3 targetPosition, Vector3 currentPosition, float lerp = 1, bool useDeltaTime = true)
    {
        Vector3 newPosition = currentPosition;
        Vector3 moveVector = Move(targetPosition, currentPosition, lerp, useDeltaTime);
        return newPosition += moveVector;
    }
}
   