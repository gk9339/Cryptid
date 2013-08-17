//*****************************************************************************
// Torque -- HLSL procedural shader
//*****************************************************************************

// Dependencies:
#include "shaders/common/imposter.hlsl"
#include "shaders/common/lighting.hlsl"
//------------------------------------------------------------------------------
// Autogenerated 'Light Buffer Conditioner [RGB]' Uncondition Method
//------------------------------------------------------------------------------
inline void autogenUncondition_bde4cbab(in float4 bufferSample, out float3 lightColor, out float NL_att, out float specular)
{
   lightColor = bufferSample.rgb;
   NL_att = dot(bufferSample.rgb, float3(0.3576, 0.7152, 0.1192));
   specular = max(bufferSample.a / NL_att, 0.00001f);
}


#include "shaders/common/torque.hlsl"

// Features:
// Imposter Vert
// Vert Position
// Base Texture
// Alpha Test
// Bumpmap [Deferred]
// Deferred RT Lighting
// Visibility
// HDR Output
// DXTnm

struct VertData
{
   float4 position        : POSITION;
   float2 tcImposterParams : TEXCOORD0;
   float3 tcImposterUpVec : TEXCOORD1;
   float3 tcImposterRightVec : TEXCOORD2;
};


struct ConnectData
{
   float imposterFade    : TEXCOORD0;
   float4 hpos            : POSITION;
   float2 out_texCoord    : TEXCOORD1;
   float4 screenspacePos  : TEXCOORD2;
};


//-----------------------------------------------------------------------------
// Main
//-----------------------------------------------------------------------------
ConnectData main( VertData IN,
                  uniform float4   imposterLimits  : register(C4),
                  uniform float4   imposterUVs[64] : register(C5),
                  uniform float3   eyePosWorld     : register(C69),
                  uniform float4x4 modelview       : register(C0)
)
{
   ConnectData OUT;

   // Imposter Vert
   float3 inPosition;
   float2 texCoord;
   float3x3 worldToTangent;
   OUT.imposterFade = IN.tcImposterParams.y;
   imposter_v( IN.position.xyz, IN.position.w, IN.tcImposterParams.x * length(IN.tcImposterRightVec), normalize(IN.tcImposterUpVec), normalize(IN.tcImposterRightVec), imposterLimits.y, imposterLimits.x, imposterLimits.z, imposterLimits.w, eyePosWorld, imposterUVs, inPosition, texCoord, worldToTangent );
   float3 wsPosition = inPosition.xyz;
   float3x3 viewToTangent = worldToTangent;
   
   // Vert Position
   OUT.hpos = mul(modelview, float4(inPosition.xyz,1));
   
   // Base Texture
   OUT.out_texCoord = (float2)texCoord;
   
   // Alpha Test
   
   // Bumpmap [Deferred]
   
   // Deferred RT Lighting
   OUT.screenspacePos = OUT.hpos;
   
   // Visibility
   
   // HDR Output
   
   // DXTnm
   
   return OUT;
}
