using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Craft
{
    public string craftName;//이름
    public GameObject craftPrefab;//실제 설치될 프리팹
    public GameObject craftPreviewPrefab;//미리보기 프리팹
}

public class CraftManager : MonoBehaviour
{
    private bool isActivated = false;
    private bool isPreviewActivated = false;

    public InputActionReference pushAButtonR;//오른쪽 컨트롤러 A버튼
    public InputActionReference pushBButtonR;
    public InputActionReference triggerR;

    [SerializeField]
    private GameObject CraftUI;//건물건설 베이스 UI

    [SerializeField]
    private Craft[] craft_Building; //건물건설 탭

    private GameObject cr_Preview; //미리보기 프리팹을 담을 변수
    private GameObject cr_Prefab; //실제 생성될 프리팹을 담을 변수

    [SerializeField]
    private Transform tf_PlayerCamera;//플레이어 카메라의 위치

    private RaycastHit hitInfo;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float range;
    private void Awake()
    {
        pushAButtonR.action.started += OnpushAButtonR;
        pushAButtonR.action.started += OnpushBButtonR;
        triggerR.action.started += OntriggerR;
    }

    public void SlotClick(int slotNumber)
    {
        cr_Preview = Instantiate(craft_Building[slotNumber].craftPreviewPrefab, tf_PlayerCamera.position + tf_PlayerCamera.forward, Quaternion.identity);
        cr_Prefab = craft_Building[slotNumber].craftPrefab;
        isPreviewActivated = true;
        CraftUI.SetActive(false);
    }

    void Update()
    {
        if (isPreviewActivated)
            previewPosUpdate();
    }

    private void previewPosUpdate()
    {
        if (Physics.Raycast(tf_PlayerCamera.position, tf_PlayerCamera.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform != null)
            {
                Vector3 _location = hitInfo.point;
                cr_Preview.transform.position = _location;
            }
        }
    }
    private void CrUI()
    {
        if (!isActivated)
            OpenCrUI();

        else
            CloseCrUI();
    }

    private void OpenCrUI()
    {
        isActivated = true;
        CraftUI.SetActive(true);
    }

    private void CloseCrUI()
    {
        isActivated = false;
        CraftUI.SetActive(false);
    }

    private void Cancel()
    {
        if (isPreviewActivated)
            Destroy(cr_Preview);

        isActivated = false;
        isPreviewActivated = false;
        cr_Preview = null;
        cr_Prefab = null;
        CraftUI.SetActive(false);
    }

    private void Build()
    {
        if (isPreviewActivated)
        {
            Instantiate(cr_Prefab, hitInfo.point, Quaternion.identity);
            Destroy(cr_Preview);
            isActivated = false;
            isPreviewActivated = false;
            cr_Preview = null;
            cr_Prefab = null;
        }
    }


    void OnpushAButtonR(InputAction.CallbackContext context)
    {
        if (!isPreviewActivated)
            CrUI();
    }

    void OnpushBButtonR(InputAction.CallbackContext context)
    {
        Cancel();
    }

    void OntriggerR(InputAction.CallbackContext context)
    {
        Build();
    }
}