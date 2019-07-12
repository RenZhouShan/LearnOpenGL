#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

struct Material {
    sampler2D texture_reflection1;
    sampler2D texture1;    
    sampler2D texture_diffuse1;    
    float shininess;
}; 


void main()
{    
    vec3 viewDir = normalize(cameraPos - Position);
    vec3 normal = normalize(Normal);

    vec3 R = reflect(- viewDir, normal);
    vec3 reflectMap = vec3(texture(material.texture_reflection1, TexCoord));
    vec3 reflection = vec3(texture(material.texture1, R).rgb) * reflectMap;

    float diff = max(normalize(dot(normal, viewDir)), 0.0f);
    vec3 diffuse = diff * vec3(texture(material.texture_diffuse1, TexCoord));

    FragColor = vec4(diffuse + reflection, 1.0f);
}