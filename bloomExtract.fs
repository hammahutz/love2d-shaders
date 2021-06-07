extern number bloom_threshold;

vec4 effect (vec4 color, Image texture, vec2 texture_coords, vec2 screen_coords){
    vec4 pixel = Texel(texture, texture_coords);

    number average = (pixel.r + pixel.g + pixel.b) / 3.0;

    if(average < bloom_threshold){
        pixel.r = 0.0;
        pixel.g = 0.0;
        pixel.b = 0.0;
    }

    color = texture

    

    return pixel * color;
}