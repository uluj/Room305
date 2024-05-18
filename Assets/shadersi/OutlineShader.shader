Shader "Custom/OutlineShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1,1,0,1)
        _OutlineThickness ("Outline Thickness", Range(0.0, 0.1)) = 0.01
    }
    SubShader
    {
        Tags { "Queue" = "Overlay" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _OutlineColor;
            float _OutlineThickness;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float2 uv = i.texcoord;
                half4 color = tex2D(_MainTex, uv);

                float3 outlineColor = _OutlineColor.rgb;

                float x = _OutlineThickness;
                float2 uv1 = uv + float2(x, 0);
                float2 uv2 = uv + float2(-x, 0);
                float2 uv3 = uv + float2(0, x);
                float2 uv4 = uv + float2(0, -x);

                half4 col1 = tex2D(_MainTex, uv1);
                half4 col2 = tex2D(_MainTex, uv2);
                half4 col3 = tex2D(_MainTex, uv3);
                half4 col4 = tex2D(_MainTex, uv4);

                if (color.a == 0 && (col1.a != 0 || col2.a != 0 || col3.a != 0 || col4.a != 0))
                {
                    color.rgb = outlineColor;
                    color.a = 1;
                }

                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
