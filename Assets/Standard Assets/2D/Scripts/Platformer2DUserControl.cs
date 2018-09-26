using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool onPickupMode;

        public int TempsAnimPoint;
        public int CDPoing;
        private int compt;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            onPickupMode = false;
            compt = TempsAnimPoint;
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if (Input.GetButtonDown("Action"))
            {
                onPickupMode = !onPickupMode;
                var crateTab = GameObject.FindGameObjectsWithTag("Crate");
                var crate = crateTab[0];
                if (onPickupMode)
                {
                    for (int i = 0; i < crateTab.Length; i++)
                    {
                        crateTab[i].layer= UnityEngine.LayerMask.NameToLayer("CratePickup");//CratePickUP
                    }
                    //crate.layer = UnityEngine.LayerMask.NameToLayer("CratePickup");//CratePickUP
                }
                else
                {
                    for (int i = 0; i < crateTab.Length; i++)
                    {
                        crateTab[i].layer = UnityEngine.LayerMask.NameToLayer("Crate");//CratePickUP
                    }
                    //crate.layer = UnityEngine.LayerMask.NameToLayer("Crate");//crate
                }
            }

            if (Input.GetButtonDown("CoupCAC")&& compt>=TempsAnimPoint+CDPoing)
            {
                var poing = gameObject.transform.FindChild("Poing");
                poing.gameObject.SetActive(true);
                compt = 0;
            }
            if (compt >= TempsAnimPoint){
                var poing = gameObject.transform.FindChild("Poing");
                poing.gameObject.SetActive(false);
            }
            if (compt < TempsAnimPoint+CDPoing)
            {
                compt++;
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
