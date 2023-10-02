using System.Collections;
using Agava.YandexGames;
using PushKeen.UIFramework.DI;
using UnityEngine;

namespace Initialization
{
    public class InitializationHandler : MonoBehaviour
    {
        [SerializeField] private UIScope _uiScope;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
            PlayerAccount.AuthorizedInBackground += OnAuthorizedInBackground;
        }
        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize();
            Debug.Log("Yandex games initialized");
        }
        
        private void OnAuthorizedInBackground()
        {
            Debug.Log($"{nameof(OnAuthorizedInBackground)} {PlayerAccount.IsAuthorized}");
        }
    }
}