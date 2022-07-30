namespace Hax;
public class NetworkDesync : HaxModules {
    NetworkMachineSyncUnityClient networkMachineSyncUnityClient = FindObjectOfType<NetworkMachineSyncUnityClient>();
    NetworkMachineSyncUnityClient NetworkMachineSyncUnityClient {
        get {
            if (!this.networkMachineSyncUnityClient) {
                this.networkMachineSyncUnityClient = FindObjectOfType<NetworkMachineSyncUnityClient>();
            }

            return this.networkMachineSyncUnityClient;
        }
    }

    void Update() {
        SetNetworkSync(!MenuOptions.EnableNetworkDesync);
    }

    void SetNetworkSync(bool isNetworkDesync) => this.NetworkMachineSyncUnityClient.gameObject.SetActive(isNetworkDesync);
}