using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class InputComponent : MonoBehaviour
    {
        public event Action onChangeMode;

		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				onChangeMode?.Invoke();
			}
		}
    }
}
