using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace Diwide.Ziggurat
{
    public class CameraController : MonoBehaviour
    {
        // private LinkedList<BaseUnit> _flags = new LinkedList<BaseUnit>();

        private FreeCameraControls _controls;
        private Camera _camera;
        [SerializeField, Layer]
        private LayerMask _mask;

        private bool _activeRotate = false;

        [SerializeField, Range(0.1f, 100f)]
        private float _moveSpeed = 10f;
        
        [SerializeField, Range(0.1f, 1000f)]
        private float _rotateSpeed = 10f;
        
        [SerializeField, Range(0.1f, 100f)]
        private float _upDownSpeed = 10f;

        // [Space, SerializeField] private BaseUnit _flagPrefab;
        [Inject] private SignalBus _signalBus;
        [Inject] private List<GateFacade> _gateFacades;
        [Inject] private PopupPresenter _popupPresenter;

        private int UILayer;
        

        private void Awake()
        {
            UILayer = LayerMask.NameToLayer("UI");
            _controls = new FreeCameraControls();
            _controls.Camera.Select.performed += OnClick;
            _controls.Camera.ActivateRotation.performed += OnActivateRotation;
            _controls.Camera.ActivateRotation.canceled += OnActivateRotation;
            _controls.Camera.Scale.performed += OnScale;
        }

        private void Start()
        {
            _camera = GetComponent<Camera>();
            // _mask = LayerMask.GetMask("Floor");
            // _unit = FindObjectsOfType<NPC>().First(_=>_.name == "Unit");
            // _hunter = FindObjectsOfType<NPC>().First(_=>_.name == "Hunter");
            // if(_hunter!= null) _hunter.Target = _unit;
        }

        private void Update()
        {
            OnMoveAndRotate();
        }

        private void OnMoveAndRotate()
        {
            Vector2 direction = _controls.Camera.Move.ReadValue<Vector2>();
            var forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
            transform.position += (forward * direction.y + transform.right * direction.x) *
                                  (_moveSpeed * Time.deltaTime);
            
            if(!_activeRotate) return;

            direction = _controls.Camera.Rotate.ReadValue<Vector2>();
            var angles = transform.eulerAngles;
            angles.x -= direction.y * _rotateSpeed * Time.deltaTime;
            angles.y += direction.x * _rotateSpeed * Time.deltaTime;
            angles.z = 0;

            transform.eulerAngles = angles;
        }

        private void OnScale(InputAction.CallbackContext ctx)
        {
            transform.position +=
                transform.forward * _controls.Camera.Scale.ReadValue<float>() * _upDownSpeed * Time.deltaTime;
        }

        private void OnActivateRotation(InputAction.CallbackContext obj)
        {
            if (obj.performed) _activeRotate = true; 
            else if (obj.canceled) _activeRotate = false;
            Cursor.lockState = (_activeRotate) ? CursorLockMode.Locked : CursorLockMode.None;
        }

        private void OnClick(InputAction.CallbackContext obj)
        {
            if(IsPointerOverUIElement()) return;
            var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hit, 1000f, _mask, QueryTriggerInteraction.Collide))
            {
                Select(hit.collider.gameObject);
            }
            else
            {
                Deselect();
            }
        }

        private void Select(GameObject selectedGameObject)
        {
            Debug.Log($"{selectedGameObject.layer} selected");
            _signalBus.Fire(new TeamSelectedSignal(){ layer = selectedGameObject.layer });
        }

        private void Deselect()
        {
            Debug.Log("Team deselected");
            _signalBus.Fire(new TeamSelectedSignal(){ layer = LayerMask.NameToLayer("Floor") });
            _popupPresenter.Hide();
        }

        public bool IsPointerOverUIElement()
        {
            return IsPointerOverUIElement(GetEventSystemRaycastResults());
        }
 
 
        //Returns 'true' if we touched or hovering on Unity UI element.
        private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
        {
            for (int index = 0; index < eventSystemRaysastResults.Count; index++)
            {
                RaycastResult curRaysastResult = eventSystemRaysastResults[index];
                if (curRaysastResult.gameObject.layer == UILayer)
                    return true;
            }
            return false;
        }
 
 
        //Gets all event system raycast results of current mouse or touch position.
        static List<RaycastResult> GetEventSystemRaycastResults()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raysastResults);
            return raysastResults;
        }
        private void OnEnable()
        {
            _controls.Camera.Enable();
        }

        private void OnDisable()
        {
            _controls.Camera.Disable();
        }

        private void OnDestroy()
        {
            _controls.Dispose();
        }
    }
}