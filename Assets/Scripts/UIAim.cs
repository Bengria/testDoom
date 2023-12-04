using UnityEngine;
using UnityEngine.UI;

public class UIAim : MonoBehaviour
{
    [SerializeField] private Image aimImage;
    [SerializeField] private Image aimImage2;

    public bool CanShoot { get; set; }

    private void Update()
    {
        aimImage.color = CanShoot ? Color.red : Color.white;
        aimImage2.color = CanShoot ? Color.red : Color.white;
    }
}
