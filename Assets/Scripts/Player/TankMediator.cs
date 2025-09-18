using Tanks;
using UnityEngine;

namespace Player
{
    public class TankMediator : MonoBehaviour
    {
        private TankMovement tankMovement;
        private TankShooting tankShooting;

        private void Awake()
        {
            tankMovement = GetComponent<TankMovement>();
            tankShooting = GetComponent<TankShooting>();
        }

        public TankMovement TankMovement => tankMovement;
        public TankShooting TankShooting => tankShooting;
    }
}