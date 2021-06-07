function love.load()
    bE = love.graphics.newShader("bloomExtract.fs")
    adventurer = love.graphics.newImage("adventurer.png")
    screen_width, screen_height = love.window.getMode()

    canvas = love.graphics.newCanvas(screen_width, screen_height)
    love.graphics.setCanvas(canvas)
    love.graphics.setColor(0.5, 0.5, 0.5, 1)
    love.graphics.rectangle("fill", 0, 0, screen_width, screen_height)
    love.graphics.setColor(1, 1, 1, 1)
    love.graphics.draw(adventurer, screen_width / 2 - adventurer:getWidth() / 2, screen_height / 2 - adventurer:getHeight() / 2, 0, 2, 2)
    love.graphics.setCanvas()
end

function love.update(dt)
    require("./library/lurker/lurker").update()
    frameRate = 1 / dt

    bloom_threshold = 0.7
    -- bE:send("bloom_threshold", bloom_threshold)
end

function love.draw()
    
    love.graphics.setShader(bE)
    love.graphics.draw(canvas)
    love.graphics.setShader()

    love.graphics.print(string.format("%.0f FPS", frameRate), 10, 22)
end
