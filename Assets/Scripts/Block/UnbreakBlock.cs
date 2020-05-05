using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBlock
{
    public class UnbreakBlock : BlockBasic
    {
        public override void OnCollison()
        {
            Explosion();
        }
    }
}