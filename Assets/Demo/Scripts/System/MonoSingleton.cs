using UnityEngine;

namespace ActionDemo
{
    public abstract class MonoSingleton : MonoBehaviour
    {
        static GameObject unityObject;

        public static GameObject UnityObject
        {
            get
            {
                if (unityObject != null)
                {
                    return unityObject;
                }

                unityObject = new GameObject("MonoSingleton");
                if (Application.isPlaying)
                {
                    DontDestroyOnLoad(unityObject);
                }
                else
                {
                    unityObject.hideFlags = HideFlags.HideAndDontSave;
                }

                return unityObject;
            }
        }

#if UNITY_EDITOR
        void Awake()
        {
            UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

            void OnPlayModeStateChanged(UnityEditor.PlayModeStateChange state)
            {
                if (state == UnityEditor.PlayModeStateChange.ExitingEditMode)
                {
                    // エディターモードで生成されたインスタンスを破棄
                    if (unityObject != null && !Application.isPlaying)
                    {
                        DestroyImmediate(unityObject);
                        unityObject = null;
                        UnityEditor.EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
                    }
                }
            }
        }
#endif
    }

    public abstract class MonoSingleton<T> : MonoSingleton where T : MonoSingleton<T>
    {
        static T instance;

        public static T Instance => GetOrCreateInstance<T>();

        protected static TInherit GetOrCreateInstance<TInherit>() where TInherit : T
        {
            if (instance != null)
            {
                return instance as TInherit;
            }

            if (instance == null)
            {
                var findTypes = FindObjectsOfType<T>();
                if (findTypes.Length > 0)
                {
                    instance = findTypes[0];
                    return (TInherit)instance;
                }

                if (instance == null)
                {
                    var type = typeof(TInherit);
                    var name = type.ToString();
                    var gameObject = new GameObject(name, type);
                    instance = gameObject.GetComponent<TInherit>();
                    gameObject.transform.parent = UnityObject.transform;
                }
            }

            return (TInherit)instance;
        }

        void OnDestroy()
        {
            instance = null;
        }
    }
}
