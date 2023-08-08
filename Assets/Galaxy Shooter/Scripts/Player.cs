using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool _canTripleShot = false;

    [SerializeField]
    private float _speedBoost = 1.0f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;

    [SerializeField]
    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        //Input.GetMouseButtonDown(0) ==== Input.GetKeyDown(KeyCode.Mouse0)

        if (Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            if (_canTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
            }
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _speed * horizontalInput * _speedBoost * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * verticalInput * _speedBoost * Time.deltaTime);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.45f)
        {
            transform.position = new Vector3(-9.45f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.45f)
        {
            transform.position = new Vector3(9.45f, transform.position.y, 0);
        }
    }


    //Triple shot Powerup 
    public void TripleShotPowerupOn()
    {
        _canTripleShot = true;
        StartCoroutine(TripleShotPowerRoutine());
    }

    public IEnumerator TripleShotPowerRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _canTripleShot = false;
    }

    //Speed Powerup 
    public void SpeedBoostOn()
    {
        _speedBoost = 1.5f;
        StartCoroutine(SpeedBoostRoutine());
    }

    public IEnumerator SpeedBoostRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _speedBoost = 1.0f;
    }

}
