#define SAMPLE_COUNT = 15

vec2 sample_offsets[2];
float sample_weight[2];
float bloom_threshold = 0.7;

// extern number bloom_threshold;


vec4 bloomExtract(bool light, vec4 color, Image texture, vec2 texture_coords, vec2 screen_coords){
    vec4 pixel = Texel(texture, texture_coords);
    number average = (pixel.r + pixel.g + pixel.b) / 3.0;
    
    if(light){
        if(average < bloom_threshold){
            pixel.r = 0.0;
            pixel.g = 0.0;
            pixel.b = 0.0;
            pixel.a = 0.0;
        }
    } else{
        if(average >= bloom_threshold){
            pixel.r = 0.0;
            pixel.g = 0.0;
            pixel.b = 0.0;
            pixel.a = 0.0;
        }
    }


    return pixel * color;
}



vec4 gaussianBlur(vec4 pixel, Image texture, vec2 texture_coords){

    for(int i = 0; i < 2; i++){
        pixel = pixel + Texel(texture, texture_coords + sample_offsets[i] * sample_weight[i]);
    }



    return pixel;
}




vec4 effect (vec4 color, Image texture, vec2 texture_coords, vec2 screen_coords){
    vec4 dark_parts = bloomExtract(false, color, texture, texture_coords, screen_coords);
    vec4 light_parts = bloomExtract(true, color, texture, texture_coords, screen_coords);
    light_parts = gaussianBlur(light_parts, texture, texture_coords);



    return light_parts;
    
}


