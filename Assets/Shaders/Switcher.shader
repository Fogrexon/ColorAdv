Shader "Sprite/Switcher"
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

            float square(float2 _uv){
                float angle = _TimeValue;
                float2 uv = mul(_uv, float2x2(cos(angle),-sin(angle),sin(angle),cos(angle)));
                float2 d = abs(uv)-float2(0.6,0.6);
                return 0.1 - abs(length(max(d,0.0)) + min(max(d.x,d.y),0.0));
            }

            float circle(float2 uv){
                return 0.3 - length(uv);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float v = max(square(i.uv), circle(i.uv));
                clip(v-0.001);
                return _Color;
            }
            ENDCG
        }
    }
}
