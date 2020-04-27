Shader "Sprite/Goal"
{
    Properties
    {
        _MainTex("MainTex", 2D) = "white"{}
        _Color("Color", Color) = (.0,.0,.0,1.0)
        _TimeValue("Time", Float) = 0.0
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
            float _TimeValue;
            #define PI 3.14159265

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

            float gatherLine(float2 uv) {
                float theta = atan(uv.y / uv.x);
                float r = length(uv);
                return pow(cos(r * 3.0 + _TimeValue * 6.0) * saturate(sin(theta * 10.0) * sin(r * 0.8 * PI)), 2.0);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                clip(gatherLine(i.uv) - 0.5);
                return _Color;
            }
            ENDCG
        }
    }
}
