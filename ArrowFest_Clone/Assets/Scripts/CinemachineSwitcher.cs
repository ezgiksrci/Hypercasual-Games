using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private CinemachineVirtualCamera lookatCamera;
    [SerializeField] private GameObject scoreUI;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finish Gate"))
        {
            followCamera.gameObject.SetActive(false);
            lookatCamera.gameObject.SetActive(true);
            scoreUI.gameObject.SetActive(false);
        }
    }
}
