using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Wannabuh.FPSController;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Card Content/Weapon")]
public class WeaponData : CardContent
{
    [SerializeField] public float fireRate;
    [SerializeField] public float damage;
    [SerializeField] public GameObject weapon;
    
    public override void Realize(GameObject player)
    {
        var camera = Camera.main.GetComponent<UniversalAdditionalCameraData>();
        var spawnPos = player.GetComponent<FPSController>()._cameraRig;
        var instantiatedWeapon = Instantiate(weapon, spawnPos);
        PlayerManager.Instance.CurrentWeapon = instantiatedWeapon.GetComponent<Weapon>();
        var weaponCamera = instantiatedWeapon.GetComponentInChildren<Camera>();
        camera.cameraStack.Add(weaponCamera);
    }
}
