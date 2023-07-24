using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCPU : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CoreServices.DiagnosticsSystem.ShowDiagnostics = false;
        CoreServices.DiagnosticsSystem.ShowProfiler = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
