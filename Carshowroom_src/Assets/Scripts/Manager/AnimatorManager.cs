using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public BoolStateSO leftFrontDoorOpen;
    public BoolStateSO rightFrontDoorOpen;
    public BoolStateSO rearDoorsOpen;

    [Header("Keys of animated parts like Anim. status, parameters")]
    [SerializeField] private string _lfrDoorOpen = "Door_LFR_Open";
    [SerializeField] private string _rfrDoorOpen = "Door_RFR_Open";
    [SerializeField] private string _rearDoorsOpen = "Door_Both_RE_Open";

    [SerializeField] private string _lfrDoorParamDirection = "Door_LFR_Direction";
    [SerializeField] private string _rfrDoorParamDirection = "Door_RFR_Direction";
    [SerializeField] private string _rearDoorsParamDirection = "Door_BothRE_Direction";

    private Animator anim;

    private void OnEnable()
    {
        if (leftFrontDoorOpen)
            leftFrontDoorOpen.OnEventRaised += OnLeftFrontDoorOpen;
        if (rightFrontDoorOpen)
            rightFrontDoorOpen.OnEventRaised += OnRightFrontDoorOpen;
        if (rearDoorsOpen)
            rearDoorsOpen.OnEventRaised += OnRearDoorsOpen;
    }

    private void OnDisable()
    {
        if (leftFrontDoorOpen)
            leftFrontDoorOpen.OnEventRaised -= OnLeftFrontDoorOpen;
        if (rightFrontDoorOpen)
            rightFrontDoorOpen.OnEventRaised -= OnRightFrontDoorOpen;
        if (rearDoorsOpen)
            rearDoorsOpen.OnEventRaised -= OnRearDoorsOpen;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnLeftFrontDoorOpen(bool arg)
    {
        if (anim == null) return;

        if (arg)
            anim.SetFloat(_lfrDoorParamDirection, 1);
        else
            anim.SetFloat(_lfrDoorParamDirection, -1);

        anim.Play(_lfrDoorOpen);
    }
    private void OnRightFrontDoorOpen(bool arg)
    {
        if (anim == null) return;

        if (arg)
            anim.SetFloat(_rfrDoorParamDirection, 1);
        else
            anim.SetFloat(_rfrDoorParamDirection, -1);

        anim.Play(_rfrDoorOpen);
    }
    private void OnRearDoorsOpen(bool arg)
    {
        if (anim == null) return;

        if (arg)
            anim.SetFloat(_rearDoorsParamDirection, 1);
        else
            anim.SetFloat(_rearDoorsParamDirection, -1);

        anim.Play(_rearDoorsOpen);
    }
}
