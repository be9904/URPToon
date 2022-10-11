using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PipelineX : RenderPipeline
{
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

            var commandBuffer = new CommandBuffer();
            commandBuffer.ClearRenderTarget(true, true, Color.blue);
            
            context.ExecuteCommandBuffer(commandBuffer);
        }
        
        context.Submit();
    }
}
