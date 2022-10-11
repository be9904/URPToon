using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PipelineX : RenderPipeline
{
    public const string k_ShaderTagName = "PipelineX";
    private PipelineXAsset renderPipelineAsset;
    
    // The constructor has an instance of the ExampleRenderPipelineAsset class as its parameter.
    public PipelineX(PipelineXAsset asset) {
        renderPipelineAsset = asset;
    }
    
    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        foreach (var camera in cameras)
        {
            context.SetupCameraProperties(camera);

            if (!camera.TryGetCullingParameters(out ScriptableCullingParameters cullParameters))
                continue;

            var cullingResults = context.Cull(ref cullParameters);

            var unlitShaderTag = new ShaderTagId("XShader");

            var renderSettings = new DrawingSettings(unlitShaderTag, new SortingSettings(camera));
            var filter = new FilteringSettings(RenderQueueRange.opaque){layerMask = camera.cullingMask};
            
            context.DrawRenderers(cullingResults, ref renderSettings, ref filter);

            var commandBuffer = new CommandBuffer();
            commandBuffer.ClearRenderTarget(true, true, Color.blue);
            
            context.ExecuteCommandBuffer(commandBuffer);
        }
        
        context.Submit();
    }
}
