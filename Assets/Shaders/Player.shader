Shader "Sprite/Player"
{
    Properties
    {
        _MainTex("MainTex", 2D) = "white"{}
        _Color("Color", Color) = (.0,.0,.0,1.0)
        _Threshold("Threshold", Float) = 0.5
        _TimeValue("Time", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _Color;
            float _Threshold;
            float _TimeValue;
            #define CIRCLE_NUM 6.0

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv * 2.0 - 1.0;
                return o;
            }

            float random (float2 st) {
                return frac(sin(dot(st.xy,
                    float2(12.9898,78.233)))*
                    43758.5453123);
            }

            float circle(float i, float2 uv) {
                float t = _TimeValue * 4.0;
                float2 r = float2(random(float2(i, .0)), random(float2(.0, i))) + .5;
                float2 p = float2(cos(r.x * t), sin(r.y * t)) * .7;
                return distance(uv, p);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float r = CIRCLE_NUM / distance(i.uv, float2(.0, .0));
                for(float j=0.;j<CIRCLE_NUM;j++) {
                    r += 1.0 / circle(j, i.uv);
                }
                clip(r - _Threshold);
                return _Color;
            }
            ENDCG
        }
    }
}
