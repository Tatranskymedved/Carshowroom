using UnityEngine;
using System.Collections;

//Origin https://github.com/LiberalMiser/Colour-Picker/blob/master/Assets/Scripts/CameraMotionControls.cs
public class CameraMotionControl : MonoBehaviour
{
    [Header("Automatic Panning")]
    [Tooltip("Toggles whether the camera will automatically rotate around it's target")]
    public bool autoPan = false;
    [Tooltip("The axis on which the camera rotates. Use a value of 1 to rotate in one direction and -1 to rotate in another direction.")]
    [Vector3Range(-1, 1, -1, 1, -1, 1, true)]
    public Vector3 rotationDirection = new Vector3(0f, 1f, 0f);
    [Tooltip("The speed at which the camera will auto-pan.")]
    public float autoPanRotationSpeed = 10f;

    [Header("Manual Panning")]
    [Tooltip("The smoothness coming to a stop of the camera afer the uses pans the camera and releases. Lower values result in significantly smoother results. This means the camera will take longer to stop rotating")]
    public float rotationSmoothing = 2f;
    [Tooltip("The object the camera will focus on.")]
    public Transform target;
    [Tooltip("How sensative the camera-panning is when the user pans -- the speed of panning.")]
    public float panSensitivity = 180f;
    [Tooltip("The min and max distance along the Y-axis the camera is allowed to move when panning.")]
    public Vector2 panLimit = new Vector2(5, 80);
    [Tooltip("The position along the Z-axis the camera game object is.")]
    public float distance = 5;

    [Header("Zoom")]
    [Tooltip("Determines whether the camera will zoom by moving on the Z-axis or by adjusting the camera's field of view.")]
    public ZoomType zoomType = ZoomType.FieldOfView;
    [Tooltip("The minimum and maximum range the camera can zoon in.")]
    public Vector2 cameraZoomRange;
    public float zoomSoothness = 0.1f;
    [Tooltip("How sensative the camera zooming is -- the speed of the zooming.")]
    public float zoomSensitivity;

    private Camera cam;
    private bool mouseClickjudge;
    private float cameraZDistance;
    new private Transform transform;
    private Vector2 startAngle;
    private float xVelocity = 0f;
    private float yVelocity = 0f;
    private float xRotationAxis = 0.0f;
    private float yRotationAxis = 0.0f;
    private float zoomVelocity = 0f;
    private float rotationSpeed = 0f;
    private Vector2 cameraMovement = Vector2.zero;

    [Header("Listening on channels")]
    [Tooltip("The Camera control listens to this event, fired by objects in any scene, to adapt camera position")]
    [SerializeField] private BoolStateSO autoRotationStateSO = default;
    [SerializeField] private FloatEventChannelSO zoomEventSO = default;
    [SerializeField] private Vector2EventChannelSO cameraMoveEventSO = default;

    public enum PanAxis
    {
        xAxis,
        yAxis,
        zAxis
    }

    public enum ZoomType
    {
        ZAxisPosition,
        FieldOfView
    }

    private void Awake()
    {
        cam = GetComponent<Camera>();
        transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        if (autoRotationStateSO != null)
        {
            autoRotationStateSO.OnEventRaised += OnAutoRotationChanged;
            OnAutoRotationChanged(autoRotationStateSO.IsOn);
        }
        if (zoomEventSO != null)
            zoomEventSO.OnEventRaised += OnZoomChanged;
        if (cameraMoveEventSO != null)
            cameraMoveEventSO.OnEventRaised += OnCameraMove;
    }

    private void OnDisable()
    {
        if (autoRotationStateSO != null)
            autoRotationStateSO.OnEventRaised -= OnAutoRotationChanged;
        if (zoomEventSO != null)
            zoomEventSO.OnEventRaised -= OnZoomChanged;
        if (cameraMoveEventSO != null)
            cameraMoveEventSO.OnEventRaised -= OnCameraMove;
    }

    private void OnAutoRotationChanged(bool value)
    {
        this.autoPan = value;
    }

    private void Start()
    {
        cameraZDistance = cam.fieldOfView;

        Vector3 angles = transform.eulerAngles;

        startAngle.x = angles.x;
        startAngle.y = angles.y;
    }

    private void Update()
    {
        if (autoPan)
        {
            xVelocity += panSensitivity * Time.deltaTime;
        }
        PanAround();
    }

    private void LateUpdate()
    {
        if (target)
        {
            startAngle.x = xVelocity;
            startAngle.y = yVelocity;

            xRotationAxis += xVelocity;
            yRotationAxis += yVelocity;

            yRotationAxis = ClampAngle(yRotationAxis, panLimit.x, panLimit.y);

            Quaternion rotation = Quaternion.Euler(yRotationAxis, xRotationAxis * autoPanRotationSpeed, 0);
            Vector3 position = rotation * new Vector3(0f, 0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;

            xVelocity = Mathf.Lerp(xVelocity, 0, Time.deltaTime * rotationSmoothing);
            yVelocity = Mathf.Lerp(yVelocity, 0, Time.deltaTime * rotationSmoothing);
        }
    }

    private void PanAround()
    {
        //#if UNITY_EDITOR || UNITY_STANDALONE
        if (autoPan)
        {
            transform.RotateAround(target.position, rotationDirection, autoPanRotationSpeed * Time.smoothDeltaTime);
        }
        else
        {
            transform.LookAt(target);

            //if (Input.GetMouseButton(0))
            //{
            transform.LookAt(target);
            transform.RotateAround(target.position, Vector3.up, cameraMovement.x * panSensitivity);
            //transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * panSensitivity);
            //}
        }
        //#endif
    }

    private void Zoom()
    {
        #if UNITY_ANDROID || UNITY_IOS || UNITY_WSA
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);
            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            cam.fieldOfView = cameraZDistance;
            cameraZDistance += deltaMagnitudeDiff * zoomSensitivity;
            cameraZDistance = Mathf.Clamp(cameraZDistance, cameraZoomRange.x, cameraZoomRange.y);
        }
        #endif
    }

    public void AdjustPanSensitivity(float _sensitivity)
    {
        panSensitivity = _sensitivity * 2;
    }

    public void AdjustZoomSensitivity(float _sensitivity)
    {
        zoomSensitivity = _sensitivity * 4;
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    private void OnCameraMove(Vector2 cameraMove)
    {
        cameraMovement = cameraMove;

        xVelocity += cameraMove.x * panSensitivity;
        yVelocity -= cameraMove.y * panSensitivity;
        //if (cameraMovementLock)
        //    return;

        ////if (isDeviceMouse && !_isRMBPressed)
        ////    return;

        //freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * Time.smoothDeltaTime * speed;
        //freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * Time.smoothDeltaTime * speed;
    }

    private void OnZoomChanged(float zoomValue)
    {
        if (zoomValue == 0f) return;

        float modifier = zoomValue > 0f ? -1f : 1f;
        cameraZDistance = Mathf.SmoothDamp(cameraZDistance, cameraZDistance += zoomSensitivity * modifier, ref zoomVelocity, Time.deltaTime * zoomSoothness);
        cameraZDistance = Mathf.Clamp(cameraZDistance, cameraZoomRange.x, cameraZoomRange.y);
        cam.fieldOfView = cameraZDistance;
    }
}
