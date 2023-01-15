using System.Collections;
using UnityEngine;

namespace Ship
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Laser _laserPrefab;
        [SerializeField] private float _cooldown;
        private bool _isReadyToFire = true;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
                if (_isReadyToFire)
                {
                    StartCoroutine(Shoot());
                }
        }
        
        private IEnumerator Shoot()
        {
            _isReadyToFire = false;
            var trans = transform;
            Instantiate(_laserPrefab, trans.position, trans.rotation);
            yield return new WaitForSeconds(_cooldown);
            _isReadyToFire = true;
        }
    }
}
