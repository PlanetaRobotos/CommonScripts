using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.Architecture.Managers.DebugStaff
{
    public class Example : MonoBehaviour
    {
        private void Start()
        {
            DebugX.Log(@"I:orange:b; love:red:b; Unity:yellow:b;
 ColorfullllllllllllllllText:rainbow:b;");

            DebugX.Log(@"sniper:orange:b; bug:green:b;");
        }
    }
}