Shader "Unlit/ToonShaderURP_Advanced"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _NormalMap("Normal Map", 2D) = "bump" {}
        _MetallicMap("Metallic (R)", 2D) = "black" {}
        _Shades("Shades", Range(1,20)) = 3
        _InkColor("InkColor", Color) = (0,0,0,1)
        _InkSize("InkSize", float) = 1.0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 200

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float3 positionWS : TEXCOORD1;
                float3 normalWS : TEXCOORD2;
                float3 tangentWS : TEXCOORD3;
                float3 bitangentWS : TEXCOORD4;
                float2 uv : TEXCOORD5;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _NormalMap;
            sampler2D _MetallicMap;

            float _Shades;

            Varyings vert(Attributes input)
            {
                Varyings output;
                float3 positionWS = TransformObjectToWorld(input.positionOS.xyz);
                output.positionHCS = TransformWorldToHClip(positionWS);
                output.positionWS = positionWS;

                float3 normalWS = TransformObjectToWorldNormal(input.normalOS);
                float3 tangentWS = normalize(TransformObjectToWorldDir(input.tangentOS.xyz));
                float3 bitangentWS = cross(normalWS, tangentWS) * input.tangentOS.w;

                output.normalWS = normalWS;
                output.tangentWS = tangentWS;
                output.bitangentWS = bitangentWS;
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);

                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // Get TBN matrix
                float3x3 TBN = float3x3(
                    normalize(input.tangentWS),
                    normalize(input.bitangentWS),
                    normalize(input.normalWS)
                );

                // Get normal from normal map
                float3 normalTS = UnpackNormal(tex2D(_NormalMap, input.uv));
                float3 normalWS = normalize(mul(normalTS, TBN));

                // Get main directional light
                Light mainLight = GetMainLight();

                float3 lightDir = normalize(mainLight.direction);
                float NdotL = max(0.0, dot(normalWS, lightDir));
                NdotL = floor(NdotL * _Shades) / _Shades;

                float4 albedo = tex2D(_MainTex, input.uv);
                float metallic = tex2D(_MetallicMap, input.uv).r;

                float3 color = lerp(albedo.rgb * NdotL, float3(0.04, 0.04, 0.04), metallic);
                return float4(color, 1.0);
            }
            ENDHLSL
        }
    }
}

