using UnityEngine;

namespace Source.Core
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        public GameInput GameInput;

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
            GameInput =  new GameInput();
            GameInput.Enable();
        }


        private void OnDisable()
        {
            if (Instance == this)
            {
                GameInput.Disable();
                GameInput.MissionController.Disable();
                GameInput.TacticalMove.Disable();
                GameInput = null;
                Instance = null;
            }
        }

        public void SwitchActionMapType(ActionMapType mapType)
        {
            switch(mapType)
            {
                case ActionMapType.MissionController:
                    GameInput.MissionController.Enable();
                    GameInput.TacticalMove.Enable();
                    GameInput.HubController.Disable();
                    GameInput.IndividualMove.Disable();
                    GameInput.UI.Disable();
                    GameInput.Dialogue.Disable();
                    break;
                case ActionMapType.HubController:
                    GameInput.HubController.Enable();
                    GameInput.MissionController.Disable();
                    GameInput.TacticalMove.Disable();
                    GameInput.IndividualMove.Disable();
                    GameInput.UI.Disable();
                    GameInput.Dialogue.Disable();
                    break;
                case ActionMapType.TacticalMove:
                    GameInput.TacticalMove.Enable();
                    GameInput.MissionController.Enable();
                    GameInput.IndividualMove.Disable();
                    break;
                case ActionMapType.IndividualMove:
                    GameInput.IndividualMove.Enable();
                    GameInput.MissionController.Enable();
                    GameInput.TacticalMove.Disable();
                    break;
                case ActionMapType.UI:
                    GameInput.UI.Enable();
                    GameInput.MissionController.Disable();
                    GameInput.TacticalMove.Disable();
                    GameInput.IndividualMove.Disable();
                    GameInput.HubController.Disable();
                    GameInput.Dialogue.Disable();
                    break;
                case ActionMapType.Dialogue:
                    GameInput.Dialogue.Enable();
                    GameInput.HubController.Disable();
                    GameInput.UI.Disable();
                    break;
                default:
                    GameInput.TacticalMove.Enable(); 
                    break;

            }
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
