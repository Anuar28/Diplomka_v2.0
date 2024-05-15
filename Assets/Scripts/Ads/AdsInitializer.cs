using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _gameId = "4a21f72c-a40c-4dcc-acd3-f8fa34efcd9e";
    [SerializeField] private string _androidGameId;
    [SerializeField] private string _iOSGameId;
    [SerializeField] private bool _testMode;
    
    private void Awake()
    {
        if (Advertisement.isInitialized)
            return;
        InitializeAds();
    }
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameId : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization Failed: {error.ToString()} - {message}");
    }
}
