import pygame
from sys import exit




pygame.init()
screen = pygame.display.set_mode((800,400))
pygame.display.set_caption("First_game")
clock = pygame.time.Clock()
test_font = pygame.font.Font(None, 50)
game_active = True
start_time = 0


sky_surface = pygame.image.load('Personal_projects/graphics/tsky.png').convert_alpha()
ground_surface = pygame.image.load('Personal_projects/graphics/tgrnd.png').convert_alpha()

block_surf =  pygame.image.load('Personal_projects/graphics/enemys/tenemy.png').convert_alpha()
block_rect = block_surf.get_rect(midleft = (400,325))
#score_surf = test_font.render('I Eat Eggs', True, 'Black')
#score_rect = score_surf.get_rect(midbottom = (400, 80))


enemy_surf = pygame.image.load('Personal_projects/graphics/enemys/tenemy.png').convert_alpha()
enemy_rect = enemy_surf.get_rect(midbottom = (600, 325))

player_surf = pygame.image.load('Personal_projects/graphics/player/player_walk1.png').convert_alpha()
player_rect = player_surf.get_rect(midbottom = (100, 325))
player_gravity = 0



while True:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
            exit()
        if game_active == True:
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_SPACE and player_rect.bottom >= 325:
                    player_gravity = -20

            
                #if event.key == pygame.K_a: player_rect.left -= 1
                #if event.key == pygame.K_d: player_rect.left += 1
           
            
            
            
            #if event.type == pygame.KEYDOWN:
                #if event.key == pygame.K_SPACE and game_active == False: 
                    #game_active = True
                    #enemy_rect.left = 600
        else:
            if event.type == pygame.KEYDOWN and event.key == pygame.K_SPACE: 
                game_active = True 
                enemy_rect.left = 600
                start_time = int(pygame.time.get_ticks() / 1000)
    
    
    if game_active == True:
        screen.blit(sky_surface,(0,0))
        screen.blit(ground_surface,(0,325))

        
        screen.blit(block_surf,block_rect)

        #pygame.draw.rect(screen, 'Pink', score_rect)
        #pygame.draw.line(screen, 'Gold', (0,0), pygame.mouse.get_pos(), 10)
        #screen.blit(score_surf, score_rect)


        if enemy_rect.left < -100: enemy_rect.left = 850 
        #enemy_rect.left -= 4
        screen.blit(enemy_surf, enemy_rect)


        #Player Stuff!!!---- 
        #if player_rect.left > 850: player_rect.left = -100
        #player_rect.left += 5

        player_gravity += 1
        player_rect.bottom += player_gravity
        keys = pygame.key.get_pressed()
        if keys[pygame.K_a]: player_rect.left -= 4
        if keys[pygame.K_d]:player_rect.left +=4
        
        
        

        if player_rect.bottom >= 325: player_rect.bottom = 325


        screen.blit(player_surf, player_rect)
    
        # colision
        if enemy_rect.colliderect(player_rect):
            game_active = False
    else:
        screen.fill((94,129,162))   
    
    if block_rect.colliderect(player_rect): player_rect.bottom = 300
    
    pygame.display.update()
    clock.tick(60)