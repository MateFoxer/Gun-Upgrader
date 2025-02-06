Shader "Custom/TransparentWallWithOpaqueBlackBorder"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)      // The base color for the material (default white)
        _BorderWidth ("Border Width", Float) = 0.05          // The width of the border (default 0.05)
        _MainTex ("Base Texture", 2D) = "white" { }           // The texture applied to the wall (default white)
        _Transparency ("Transparency", Float) = 0.3          // The transparency level (default 0.3)
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" }

        Pass
        {
            // Set up for transparency
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
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
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            uniform float _BorderWidth;
            uniform float4 _BaseColor;
            uniform float _Transparency;
            uniform sampler2D _MainTex;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // Get the color from the base texture, multiplied by the base color
                half4 texColor = tex2D(_MainTex, i.uv) * _BaseColor;

                // Apply transparency to the texture color
                texColor.a = _Transparency;

                // Determine if the pixel is within the border region (based on UV coordinates)
                float border = step(i.uv.x, _BorderWidth) + step(1.0 - i.uv.x, _BorderWidth) + 
                               step(i.uv.y, _BorderWidth) + step(1.0 - i.uv.y, _BorderWidth);

                // If within the border region, make the color black and fully opaque
                half4 col = texColor;
                col = lerp(half4(0, 0, 0, 1), col, 1.0 - border); // Black border, material color elsewhere
                return col;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
