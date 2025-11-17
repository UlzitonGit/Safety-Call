using UnityEngine;

namespace Source.Core
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        public GameInput GameInput;

        public ActionMapType CurentActionMapType; 
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        
        
        public static void Init()
        {
            if (Instance != null)
                return;
            
            GameObject obj = new GameObject("InputManager");
            Instance = obj.AddComponent<InputManager>();
            DontDestroyOnLoad(obj);
            
        }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            GameInput =  new GameInput();
            GameInput.Enable();
        }


        private void OnDisable()
        {
            if (Instance == this)
            {
                print("Disable!!");
                DisableAllActionMaps();
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                GameInput?.Dispose();
                GameInput = null;
                Instance = null;
            }
        }

        private void DisableAllActionMaps()
        {
            GameInput?.Base.Disable();
            GameInput?.Mission.Disable();
            GameInput?.TacticalMove.Disable();
            GameInput?.IndividualMove.Disable();
            GameInput?.Hub.Disable();
            GameInput?.UI.Disable();
            GameInput?.Dialogue.Disable();
        }

        public void SwitchActionMapType(ActionMapType mapType)
        {
            DisableAllActionMaps();
            switch(mapType)
            {
                case ActionMapType.MissionController:
                    GameInput.Base.Enable();
                    GameInput.Mission.Enable();
                    GameInput.TacticalMove.Enable();
                    break;
                case ActionMapType.HubController:
                    GameInput.Base.Enable();
                    GameInput.Hub.Enable();
                    break;
                case ActionMapType.TacticalMove:
                    GameInput.Base.Enable();
                    GameInput.Mission.Enable();
                    GameInput.TacticalMove.Enable();
                    break;
                case ActionMapType.IndividualMove:
                    GameInput.Base.Enable();
                    GameInput.Mission.Enable();
                    GameInput.IndividualMove.Enable();
                    break;
                case ActionMapType.UI:
                    GameInput.UI.Enable();
                    break;
                case ActionMapType.Dialogue:
                    GameInput.Dialogue.Enable();
                    break;
                default:
                    GameInput.Base.Enable();
                    break;

            }
            CurentActionMapType = mapType;
        }
    }

    public enum ActionMapType
    {
        MissionController,
        HubController,
        TacticalMove,
        IndividualMove,
        UI,
        Dialogue

    }
}
