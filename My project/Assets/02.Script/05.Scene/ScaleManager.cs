using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleManager : MonoBehaviour
{
    float rayDistance = 30f;
    public GameObject CatWheel;
    bool OnAnim = false;
    public Animator anim;   
    public InputActionReference rightHandSelect;

    private void Awake()
    {
        rightHandSelect.action.started += OnRightHandSelect;
    }

    public void Start()
    {
        CatWheel = GameObject.Find("CatWheelforUnity");    
    }

    void Update()
    {
        //ObjHit();
    }

    public void ObjHit()
    {
        Ray ray = new Ray(transform.position, transform.forward * rayDistance);
        RaycastHit hitData;

        if (Physics.Raycast(transform.position, transform.forward, out hitData, Mathf.Infinity, LayerMask.GetMask("Object")) && !OnAnim)
        {
            OnAnim = true;
            anim.SetBool("OnAnimation", true);
        }

        else if (Physics.Raycast(transform.position, transform.forward, out hitData, Mathf.Infinity, LayerMask.GetMask("Object")) && OnAnim)
        {
            OnAnim = false;
            anim.SetBool("OnAnimation", false);
        }
    }


    public void OnRightHandSelect(InputAction.CallbackContext context)
    {
        //Debug.Log("Right Hand Select");
        ObjHit();
    }
}
