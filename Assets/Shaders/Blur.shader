Shader "Custom/Blur"
{
    Properties
    {
        [PerRendererData] _MainTex("Texture", 2D) = "white" {}
        _Range ("Range", Range(0, 0.1)) = 0.01
        _Color("Color", Color) = (1.0,1.0,1.0,1.0)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Range;
            half4 _Color;

            half4 frag (v2f i) : SV_Target
            {

                half4 pixelCol = half4(0, 0, 0, 0);
                #define PI 3.14159265
                #define ADDPIXEL(weight, pos) tex2D(_MainTex, i.uv + pos * _Range) * weight

                pixelCol += ADDPIXEL(1.0/256.0, float2(-2.0,-2.0));
                pixelCol += ADDPIXEL(4.0/256.0, float2(-1.0,-2.0));
                pixelCol += ADDPIXEL(6.0/256.0, float2(0.0,-2.0));
                pixelCol += ADDPIXEL(4.0/256.0, float2(1.0,-2.0));
                pixelCol += ADDPIXEL(1.0/256.0, float2(2.0,-2.0));

                pixelCol += ADDPIXEL(4.0/256.0, float2(-2.0,-1.0));
                pixelCol += ADDPIXEL(16.0/256.0, float2(-1.0,-1.0));
                pixelCol += ADDPIXEL(24.0/256.0, float2(0.0,-1.0));
                pixelCol += ADDPIXEL(16.0/256.0, float2(1.0,-1.0));
                pixelCol += ADDPIXEL(4.0/256.0, float2(2.0,-1.0));

                pixelCol += ADDPIXEL(6.0/256.0, float2(-2.0,0.0));
                pixelCol += ADDPIXEL(24.0/256.0, float2(-1.0,0.0));
                pixelCol += ADDPIXEL(36.0/256.0, float2(0.0,0.0));
                pixelCol += ADDPIXEL(24.0/256.0, float2(1.0,0.0));
                pixelCol += ADDPIXEL(6.0/256.0, float2(2.0,0.0));

                pixelCol += ADDPIXEL(4.0/256.0, float2(-2.0,1.0));
                pixelCol += ADDPIXEL(16.0/256.0, float2(-1.0,1.0));
                pixelCol += ADDPIXEL(24.0/256.0, float2(0.0,1.0));
                pixelCol += ADDPIXEL(16.0/256.0, float2(1.0,1.0));
                pixelCol += ADDPIXEL(4.0/256.0, float2(2.0,1.0));

                pixelCol += ADDPIXEL(1.0/256.0, float2(-2.0,2.0));
                pixelCol += ADDPIXEL(4.0/256.0, float2(-1.0,2.0));
                pixelCol += ADDPIXEL(6.0/256.0, float2(0.0,2.0));
                pixelCol += ADDPIXEL(4.0/256.0, float2(1.0,2.0));
                pixelCol += ADDPIXEL(1.0/256.0, float2(2.0,2.0));
                return pixelCol * _Color;
            }
            ENDCG
        }
    }
}