using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip reloadClip;
    public AudioClip shootClip;
    public AudioClip emptyClip;
    public AudioSource reloadSource;
    public AudioSource shootSource;
    public AudioSource emptySource;

    public Transform firePoint;
    public GameObject bulletPrefab;
    private GameObject bullet;
    private Rigidbody2D rb;
    public float bulletForce;
    public static bool canFire = false;

    [Header("Ammo & Reloading")]
    [SerializeField]
    public int gunClipAmmo;
    public int amountsOfClips;
    public int currentAmmo = -1;
    public float reloadTime;
    private bool isReloading = false;
    private float coolDownTimer;
    public float coolDown;

    [Header("Text shizz")]
    public Text ammoText;
    public Text reloadText;
    public Text clipText;

    private void Start()
    {
        currentAmmo = gunClipAmmo;
        amountsOfClips = 0;
        reloadText.enabled = false;
    }

    private void OnEnable()
    {
        isReloading = false;
    }

    void Update()
    {
        //Zorgt dat je klaar bent met reloaden en niks anders kan doen
        if (isReloading) return; 
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            // zorgt ervoor dat de code hieronder niet wordt gecheckt
            return; 
        }

        //Timer naar 0 tellen zodat je weer kan schieten
        if (coolDownTimer > 0) coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0) coolDownTimer = 0;

        //Player won't be able to shoot in resting phase
        if (canFire) {
            if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) && coolDownTimer == 0)
            {
                Shoot();
                coolDownTimer = coolDown;
            }
        }

        ammoText.text = "Ammo: " + currentAmmo;
        clipText.text = "Clips: " + amountsOfClips;
    }

    //Reloading method
    private IEnumerator Reload()
    {
        if (amountsOfClips != 0 && currentAmmo != gunClipAmmo)
        {
            isReloading = true;
            reloadText.enabled = true;
            reloadText.text = "Reloading...";
            reloadSource.PlayOneShot(reloadClip);
            yield return new WaitForSeconds(reloadTime);

            currentAmmo = gunClipAmmo;
            amountsOfClips--;
            isReloading = false;
            reloadText.enabled = false;
        }
        else isReloading = false;   
    }

    //Shooting method
    private void Shoot()
    {
        if (currentAmmo != 0)
        {
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            shootSource.PlayOneShot(shootClip);
            currentAmmo--;
        }
        else if (currentAmmo == 0) emptySource.PlayOneShot(emptyClip);
    }
}
