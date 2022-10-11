using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "PipelineXAsset_Default.asset", menuName = "Rendering/PipelineXAsset")]
public class PipelineXAsset : RenderPipelineAsset
{
    protected override RenderPipeline CreatePipeline()
    {
        return new PipelineX(this);
    }
}
