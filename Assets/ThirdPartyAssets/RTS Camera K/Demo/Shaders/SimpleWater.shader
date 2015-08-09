// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-53-RGB,spec-54-OUT,gloss-55-OUT,normal-52-OUT,alpha-56-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33608,y:32460,tex:21cd7510d26a6474082c92952dfefb48,ntxv:3,isnm:True|UVIN-13-OUT,TEX-35-TEX;n:type:ShaderForge.SFN_Append,id:10,x:34164,y:32419|A-36-OUT,B-39-OUT;n:type:ShaderForge.SFN_TexCoord,id:11,x:34008,y:32717,uv:0;n:type:ShaderForge.SFN_Multiply,id:12,x:33993,y:32537|A-10-OUT,B-28-T;n:type:ShaderForge.SFN_Add,id:13,x:33780,y:32457|A-11-UVOUT,B-12-OUT;n:type:ShaderForge.SFN_ValueProperty,id:14,x:34572,y:32263,ptlb:SpeedX,ptin:_SpeedX,glob:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:15,x:34613,y:32452,ptlb:SpeedY,ptin:_SpeedY,glob:False,v1:-0.3;n:type:ShaderForge.SFN_Tex2d,id:18,x:33626,y:32869,tex:21cd7510d26a6474082c92952dfefb48,ntxv:3,isnm:True|UVIN-20-OUT,TEX-35-TEX;n:type:ShaderForge.SFN_Add,id:20,x:33818,y:32871|A-11-UVOUT,B-24-OUT;n:type:ShaderForge.SFN_Multiply,id:24,x:34032,y:32951|A-26-OUT,B-28-T;n:type:ShaderForge.SFN_Append,id:26,x:34203,y:32833|A-43-OUT,B-45-OUT;n:type:ShaderForge.SFN_Time,id:28,x:34217,y:32664;n:type:ShaderForge.SFN_ValueProperty,id:30,x:34614,y:32866,ptlb:SpeedY2,ptin:_SpeedY2,glob:False,v1:0.6;n:type:ShaderForge.SFN_ValueProperty,id:32,x:34656,y:32718,ptlb:SpeedX2,ptin:_SpeedX2,glob:False,v1:-0.2;n:type:ShaderForge.SFN_Tex2dAsset,id:35,x:33778,y:32634,ptlb:Wave Tex,ptin:_WaveTex,glob:False,tex:21cd7510d26a6474082c92952dfefb48;n:type:ShaderForge.SFN_Divide,id:36,x:34351,y:32304|A-14-OUT,B-41-OUT;n:type:ShaderForge.SFN_Divide,id:39,x:34341,y:32478|A-15-OUT,B-41-OUT;n:type:ShaderForge.SFN_Vector1,id:41,x:34592,y:32576,v1:500;n:type:ShaderForge.SFN_Divide,id:43,x:34396,y:32701|A-32-OUT,B-41-OUT;n:type:ShaderForge.SFN_Divide,id:45,x:34395,y:32860|A-30-OUT,B-41-OUT;n:type:ShaderForge.SFN_NormalBlend,id:52,x:33227,y:32630|BSE-2-RGB,DTL-18-RGB;n:type:ShaderForge.SFN_Color,id:53,x:33210,y:32350,ptlb:Water Color,ptin:_WaterColor,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:54,x:33117,y:32877,ptlb:Specular,ptin:_Specular,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:55,x:33113,y:32980,ptlb:Gloss,ptin:_Gloss,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:56,x:33117,y:33084,ptlb:Transparency,ptin:_Transparency,min:0,cur:0,max:1;proporder:53-35-54-55-56-14-15-30-32;pass:END;sub:END;*/

Shader "RTS Camera K/SimpleWater" {
    Properties {
        _WaterColor ("Water Color", Color) = (0.5,0.5,0.5,1)
        _WaveTex ("Wave Tex", 2D) = "bump" {}
        _Specular ("Specular", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0
        _Transparency ("Transparency", Range(0, 1)) = 0
        _SpeedX ("SpeedX", Float ) = 0.5
        _SpeedY ("SpeedY", Float ) = -0.3
        _SpeedY2 ("SpeedY2", Float ) = 0.6
        _SpeedX2 ("SpeedX2", Float ) = -0.2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _SpeedX;
            uniform float _SpeedY;
            uniform float _SpeedY2;
            uniform float _SpeedX2;
            uniform sampler2D _WaveTex; uniform float4 _WaveTex_ST;
            uniform float4 _WaterColor;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float _Transparency;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_11 = i.uv0;
                float node_41 = 500.0;
                float4 node_28 = _Time + _TimeEditor;
                float2 node_13 = (node_11.rg+(float2((_SpeedX/node_41),(_SpeedY/node_41))*node_28.g));
                float2 node_20 = (node_11.rg+(float2((_SpeedX2/node_41),(_SpeedY2/node_41))*node_28.g));
                float3 node_52_nrm_base = UnpackNormal(tex2D(_WaveTex,TRANSFORM_TEX(node_13, _WaveTex))).rgb + float3(0,0,1);
                float3 node_52_nrm_detail = UnpackNormal(tex2D(_WaveTex,TRANSFORM_TEX(node_20, _WaveTex))).rgb * float3(-1,-1,1);
                float3 node_52_nrm_combined = node_52_nrm_base*dot(node_52_nrm_base, node_52_nrm_detail)/node_52_nrm_base.z - node_52_nrm_detail;
                float3 node_52 = node_52_nrm_combined;
                float3 normalLocal = node_52;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * _WaterColor.rgb;
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor,_Transparency);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _SpeedX;
            uniform float _SpeedY;
            uniform float _SpeedY2;
            uniform float _SpeedX2;
            uniform sampler2D _WaveTex; uniform float4 _WaveTex_ST;
            uniform float4 _WaterColor;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float _Transparency;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_11 = i.uv0;
                float node_41 = 500.0;
                float4 node_28 = _Time + _TimeEditor;
                float2 node_13 = (node_11.rg+(float2((_SpeedX/node_41),(_SpeedY/node_41))*node_28.g));
                float2 node_20 = (node_11.rg+(float2((_SpeedX2/node_41),(_SpeedY2/node_41))*node_28.g));
                float3 node_52_nrm_base = UnpackNormal(tex2D(_WaveTex,TRANSFORM_TEX(node_13, _WaveTex))).rgb + float3(0,0,1);
                float3 node_52_nrm_detail = UnpackNormal(tex2D(_WaveTex,TRANSFORM_TEX(node_20, _WaveTex))).rgb * float3(-1,-1,1);
                float3 node_52_nrm_combined = node_52_nrm_base*dot(node_52_nrm_base, node_52_nrm_detail)/node_52_nrm_base.z - node_52_nrm_detail;
                float3 node_52 = node_52_nrm_combined;
                float3 normalLocal = node_52;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * _WaterColor.rgb;
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * _Transparency,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
