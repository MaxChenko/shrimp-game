Shader "Custom/SpriteShapeColor" {
    Properties {
        _MainTex ("Sprite Texture (Alpha Mask)", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata {
                float4 vertex   : POSITION;
                float2 texcoord : TEXCOORD0;
            };
            
            struct v2f {
                float4 vertex   : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target {
                // Sample the texture only to get the alpha for the shape.
                fixed4 texSample = tex2D(_MainTex, i.texcoord);
                fixed4 outputColor = _Color;
                outputColor.a *= texSample.a;  // Multiply our material alpha by the texture's alpha
                return outputColor;
            }
            ENDCG
        }
    }
    Fallback "Sprites/Default"
}


