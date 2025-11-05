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
            GameInput.MissionController.Enable();
            GameInput.TacticalMove.Enable();
            GameInput.IndividualMove.Disable();
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
                case ActionMapType.TacticalMove:
                    GameInput.TacticalMove.Enable();
                    GameInput.IndividualMove.Disable();
                    break;
                case ActionMapType.IndividualMove:
                    GameInput.TacticalMove.Disable();
                    GameInput.IndividualMove.Enable();
                    break;
                default:
                    GameInput.TacticalMove.Enable(); 
                    break;

            }
        }

        public enum ActionMapType
        {
            TacticalMove,
            IndividualMove
        }
    }

}
