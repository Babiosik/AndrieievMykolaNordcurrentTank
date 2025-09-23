using System.Collections;
using UnityEngine;

namespace Tanks
{
    public class TankAppearanceController : MonoBehaviour
    {
        private SpriteRenderer[] renderers;
        private Collider2D[] colliders;

        private void Awake()
        {
            renderers = GetComponentsInChildren<SpriteRenderer>();
            colliders = GetComponentsInChildren<Collider2D>();
        }

        public void StartSpawnAnimation() => StartCoroutine(SpawnAnimation());
        private IEnumerator SpawnAnimation()
        {
            foreach (var collider in colliders)
                collider.enabled = false;

            foreach (var renderer in renderers)
                renderer.color = new Color(1f, 1f, 1f, .5f);

            yield return new WaitForSeconds(2f);

            foreach (var renderer in renderers)
                renderer.color = new Color(1f, 1f, 1f, 1f);

            foreach (var collider in colliders)
                collider.enabled = true;
        }


    }
}