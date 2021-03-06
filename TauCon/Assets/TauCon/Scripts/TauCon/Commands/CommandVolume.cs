using System.Collections;
using UnityEngine;

namespace TauConsole
{

    /// <summary>
    /// Adds Volume command to console. Changes the value for the global AudioListener volume.
    /// </summary>
    public class CommandVolume : ScriptableObject
    {

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        void Awake()
        {
            this.hideFlags = HideFlags.HideAndDontSave;
        }

        /// <summary>
        /// Changes the volume based on parameter.
        /// </summary>
        /// <param name="param">float</param>
        /// <returns>string AudioListener.volume</returns>
        public static string ChangeVolume(string param)
        {
            float newVolume;

            // if no argument, output the current setting
            if (string.IsNullOrEmpty(param))
            {
                return "Volume: " + AudioListener.volume;
            }
            
            // check if argument is valid
            if (float.Parse(param) >= 0.0f && float.Parse(param) <= 1.0)
            {
                if (float.TryParse(param, out newVolume))
                {
                    AudioListener.volume = newVolume;
                    return "Volume: " + newVolume;
                }
            }

            return TauCon.Colorify("Error: ", TauCon.ErrorColor) + "Failed to set volume, check the syntax.";
        }
    }
}
